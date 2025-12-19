cd %cd%
dotnet publish Avalonia.WebView/Avalonia.WebView.csproj -r win-x64 -c Release -p:publishAot=true  -o publish/win-x64
cd  publish/win-x64
del /a /f /s /q "*.pdb"
echo publish success!
pause