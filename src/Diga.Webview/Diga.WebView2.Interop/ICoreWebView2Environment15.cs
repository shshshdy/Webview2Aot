using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("2ac5ebfb-e654-5961-a667-7971885c7b27")]
[GeneratedComInterface]
public partial interface ICoreWebView2Environment15 : ICoreWebView2Environment14
{
    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2FindOptions CreateFindOptions();

}
