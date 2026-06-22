<#
.SYNOPSIS
    Automated end-to-end test for the Macro Deck Windows Utils plugin.
.DESCRIPTION
    Optionally updates the plugin to the latest release, restarts Macro Deck,
    connects to the Macro Deck WebSocket server as a paired client, simulates
    pressing the EditPlus button, then verifies the result through both the
    Macro Deck log and the EditPlus process.
.PARAMETER SkipUpdate
    Skip the plugin update. Only restart Macro Deck and run the test against
    the plugin DLL currently on disk.
.PARAMETER ClientId
    Paired Macro Deck client id used for the WebSocket handshake. Must already
    exist in devices.json (Blocked=false) to avoid an approval prompt.
.PARAMETER Row
    Button row of the EditPlus button (default 0).
.PARAMETER Column
    Button column of the EditPlus button (default 1).
.PARAMETER ServerHost
    Macro Deck host (default localhost).
.PARAMETER Port
    Macro Deck WebSocket/HTTP port (default 8191).
.PARAMETER ExpectProcess
    Process name expected to start when the button is pressed (default editplus).
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

# ---- result tracking -------------------------------------------------------
$script:Results = [ordered]@{}
function Set-Result($Name, $Passed, $Detail) {
    $script:Results[$Name] = [pscustomobject]@{ Passed = [bool]$Passed; Detail = $Detail }
}

function Write-Step($Message) { Write-Host "[INFO] $Message" -ForegroundColor Cyan }
function Write-Ok($Message)   { Write-Host "[ OK ] $Message" -ForegroundColor Green }
function Write-Warn($Message) { Write-Host "[WARN] $Message" -ForegroundColor Yellow }
function Write-Fail($Message) { Write-Host "[FAIL] $Message" -ForegroundColor Red }

Write-Host "=== Macro Deck Windows Utils - EditPlus Auto Test ===" -ForegroundColor Cyan
Write-Host "Target button: row=$Row column=$Column (Message='$ButtonPos'), client='$ClientId'"

# ---- 0. baselines (BEFORE restart, so the plugin Enable() log line counts as new) ----
$today = Get-Date -Format "yyyyMMdd"
$logPath = Join-Path $LogDir "log$today.txt"
$logBaseline = 0
if (Test-Path $logPath) {
    $logBaseline = (Get-Item $logPath).Length
}
Write-Host "Log file: $logPath (baseline offset $logBaseline bytes)"
$pidBaseline = @(Get-Process -Name $ExpectProcess -ErrorAction SilentlyContinue | Select-Object -ExpandProperty Id)
Write-Host "EditPlus baseline PIDs: $([string]::Join(',', $pidBaseline))"

# ---- 1. update or restart --------------------------------------------------
if (-not $SkipUpdate) {
    Write-Step "Updating plugin to latest release and restarting Macro Deck..."
    $updater = Join-Path $ScriptDir "update-plugin.ps1"
    if (-not (Test-Path $updater)) {
        Write-Fail "update-plugin.ps1 not found next to this script: $updater"
        exit 1
    }
    & powershell -NoProfile -ExecutionPolicy Bypass -File $updater -Force -AutoRestart
    if ($LASTEXITCODE -ne 0) {
        Write-Fail "update-plugin.ps1 exited with code $LASTEXITCODE"
        exit 1
    }
} else {
    Write-Step "Skip update. Restarting Macro Deck to reload plugin from disk..."
    $proc = Get-Process -Name $MacroDeckProcessName -ErrorAction SilentlyContinue
    if ($proc) {
        $proc | Stop-Process -Force
        Start-Sleep -Seconds 2
    }
    if (Test-Path $MacroDeckExe) {
        Start-Process -FilePath $MacroDeckExe
    } else {
        Write-Fail "Macro Deck executable not found: $MacroDeckExe"
        exit 1
    }
}

