using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("6a90ecaf-44b0-5bd9-8f07-1967e17be9fb")]
[GeneratedComInterface]
public partial interface ICoreWebView2FindStartCompletedHandler
{
    void Invoke(int errorCode);

}
