using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("a6c1d8ad-bb80-59c5-895b-fba1698b9309")]
[GeneratedComInterface]
public partial interface ICoreWebView2FrameScreenCaptureStartingEventHandler
{
    void Invoke([MarshalAs(UnmanagedType.Interface)] ICoreWebView2Frame sender, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2ScreenCaptureStartingEventArgs args);

}
