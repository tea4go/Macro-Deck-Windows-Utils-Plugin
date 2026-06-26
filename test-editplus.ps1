<#
.SYNOPSIS
    Macro Deck Windows Utils 插件的自动化端到端测试。
.DESCRIPTION
    可选更新插件到最新版本，重启 Macro Deck，以已配对客户端身份连接
    Macro Deck WebSocket 服务器，模拟按下 EditPlus 按钮，然后通过 Macro Deck
    日志和 EditPlus 进程双重验证测试结果。
.PARAMETER SkipUpdate
    跳过插件更新步骤，仅重启 Macro Deck 并使用磁盘上已有的插件 DLL 进行测试。
.PARAMETER ClientId
    用于 WebSocket 握手的已配对 Macro Deck 客户端 ID。必须已存在于
    devices.json 中（Blocked=false），以避免授权弹窗。
.PARAMETER Row
    EditPlus 按钮所在的行号（默认 0）。
.PARAMETER Column
    EditPlus 按钮所在的列号（默认 1）。
.PARAMETER ServerHost
    Macro Deck 主机地址（默认 localhost）。
.PARAMETER Port
    Macro Deck WebSocket/HTTP 端口（默认 8191）。
.PARAMETER ExpectProcess
    按下按钮时期望启动的进程名称（默认 editplus）。
.EXAMPLE
    powershell -ExecutionPolicy Bypass -File .\test-editplus.ps1 -SkipUpdate
    powershell -ExecutionPolicy Bypass -File .\test-editplus.ps1
#>

param(
    [switch]$SkipUpdate,
    [string]$ClientId = "lvgoejr",
    [int]$Row = 0,
    [int]$Column = 1,
    [string]$ServerHost = "localhost",
    [int]$Port = 8191,
    [string]$ExpectProcess = "editplus"
)

$ErrorActionPreference = "Stop"
$ScriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path

$MacroDeckProcessName = "Macro Deck 2"
$MacroDeckExe = "C:\Program Files\Macro Deck\Macro Deck 2.exe"
$PluginId = "SuchByte.WindowsUtils"
$PluginDir = Join-Path $env:APPDATA "Macro Deck\plugins\$PluginId"
$LogDir = Join-Path $env:APPDATA "Macro Deck\logs"
$ButtonPos = "{0}_{1}" -f $Row, $Column

# ---- 结果跟踪 -------------------------------------------------------
$script:Results = [ordered]@{}
function Set-Result($Name, $Passed, $Detail) {
    $script:Results[$Name] = [pscustomobject]@{ Passed = [bool]$Passed; Detail = $Detail }
}

function Write-Step($Message) { Write-Host "[信息] $Message" -ForegroundColor Cyan }
function Write-Ok($Message)   { Write-Host "[通过] $Message" -ForegroundColor Green }
function Write-Warn($Message) { Write-Host "[警告] $Message" -ForegroundColor Yellow }
function Write-Fail($Message) { Write-Host "[失败] $Message" -ForegroundColor Red }

Write-Host "=== Macro Deck Windows Utils - EditPlus 自动化测试 ===" -ForegroundColor Cyan
Write-Host "目标按钮: 行=$Row 列=$Column (消息='$ButtonPos'), 客户端='$ClientId'"

# ---- 0. 基线记录（在重启前记录，这样插件的 Enable() 日志行会被视为新增内容） ----
$today = Get-Date -Format "yyyyMMdd"
$logPath = Join-Path $LogDir "log$today.txt"
$logBaseline = 0
if (Test-Path $logPath) {
    $logBaseline = (Get-Item $logPath).Length
}
Write-Host "日志文件: $logPath (基线偏移 $logBaseline 字节)"
$pidBaseline = @(Get-Process -Name $ExpectProcess -ErrorAction SilentlyContinue | Select-Object -ExpandProperty Id)
Write-Host "EditPlus 基线 PID: $([string]::Join(',', $pidBaseline))"

