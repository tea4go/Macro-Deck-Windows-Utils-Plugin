<#
.SYNOPSIS
    Update Macro Deck Windows Utils plugin from the latest GitHub Release.
.DESCRIPTION
    Downloads the latest Windows-Utils-*.zip from GitHub Releases and overwrites
    the local Macro Deck plugin files.
.PARAMETER AutoRestart
    Restart Macro Deck after updating.
.PARAMETER SkipBackup
    Do not create a backup before overwriting files.
.PARAMETER Force
    Reinstall the latest release even when the installed version is already current.
.EXAMPLE
    powershell -ExecutionPolicy Bypass -File .\update-plugin.ps1
    powershell -ExecutionPolicy Bypass -File .\update-plugin.ps1 -AutoRestart
    powershell -ExecutionPolicy Bypass -File .\update-plugin.ps1 -Force
#>

param(
    [switch]$AutoRestart,
    [switch]$SkipBackup,
    [switch]$Force
)

$ErrorActionPreference = "Stop"

$RepoOwner = "tea4go"
$RepoName = "Macro-Deck-Windows-Utils-Plugin"
$PluginId = "SuchByte.WindowsUtils"
$MacroDeckProcessName = "Macro Deck 2"
$MacroDeckExe = "C:\Program Files\Macro Deck\Macro Deck 2.exe"
$PluginDir = Join-Path $env:APPDATA "Macro Deck\plugins\$PluginId"

function Write-Step($Message) {
    Write-Host "[INFO] $Message" -ForegroundColor Cyan
}

function Write-Ok($Message) {
    Write-Host "[ OK ] $Message" -ForegroundColor Green
}

function Write-Warn($Message) {
    Write-Host "[WARN] $Message" -ForegroundColor Yellow
}

function Write-Fail($Message) {
    Write-Host "[FAIL] $Message" -ForegroundColor Red
}

Write-Host "=== Macro Deck Windows Utils Plugin Updater ===" -ForegroundColor Cyan

if (-not (Test-Path $PluginDir)) {
    Write-Fail "Plugin directory does not exist: $PluginDir"
    Write-Host "Install the plugin once before running this updater."
    exit 1
}

Write-Host "Plugin directory: $PluginDir"

$ManifestPath = Join-Path $PluginDir "ExtensionManifest.json"
$CurrentVersion = "unknown"
if (Test-Path $ManifestPath) {
    try {
        $CurrentManifest = Get-Content $ManifestPath -Raw | ConvertFrom-Json
        $CurrentVersion = $CurrentManifest.version
    } catch {
        Write-Warn "Could not read current manifest: $($_.Exception.Message)"
    }
}
Write-Host "Current version: $CurrentVersion"

Write-Step "Querying latest release..."
try {
    $LatestRelease = Invoke-RestMethod `
        -Uri "https://api.github.com/repos/$RepoOwner/$RepoName/releases/latest" `
        -Headers @{ "User-Agent" = "Macro-Deck-Windows-Utils-Updater" }
} catch {
    Write-Fail "Failed to query GitHub Releases: $($_.Exception.Message)"
    exit 1
}

$LatestTag = $LatestRelease.tag_name
$LatestVersion = $LatestTag -replace '^v', ''
Write-Host "Latest version: $LatestTag"

if (($CurrentVersion -eq $LatestVersion) -and (-not $Force)) {
    Write-Ok "Already up to date. Use -Force to reinstall the latest release."
    exit 0
}

$ZipAsset = $LatestRelease.assets |
    Where-Object { $_.name -match '^Windows-Utils-.*\.zip$' } |
    Select-Object -First 1

if (-not $ZipAsset) {
    Write-Fail "No Windows-Utils-*.zip asset found in release $LatestTag."
    exit 1
}

Write-Host "Asset: $($ZipAsset.name)"
Write-Host "URL:   $($ZipAsset.browser_download_url)"

Write-Step "Stopping Macro Deck if it is running..."
$MacroDeckProcess = Get-Process -Name $MacroDeckProcessName -ErrorAction SilentlyContinue
if ($MacroDeckProcess) {
    try {
        $MacroDeckProcess | Stop-Process -Force
        Start-Sleep -Seconds 2
        Write-Ok "Macro Deck stopped."
    } catch {
        Write-Fail "Could not stop Macro Deck: $($_.Exception.Message)"
        Write-Host "Close Macro Deck manually and run this updater again."
        exit 1
    }
} else {
    Write-Host "Macro Deck is not running."
}

$BackupDir = $null
if (-not $SkipBackup) {
    Write-Step "Creating backup..."
    $BackupDir = Join-Path $env:TEMP ("MacroDeck_WindowsUtils_backup_" + (Get-Date -Format "yyyyMMdd_HHmmss"))
    try {
        Copy-Item -Path $PluginDir -Destination $BackupDir -Recurse -Force
        Write-Ok "Backup created: $BackupDir"
    } catch {
        Write-Warn "Backup failed: $($_.Exception.Message)"
    }
}

$TempZip = Join-Path $env:TEMP $ZipAsset.name
$TempExtract = Join-Path $env:TEMP ("MacroDeck_WindowsUtils_extract_" + (Get-Date -Format "yyyyMMdd_HHmmss"))

Write-Step "Downloading release asset..."
try {
    Invoke-WebRequest `
        -Uri $ZipAsset.browser_download_url `
        -OutFile $TempZip `
        -UserAgent "Macro-Deck-Windows-Utils-Updater"
    Write-Ok "Download completed: $TempZip"
} catch {
    Write-Fail "Download failed: $($_.Exception.Message)"
    exit 1
}

Write-Step "Extracting and copying plugin files..."
try {
    Expand-Archive -Path $TempZip -DestinationPath $TempExtract -Force

    $ExtractedPluginDir = Join-Path $TempExtract $PluginId
    if (-not (Test-Path $ExtractedPluginDir)) {
        $ExtractedPluginDir = $TempExtract
    }

    # Replace the plugin directory instead of only overwriting files.
    # This removes stale files such as old .deps.json files from previous releases.
    Get-ChildItem -Path $PluginDir -Force | Remove-Item -Recurse -Force
    Copy-Item -Path (Join-Path $ExtractedPluginDir "*") -Destination $PluginDir -Recurse -Force

    Remove-Item -Path $TempZip -Force -ErrorAction SilentlyContinue
    Remove-Item -Path $TempExtract -Recurse -Force -ErrorAction SilentlyContinue

    Write-Ok "Plugin updated to $LatestTag."
} catch {
    Write-Fail "Update failed: $($_.Exception.Message)"
    if ($BackupDir) {
        Write-Host "Backup directory: $BackupDir"
    }
    exit 1
}

try {
    $UpdatedManifest = Get-Content $ManifestPath -Raw | ConvertFrom-Json
    Write-Host "Installed version: $($UpdatedManifest.version)"
} catch {
    Write-Warn "Could not verify installed version."
}

if ($AutoRestart) {
    Write-Step "Starting Macro Deck..."
    if (Test-Path $MacroDeckExe) {
        Start-Process -FilePath $MacroDeckExe
        Write-Ok "Macro Deck started."
    } else {
        Write-Warn "Macro Deck executable not found: $MacroDeckExe"
    }
} else {
    Write-Host "Start Macro Deck manually to load the updated plugin."
}

Write-Ok "Done."
