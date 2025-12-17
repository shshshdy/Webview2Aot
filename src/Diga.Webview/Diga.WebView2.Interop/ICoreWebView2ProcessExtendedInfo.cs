using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("af4c4c2e-45db-11ee-be56-0242ac120002")]
[GeneratedComInterface]
public partial interface ICoreWebView2ProcessExtendedInfo
{
    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2ProcessInfo GetProcessInfo();

    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2FrameInfoCollection GetAssociatedFrameInfos();

}
