using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("df1aab27-82b9-4ab6-aae8-017a49398c14")]
[GeneratedComInterface]
public partial interface ICoreWebView2ProfileAddBrowserExtensionCompletedHandler
{
    void Invoke(int errorCode, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2BrowserExtension result);

}
