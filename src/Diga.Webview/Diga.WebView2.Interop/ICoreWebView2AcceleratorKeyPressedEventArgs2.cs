using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("03b2c8c8-7799-4e34-bd66-ed26aa85f2bf")]
[GeneratedComInterface]
public partial interface ICoreWebView2AcceleratorKeyPressedEventArgs2 : ICoreWebView2AcceleratorKeyPressedEventArgs
{
    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetIsBrowserAcceleratorKeyEnabled();

    void SetIsBrowserAcceleratorKeyEnabled([MarshalAs(UnmanagedType.Bool)] bool value);

}
