using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("892c03fd-aee3-5eba-a1fa-6fd2f6484b2b")]
[GeneratedComInterface]
public partial interface ICoreWebView2ScreenCaptureStartingEventArgs
{
    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetCancel();

    void SetCancel([MarshalAs(UnmanagedType.Bool)] bool value);

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetHandled();

    void SetHandled([MarshalAs(UnmanagedType.Bool)] bool value);

    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2FrameInfo GetOriginalSourceFrameInfo();

    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2Deferral GetDeferral();

}
