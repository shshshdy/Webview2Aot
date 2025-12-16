using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("b29c7e28-fa79-41a8-8e44-65811c76dcb2")]
[GeneratedComInterface]
public partial interface ICoreWebView2AcceleratorKeyPressedEventHandler
{
    void Invoke([MarshalAs(UnmanagedType.Interface)] ICoreWebView2Controller sender, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2AcceleratorKeyPressedEventArgs args);

}
