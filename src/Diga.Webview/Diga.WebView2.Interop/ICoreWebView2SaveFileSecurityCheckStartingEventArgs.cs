using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("cf4ff1d1-5a67-5660-8d63-ef699881ea65")]
[GeneratedComInterface]
public partial interface ICoreWebView2SaveFileSecurityCheckStartingEventArgs
{
    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetCancelSave();

    void SetCancelSave([MarshalAs(UnmanagedType.Bool)] bool value);

    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetDocumentOriginUri();

    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetFileExtension();

    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetFilePath();

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetSuppressDefaultPolicy();

    void SetSuppressDefaultPolicy([MarshalAs(UnmanagedType.Bool)] bool value);

    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2Deferral GetDeferral();

}
