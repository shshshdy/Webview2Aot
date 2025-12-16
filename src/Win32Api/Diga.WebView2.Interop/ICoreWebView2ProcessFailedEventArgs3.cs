using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("ab667428-094d-5fd1-b480-8b4c0fdbdf2f")]
[GeneratedComInterface]
public partial interface ICoreWebView2ProcessFailedEventArgs3 : ICoreWebView2ProcessFailedEventArgs2
{
    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetFailureSourceModulePath();

}
