using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("af641f58-72b2-11ee-b962-0242ac120002")]
[GeneratedComInterface]
public partial interface ICoreWebView2Environment13 : ICoreWebView2Environment12
{
    void GetProcessExtendedInfos([MarshalAs(UnmanagedType.Interface)] ICoreWebView2GetProcessExtendedInfosCompletedHandler handler);

}
