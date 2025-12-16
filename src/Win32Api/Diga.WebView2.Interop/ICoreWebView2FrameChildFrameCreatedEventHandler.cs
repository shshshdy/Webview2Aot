using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("569e40e7-46b7-563d-83ae-1073155664d7")]
[GeneratedComInterface]
public partial interface ICoreWebView2FrameChildFrameCreatedEventHandler
{
    void Invoke([MarshalAs(UnmanagedType.Interface)] ICoreWebView2Frame sender, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2FrameCreatedEventArgs args);

}
