using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("1512DD5B-5514-4F85-886E-21C3A4C9CFE6")]
[GeneratedComInterface]
public partial interface ICoreWebView2NotificationReceivedEventArgs
{
    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetSenderOrigin();

    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2Notification GetNotification();

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetHandled();

    void SetHandled([MarshalAs(UnmanagedType.Bool)] bool value);

    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2Deferral GetDeferral();

}
