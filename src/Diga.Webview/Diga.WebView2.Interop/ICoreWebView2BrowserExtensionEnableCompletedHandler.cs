using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("30c186ce-7fad-421f-a3bc-a8eaf071ddb8")]
[GeneratedComInterface]
public partial interface ICoreWebView2BrowserExtensionEnableCompletedHandler
{
    void Invoke(int errorCode);

}
