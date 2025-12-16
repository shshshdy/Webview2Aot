using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("47c32d23-1e94-4733-85f1-d9bf4acd0974")]
[GeneratedComInterface]
public partial interface ICoreWebView2NotificationCloseRequestedEventHandler
{
    void Invoke([MarshalAs(UnmanagedType.Interface)] ICoreWebView2Notification sender, [MarshalAs(UnmanagedType.Interface)] object args);

}
