using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("3598cfa2-d85d-5a9f-9228-4dde1f59ec64")]
[GeneratedComInterface]
public partial interface ICoreWebView2Frame7 : ICoreWebView2Frame6
{
    void add_FrameCreated([MarshalAs(UnmanagedType.Interface)] ICoreWebView2FrameChildFrameCreatedEventHandler eventHandler, out EventRegistrationToken token);

    void remove_FrameCreated(EventRegistrationToken token);

}
