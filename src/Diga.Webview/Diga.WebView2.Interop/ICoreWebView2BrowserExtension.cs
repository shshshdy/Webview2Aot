using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("7EF7FFA0-FAC5-462C-B189-3D9EDBE575DA")]
[GeneratedComInterface]
public partial interface ICoreWebView2BrowserExtension
{
    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetId();

    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetName();

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetIsEnabled();

    void Remove([MarshalAs(UnmanagedType.Interface)] ICoreWebView2BrowserExtensionRemoveCompletedHandler handler);

    void Enable([MarshalAs(UnmanagedType.Bool)] bool isEnabled, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2BrowserExtensionEnableCompletedHandler handler);

}
