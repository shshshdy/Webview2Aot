using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("806268b8-f897-5685-88e5-c45fca0b1a48")]
[GeneratedComInterface]
public partial interface ICoreWebView2_26 : ICoreWebView2_25
{
    void add_SaveFileSecurityCheckStarting([MarshalAs(UnmanagedType.Interface)] ICoreWebView2SaveFileSecurityCheckStartingEventHandler eventHandler, out EventRegistrationToken token);

    void remove_SaveFileSecurityCheckStarting(EventRegistrationToken token);

}
