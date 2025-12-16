using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("b52d71d6-c4df-4543-a90c-64a3e60f38cb")]
[GeneratedComInterface]
public partial interface ICoreWebView2ZoomFactorChangedEventHandler
{
    void Invoke([MarshalAs(UnmanagedType.Interface)] ICoreWebView2Controller sender, [MarshalAs(UnmanagedType.Interface)] object args);

}
