cd %cd%
dotnet publish WebviewTestAot/WebviewTestAot.csproj -r win-x64 -c Release -p:publishAot=true  -p:_SuppressWinFormsTrimError=true -o publish
cd publish
del /a /f /s /q "*.pdb"
echo publish success!
pause