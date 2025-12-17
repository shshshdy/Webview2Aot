using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("0de611fd-31e9-5ddc-9d71-95eda26eff32")]
[GeneratedComInterface]
public partial interface ICoreWebView2Frame6 : ICoreWebView2Frame5
{
    void add_ScreenCaptureStarting([MarshalAs(UnmanagedType.Interface)] ICoreWebView2FrameScreenCaptureStartingEventHandler eventHandler, out EventRegistrationToken token);

    void remove_ScreenCaptureStarting(EventRegistrationToken token);

}
