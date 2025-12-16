using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("39a7ad55-4287-5cc1-88a1-c6f458593824")]
[GeneratedComInterface]
public partial interface ICoreWebView2_24 : ICoreWebView2_23
{
    void add_NotificationReceived([MarshalAs(UnmanagedType.Interface)] ICoreWebView2NotificationReceivedEventHandler eventHandler, out EventRegistrationToken token);

    void remove_NotificationReceived(EventRegistrationToken token);

}
