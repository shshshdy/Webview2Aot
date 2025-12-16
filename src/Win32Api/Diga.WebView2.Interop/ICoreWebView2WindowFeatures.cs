using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("5eaf559f-b46e-4397-8860-e422f287ff1e")]
[GeneratedComInterface]
public partial interface ICoreWebView2WindowFeatures
{
    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetHasPosition();

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetHasSize();

    uint GetLeft();

    uint GetTop();

    uint GetHeight();

    uint GetWidth();

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetShouldDisplayMenuBar();

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetShouldDisplayStatus();

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetShouldDisplayToolbar();

    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetShouldDisplayScrollBars();

}
