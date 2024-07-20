@echo off
taskkill /IM "Macro Deck 2.exe" /F
del "C:\Users\Administrator\AppData\Roaming\Macro Deck\plugins\SuchByte.WindowsUtils\Windows Utils.dll"
dotnet build "Windows Utils.sln"
call start /min "n" "C:\Program Files\Macro Deck\Macro Deck 2.exe"