# ---- 1. 更新或重启 --------------------------------------------------
if (-not $SkipUpdate) {
    Write-Step "正在更新插件到最新版本并重启 Macro Deck..."
    $updater = Join-Path $ScriptDir "update-plugin.ps1"
    if (-not (Test-Path $updater)) {
        Write-Fail "未找到 update-plugin.ps1，请确保与本脚本在同一目录: $updater"
        exit 1
    }
    & powershell -NoProfile -ExecutionPolicy Bypass -File $updater -Force -AutoRestart
    if ($LASTEXITCODE -ne 0) {
        Write-Fail "update-plugin.ps1 退出，返回码 $LASTEXITCODE"
        exit 1
    }
} else {
    Write-Step "跳过更新，正在重启 Macro Deck 以重新加载磁盘上的插件..."
    $proc = Get-Process -Name $MacroDeckProcessName -ErrorAction SilentlyContinue
    if ($proc) {
        $proc | Stop-Process -Force
        Start-Sleep -Seconds 2
    }
    if (Test-Path $MacroDeckExe) {
        Start-Process -FilePath $MacroDeckExe
    } else {
        Write-Fail "未找到 Macro Deck 可执行文件: $MacroDeckExe"
        exit 1
    }
}

# ---- 2. 等待 WebSocket 端口 --------------------------------------------
Write-Step "正在等待 Macro Deck 端口 $Port 接受连接..."
$portReady = $false
$deadline = (Get-Date).AddSeconds(40)
while ((Get-Date) -lt $deadline) {
    try {
        $tcp = New-Object System.Net.Sockets.TcpClient
        $iar = $tcp.BeginConnect($ServerHost, $Port, $null, $null)
        if ($iar.AsyncWaitHandle.WaitOne(1000) -and $tcp.Connected) {
            $tcp.EndConnect($iar)
            $tcp.Close()
            $portReady = $true
            break
        }
        $tcp.Close()
    } catch { }
    Start-Sleep -Milliseconds 800
}
if ($portReady) {
    Write-Ok "端口 $Port 已就绪。"
} else {
    Write-Fail "端口 $Port 未在规定时间内就绪。"
}
Set-Result "PortReady" $portReady "tcp ${ServerHost}:$Port"
if (-not $portReady) {
    # 无法在无服务器的情况下继续
    Write-Host ""
    Write-Host "=== 测试结果: 失败（服务器不可达） ===" -ForegroundColor Red
    exit 1
}
# 端口打开后，给插件的 Enable() 留一些执行时间
Start-Sleep -Seconds 3

# ---- 5. WebSocket 触发 --------------------------------------------------
function Invoke-WebSocketTrigger($Uri) {
    $ws = New-Object System.Net.WebSockets.ClientWebSocket
    $cts = New-Object System.Threading.CancellationTokenSource
    $cts.CancelAfter(10000)
    $handshake = $null
    try {
        $ws.ConnectAsync([Uri]$Uri, $cts.Token).Wait()

        function Send-Json($obj) {
            $json = ($obj | ConvertTo-Json -Compress)
            $bytes = [System.Text.Encoding]::UTF8.GetBytes($json)
            $seg = New-Object System.ArraySegment[byte] (,$bytes)
            $ws.SendAsync($seg, [System.Net.WebSockets.WebSocketMessageType]::Text, $true, $cts.Token).Wait()
        }

        function Receive-Text() {
            $buffer = New-Object byte[] 16384
            $sb = New-Object System.Text.StringBuilder
            do {
                $seg = New-Object System.ArraySegment[byte] (,$buffer)
                $res = $ws.ReceiveAsync($seg, $cts.Token)
                $res.Wait()
                $r = $res.Result
                [void]$sb.Append([System.Text.Encoding]::UTF8.GetString($buffer, 0, $r.Count))
            } while (-not $res.Result.EndOfMessage)
            return $sb.ToString()
        }

        # 握手
        Send-Json ([ordered]@{ Method = "CONNECTED"; "Client-Id" = $ClientId; API = "20"; "Device-Type" = "Web" })
        Send-Json ([ordered]@{ Method = "GET_BUTTONS" })
        $handshake = Receive-Text

        # 按下 + 释放（EditPlus 动作绑定到 ActionsRelease）
        Send-Json ([ordered]@{ Method = "BUTTON_PRESS"; Message = $ButtonPos })
        Start-Sleep -Milliseconds 150
        Send-Json ([ordered]@{ Method = "BUTTON_RELEASE"; Message = $ButtonPos })
        Start-Sleep -Milliseconds 300

        try {
            $closeCts = New-Object System.Threading.CancellationTokenSource
            $closeCts.CancelAfter(2000)
            $ws.CloseAsync([System.Net.WebSockets.WebSocketCloseStatus]::NormalClosure, "done", $closeCts.Token).Wait()
        } catch { }

        return $handshake
    } finally {
        $ws.Dispose()
        $cts.Dispose()
    }
}

