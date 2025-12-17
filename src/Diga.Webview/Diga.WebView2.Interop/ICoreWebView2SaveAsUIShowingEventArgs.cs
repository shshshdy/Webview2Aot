using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("55902952-0e0d-5aaa-a7d0-e833cdb34f62")]
[GeneratedComInterface]
public partial interface ICoreWebView2SaveAsUIShowingEventArgs
{
    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetContentMimeType();

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetCancel();

    void SetCancel([MarshalAs(UnmanagedType.Bool)] bool value);

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetSuppressDefaultDialog();

    void SetSuppressDefaultDialog([MarshalAs(UnmanagedType.Bool)] bool value);

    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetSaveAsFilePath();

    void SetSaveAsFilePath([MarshalAs(UnmanagedType.LPWStr)] string value);

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetAllowReplace();

    void SetAllowReplace([MarshalAs(UnmanagedType.Bool)] bool value);

    COREWEBVIEW2_SAVE_AS_KIND GetKind();

    void SetKind(COREWEBVIEW2_SAVE_AS_KIND value);

    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2Deferral GetDeferral();

}
