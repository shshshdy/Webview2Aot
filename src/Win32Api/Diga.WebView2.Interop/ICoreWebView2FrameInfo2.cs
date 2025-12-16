using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("56f85cfa-72c4-11ee-b962-0242ac120002")]
[GeneratedComInterface]
public partial interface ICoreWebView2FrameInfo2 : ICoreWebView2FrameInfo
{
    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2FrameInfo GetParentFrameInfo();

    uint GetFrameId();

    COREWEBVIEW2_FRAME_KIND GetFrameKind();

}
