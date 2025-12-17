using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("7899576c-19e3-57c8-b7d1-55808292de57")]
[GeneratedComInterface]
public partial interface ICoreWebView2SaveFileSecurityCheckStartingEventHandler
{
    void Invoke([MarshalAs(UnmanagedType.Interface)] ICoreWebView2 sender, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2SaveFileSecurityCheckStartingEventArgs args);

}
