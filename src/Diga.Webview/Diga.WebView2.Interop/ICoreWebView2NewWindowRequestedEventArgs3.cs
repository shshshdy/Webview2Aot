using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("842bed3c-6ad6-4dd9-b938-28c96667ad66")]
[GeneratedComInterface]
public partial interface ICoreWebView2NewWindowRequestedEventArgs3 : ICoreWebView2NewWindowRequestedEventArgs2
{
    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2FrameInfo GetOriginalSourceFrameInfo();

}
