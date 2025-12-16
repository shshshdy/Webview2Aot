using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("99d199c4-7305-11ee-b962-0242ac120002")]
[GeneratedComInterface]
public partial interface ICoreWebView2Frame5 : ICoreWebView2Frame4
{
    uint GetFrameId();

}