Write-Step "正在连接 WebSocket 并按下 EditPlus 按钮 ($ButtonPos)..."
$handshakeOk = $false
$handshakeText = $null
$wsErr = $null
foreach ($uri in @("ws://${ServerHost}:${Port}", "ws://${ServerHost}:${Port}/ws")) {
    try {
        Write-Host "  尝试连接 $uri"
        $handshakeText = Invoke-WebSocketTrigger $uri
        $handshakeOk = $true
        Write-Ok "WebSocket 会话已通过 $uri 完成"
        break
    } catch {
        $wsErr = $_.Exception.Message
        Write-Warn "  连接失败: $wsErr"
    }
}
Set-Result "WebSocketHandshake" $handshakeOk $(if ($handshakeOk) { "已连接并发送消息" } else { $wsErr })

if ($handshakeText) {
    $preview = $handshakeText
    if ($preview.Length -gt 600) { $preview = $preview.Substring(0, 600) + "..." }
    Write-Host "GET_BUTTONS 响应预览:" -ForegroundColor Gray
    Write-Host $preview -ForegroundColor DarkGray
}

# ---- 6. 验证：日志 + 进程 ----------------------------------------------
Write-Step "正在通过日志和 EditPlus 进程进行验证..."

$pluginLoaded = $false
$pluginError = $false
$editplusStarted = $false
$newLog = ""

$verifyDeadline = (Get-Date).AddSeconds(12)
while ((Get-Date) -lt $verifyDeadline) {
    # 读取新增日志内容
    if (Test-Path $logPath) {
        try {
            $fs = [System.IO.File]::Open($logPath, 'Open', 'Read', 'ReadWrite')
            try {
                if ($fs.Length -gt $logBaseline) {
                    [void]$fs.Seek($logBaseline, 'Begin')
                    $sr = New-Object System.IO.StreamReader($fs)
                    $newLog = $sr.ReadToEnd()
                    $sr.Dispose()
                }
            } finally { $fs.Dispose() }
        } catch { }
    }
    if ($newLog -match "Windows Utils plugin enabled\. Actions=") { $pluginLoaded = $true }
    if ($newLog -match "\[Windows Utils\].*(ERR|Error)") { $pluginError = $true }

    # 检查是否有新的 EditPlus 进程
    $nowPids = @(Get-Process -Name $ExpectProcess -ErrorAction SilentlyContinue | Select-Object -ExpandProperty Id)
    $newPids = $nowPids | Where-Object { $pidBaseline -notcontains $_ }
    if ($newPids.Count -gt 0) { $editplusStarted = $true }

    if ($pluginLoaded -and $editplusStarted) { break }
    Start-Sleep -Milliseconds 700
}

if ($pluginLoaded) { Write-Ok "插件已加载（在日志中发现 'Windows Utils plugin enabled'）。" }
else { Write-Fail "未在新日志中发现插件加载行。" }
Set-Result "PluginLoaded" $pluginLoaded "日志标记"

if (-not $pluginError) { Write-Ok "本轮测试未发现插件错误行。" }
else { Write-Fail "日志中检测到插件错误行。" }
Set-Result "NoPluginError" (-not $pluginError) "日志 [Windows Utils] 错误扫描"

if ($editplusStarted) { Write-Ok "EditPlus 进程已启动。" }
else { Write-Fail "未检测到新的 EditPlus 进程。" }
Set-Result "EditPlusStarted" $editplusStarted "进程 '$ExpectProcess'"

# ---- 7. 测试总结 ------------------------------------------------------------
Write-Host ""
Write-Host "=== 测试总结 ===" -ForegroundColor Cyan
$allPass = $true
foreach ($key in $script:Results.Keys) {
    $r = $script:Results[$key]
    $tag = if ($r.Passed) { "通过" } else { "失败"; }
    $color = if ($r.Passed) { "Green" } else { "Red" }
    if (-not $r.Passed) { $allPass = $false }
    Write-Host ("  {0,-20} {1}  {2}" -f $key, $tag, $r.Detail) -ForegroundColor $color
}

Write-Host ""
if ($allPass) {
    Write-Host "=== 测试结果: 全部通过 ===" -ForegroundColor Green
    exit 0
} else {
    Write-Host "=== 测试结果: 存在失败项 ===" -ForegroundColor Red
    exit 1
}
