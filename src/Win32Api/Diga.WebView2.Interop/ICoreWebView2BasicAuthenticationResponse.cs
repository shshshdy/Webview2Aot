using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("07023f7d-2d77-4d67-9040-6e7d428c6a40")]
[GeneratedComInterface]
public partial interface ICoreWebView2BasicAuthenticationResponse
{
    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetUserName();

    void SetUserName([MarshalAs(UnmanagedType.LPWStr)] string value);

    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetPassword();

    void SetPassword([MarshalAs(UnmanagedType.LPWStr)] string value);

}
