# Minimal WinForms with Diga.WebView2.Wrapper
Take a look at the project file!
If you want to Develope with Designer you must deactivate "PublishAOT" and "_SuppressWinFormsTrimError"
otherwise Visual Studio Designer will not work!

You get an err!

In this case deactivate the values again and restart Visual Studio.

```xml
...
	  <!--Don't forget to disable while Developing!-->
	  <!--<PublishAot>true</PublishAot>-->
	  <!--Don't forget to disable while Developing!-->
	  <!--<_SuppressWinFormsTrimError>true</_SuppressWinFormsTrimError>-->
...
```

If you want to compile AOT enable the values again.
```xml
...
	  <!--Don't forget to disable while Developing!-->
	  <PublishAot>true</PublishAot>
	  <!--Don't forget to disable while Developing!-->
	  <_SuppressWinFormsTrimError>true</_SuppressWinFormsTrimError>
...
```

To compile do not use Publish in Visual Studio, use the command line:
```cmd
dotnet publish -f net10.0-windows -a x64
```
The Compiler will procude warnings!!

you can find the copiled EXE,PDB and other files in the folder:
```
bin\Release\net10.0-windows\win-x64\publish
```




