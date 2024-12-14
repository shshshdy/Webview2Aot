cd %cd%
dotnet publish WebviewTestAot/WebviewTestAot.csproj -r win-arm64 -c Release -p:publishAot=true  -p:_SuppressWinFormsTrimError=true -o publish/win-arm64
cd  publish/win-arm64
del /a /f /s /q "*.pdb"
echo publish success!
pause