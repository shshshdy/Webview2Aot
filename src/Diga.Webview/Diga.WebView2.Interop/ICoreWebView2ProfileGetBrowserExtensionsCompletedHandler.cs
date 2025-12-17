using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("fce16a1c-f107-4601-8b75-fc4940ae25d0")]
[GeneratedComInterface]
public partial interface ICoreWebView2ProfileGetBrowserExtensionsCompletedHandler
{
    void Invoke(int errorCode, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2BrowserExtensionList result);

}
