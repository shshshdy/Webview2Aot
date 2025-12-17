using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("89c5d598-8788-423b-be97-e6e01c0f9ee3")]
[GeneratedComInterface]
public partial interface ICoreWebView2NotificationReceivedEventHandler
{
    void Invoke([MarshalAs(UnmanagedType.Interface)] ICoreWebView2 sender, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2NotificationReceivedEventArgs args);

}