# ---- 2. wait for WebSocket port --------------------------------------------
Write-Step "Waiting for Macro Deck port $Port to accept connections..."
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
    Write-Ok "Port $Port is ready."
} else {
    Write-Fail "Port $Port did not become ready in time."
}
Set-Result "PortReady" $portReady "tcp ${ServerHost}:$Port"
if (-not $portReady) {
    # cannot continue without server
    Write-Host ""
    Write-Host "=== RESULT: FAIL (server not reachable) ===" -ForegroundColor Red
    exit 1
}
# give the plugin Enable() a moment to run after the port opens
Start-Sleep -Seconds 3

# ---- 5. WebSocket trigger --------------------------------------------------
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

        # handshake
        Send-Json ([ordered]@{ Method = "CONNECTED"; "Client-Id" = $ClientId; API = "20"; "Device-Type" = "Web" })
        Send-Json ([ordered]@{ Method = "GET_BUTTONS" })
        $handshake = Receive-Text

        # press + release (EditPlus action is bound to ActionsRelease)
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

Write-Step "Connecting WebSocket and pressing EditPlus button ($ButtonPos)..."
$handshakeOk = $false
$handshakeText = $null
$wsErr = $null
foreach ($uri in @("ws://${ServerHost}:${Port}", "ws://${ServerHost}:${Port}/ws")) {
    try {
        Write-Host "  trying $uri"
        $handshakeText = Invoke-WebSocketTrigger $uri
        $handshakeOk = $true
        Write-Ok "WebSocket session completed via $uri"
        break
    } catch {
        $wsErr = $_.Exception.Message
        Write-Warn "  failed: $wsErr"
    }
}
Set-Result "WebSocketHandshake" $handshakeOk $(if ($handshakeOk) { "connected & messages sent" } else { $wsErr })

if ($handshakeText) {
    $preview = $handshakeText
    if ($preview.Length -gt 600) { $preview = $preview.Substring(0, 600) + "..." }
    Write-Host "GET_BUTTONS response preview:" -ForegroundColor Gray
    Write-Host $preview -ForegroundColor DarkGray
}

# ---- 6. verify: log + process ----------------------------------------------
Write-Step "Verifying via log and EditPlus process..."

$pluginLoaded = $false
$pluginError = $false
$editplusStarted = $false
$newLog = ""

$verifyDeadline = (Get-Date).AddSeconds(12)
while ((Get-Date) -lt $verifyDeadline) {
    # read new log content
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

    # check for a new EditPlus process
    $nowPids = @(Get-Process -Name $ExpectProcess -ErrorAction SilentlyContinue | Select-Object -ExpandProperty Id)
    $newPids = $nowPids | Where-Object { $pidBaseline -notcontains $_ }
    if ($newPids.Count -gt 0) { $editplusStarted = $true }

    if ($pluginLoaded -and $editplusStarted) { break }
    Start-Sleep -Milliseconds 700
}

if ($pluginLoaded) { Write-Ok "Plugin loaded (found 'Windows Utils plugin enabled' in log)." }
else { Write-Fail "Plugin load line not found in new log output." }
Set-Result "PluginLoaded" $pluginLoaded "log marker"

if (-not $pluginError) { Write-Ok "No plugin error lines in this run." }
else { Write-Fail "Plugin error lines detected in log." }
Set-Result "NoPluginError" (-not $pluginError) "log [Windows Utils] ERR scan"

if ($editplusStarted) { Write-Ok "EditPlus process started." }
else { Write-Fail "No new EditPlus process detected." }
Set-Result "EditPlusStarted" $editplusStarted "process '$ExpectProcess'"

# ---- 7. summary ------------------------------------------------------------
Write-Host ""
Write-Host "=== Test Summary ===" -ForegroundColor Cyan
$allPass = $true
foreach ($key in $script:Results.Keys) {
    $r = $script:Results[$key]
    $tag = if ($r.Passed) { "PASS" } else { "FAIL"; }
    $color = if ($r.Passed) { "Green" } else { "Red" }
    if (-not $r.Passed) { $allPass = $false }
    Write-Host ("  {0,-20} {1}  {2}" -f $key, $tag, $r.Detail) -ForegroundColor $color
}

Write-Host ""
if ($allPass) {
    Write-Host "=== RESULT: PASS ===" -ForegroundColor Green
    exit 0
} else {
    Write-Host "=== RESULT: FAIL ===" -ForegroundColor Red
    exit 1
}
