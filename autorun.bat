taskkill /IM "Macro Deck 2.exe" /F
dotnet build "Windows Utils.sln"
call start /min "n" "C:\Program Files\Macro Deck\Macro Deck 2.exe"
