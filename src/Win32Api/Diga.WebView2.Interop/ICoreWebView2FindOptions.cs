using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("e82e3b2b-a4af-5bc6-94c6-18b44157a16c")]
[GeneratedComInterface]
public partial interface ICoreWebView2FindOptions
{
    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetFindTerm();

    void SetFindTerm([MarshalAs(UnmanagedType.LPWStr)] string value);

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetIsCaseSensitive();

    void SetIsCaseSensitive([MarshalAs(UnmanagedType.Bool)] bool value);

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetShouldHighlightAllMatches();

    void SetShouldHighlightAllMatches([MarshalAs(UnmanagedType.Bool)] bool value);

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetShouldMatchWord();

    void SetShouldMatchWord([MarshalAs(UnmanagedType.Bool)] bool value);

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetSuppressDefaultFindDialog();

    void SetSuppressDefaultFindDialog([MarshalAs(UnmanagedType.Bool)] bool value);

}
