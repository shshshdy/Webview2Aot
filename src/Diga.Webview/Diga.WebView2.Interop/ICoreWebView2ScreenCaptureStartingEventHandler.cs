using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("e24ff05a-1db5-59d9-89f3-3c864268db4a")]
[GeneratedComInterface]
public partial interface ICoreWebView2ScreenCaptureStartingEventHandler
{
    void Invoke([MarshalAs(UnmanagedType.Interface)] ICoreWebView2 sender, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2ScreenCaptureStartingEventArgs args);

}
