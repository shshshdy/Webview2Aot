using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("8e41909a-9b18-4bb1-8cdf-930f467a50be")]
[GeneratedComInterface]
public partial interface ICoreWebView2BrowserExtensionRemoveCompletedHandler
{
    void Invoke(int errorCode);

}
