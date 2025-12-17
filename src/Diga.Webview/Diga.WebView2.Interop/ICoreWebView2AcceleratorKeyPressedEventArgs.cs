using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("9f760f8a-fb79-42be-9990-7b56900fa9c7")]
[GeneratedComInterface]
public partial interface ICoreWebView2AcceleratorKeyPressedEventArgs
{
    COREWEBVIEW2_KEY_EVENT_KIND GetKeyEventKind();

    uint GetVirtualKey();

    int GetKeyEventLParam();

    COREWEBVIEW2_PHYSICAL_KEY_STATUS GetPhysicalKeyStatus();

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetHandled();

    void SetHandled([MarshalAs(UnmanagedType.Bool)] bool value);

}
