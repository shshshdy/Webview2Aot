using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("21eb052f-ad39-555e-824a-c87b091d4d36")]
[GeneratedComInterface]
public partial interface ICoreWebView2ControllerOptions4 : ICoreWebView2ControllerOptions3
{
    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetAllowHostInputProcessing();

    void SetAllowHostInputProcessing([MarshalAs(UnmanagedType.Bool)] bool value);

}
