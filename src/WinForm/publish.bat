cd %cd%
dotnet publish WinTest/WinTest.csproj -r win-x64 -c Release -p:publishAot=true  -p:_SuppressWinFormsTrimError=true -o publish
cd publish/win-x64
del /a /f /s /q "*.pdb"
del /a /f /s /q "*.xml"
echo publish success!
pause