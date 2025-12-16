using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("00fbe33b-8c07-517c-aa23-0ddd4b5f6fa0")]
[GeneratedComInterface]
public partial interface ICoreWebView2_27 : ICoreWebView2_26
{
    void add_ScreenCaptureStarting([MarshalAs(UnmanagedType.Interface)] ICoreWebView2ScreenCaptureStartingEventHandler eventHandler, out EventRegistrationToken token);

    void remove_ScreenCaptureStarting(EventRegistrationToken token);

}
