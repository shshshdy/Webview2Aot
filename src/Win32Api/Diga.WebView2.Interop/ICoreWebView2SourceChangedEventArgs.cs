using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("31e0e545-1dba-4266-8914-f63848a1f7d7")]
[GeneratedComInterface]
public partial interface ICoreWebView2SourceChangedEventArgs
{
    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetIsNewDocument();

}
