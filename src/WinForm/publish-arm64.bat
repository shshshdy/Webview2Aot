cd %cd%
dotnet publish WinTest/WinTest.csproj -r win-arm64 -c Release -p:publishAot=true  -p:_SuppressWinFormsTrimError=true -o publish/arm64
cd publish/win-arm64
del /a /f /s /q "*.pdb"
del /a /f /s /q "*.xml"
echo publish success!
pause