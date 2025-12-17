using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("B7434D98-6BC8-419D-9DA5-FB5A96D4DACD")]
[GeneratedComInterface]
public partial interface ICoreWebView2Notification
{
    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetBody();

    COREWEBVIEW2_TEXT_DIRECTION_KIND GetDirection();

    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetLanguage();

    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetTag();

    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetIconUri();

    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetTitle();

    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetBadgeUri();

    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetBodyImageUri();

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetShouldRenotify();

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetRequiresInteraction();

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetIsSilent();

    double GetTimestamp();

    void add_CloseRequested([MarshalAs(UnmanagedType.Interface)] ICoreWebView2NotificationCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);

    void remove_CloseRequested(EventRegistrationToken token);

    void ReportShown();

    void ReportClicked();

    void ReportClosed();

    void GetVibrationPattern(out uint count, out ulong vibrationPattern);

}
