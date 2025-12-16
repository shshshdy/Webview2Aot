using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("fbf70c2f-eb1f-4383-85a0-163e92044011")]
[GeneratedComInterface]
public partial interface ICoreWebView2Profile8 : ICoreWebView2Profile7
{
    void Delete();

    void add_Deleted([MarshalAs(UnmanagedType.Interface)] ICoreWebView2ProfileDeletedEventHandler eventHandler, out EventRegistrationToken token);

    void remove_Deleted(EventRegistrationToken token);

}
