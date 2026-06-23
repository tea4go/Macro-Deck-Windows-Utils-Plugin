param(
    [switch]$Build,
    [switch]$Run,
    [string]$Configuration = "Release"
)

if (-not $Build -and -not $Run) {
    Write-Host "用法: .\run_win.ps1 [-Build] [-Run] [-Configuration <Release|Debug>]"
    Write-Host ""
    Write-Host "  -Build           编译并发布插件到 publish/"
    Write-Host "  -Run             停止 Macro Deck，替换安装插件，并重新启动"
    Write-Host "  -Configuration   构建配置（默认: Release）"
    exit 0
}

$MacroDeckProcessName = "Macro Deck 2"
$MacroDeckExe = "C:\Program Files\Macro Deck\Macro Deck 2.exe"
$PluginDir = Join-Path $env:APPDATA "Macro Deck\plugins\SuchByte.WindowsUtils"
$Output = "publish"

if ($Build) {
    if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
        Write-Error "未找到 .NET SDK，请安装：https://dotnet.microsoft.com/download/dotnet/10.0"
        exit 1
    }

    # 构建前先退出正在运行的 Macro Deck，避免 DLL 被锁
    Get-Process -Name $MacroDeckProcessName -ErrorAction SilentlyContinue | Stop-Process -Force
    Start-Sleep -Seconds 1

    Write-Host "正在还原依赖..."
    dotnet restore "Windows Utils.sln"
    if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

    Write-Host "正在发布 ($Configuration)..."
    dotnet publish "Windows Utils.csproj" -c $Configuration --no-restore -o $Output -p:CI=true
    if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

    Write-Host "完成 -> $Output"
}

if ($Run) {
    if (-not (Test-Path $Output)) {
        Write-Error "输出目录不存在：$Output，请先执行 -Build"
        exit 1
    }

    if (-not (Test-Path $PluginDir)) {
        Write-Error "插件目录不存在：$PluginDir（请先安装插件）"
        exit 1
    }

    # 停止 Macro Deck
    $running = Get-Process -Name $MacroDeckProcessName -ErrorAction SilentlyContinue
    if ($running) {
        Write-Host "正在退出 Macro Deck..."
        $running | Stop-Process -Force
        Start-Sleep -Seconds 2
    }

    # 复制发布输出到插件目录
    Write-Host "正在复制插件文件到：$PluginDir"
    $absOutput = (Resolve-Path $Output).Path
    Copy-Item -Path (Join-Path $absOutput "*") -Destination $PluginDir -Recurse -Force
    Copy-Item -Path "ExtensionManifest.json" -Destination $PluginDir -Force
    Copy-Item -Path "ExtensionIcon.png" -Destination $PluginDir -Force

    # 启动 Macro Deck
    Write-Host "正在启动 Macro Deck..."
    if (Test-Path $MacroDeckExe) {
        Start-Process -FilePath $MacroDeckExe
    } else {
        Write-Warning "未找到 Macro Deck 可执行文件：$MacroDeckExe"
    }
}
