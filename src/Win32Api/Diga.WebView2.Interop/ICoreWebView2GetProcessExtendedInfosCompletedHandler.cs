using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("f45e55aa-3bc2-11ee-be56-0242ac120002")]
[GeneratedComInterface]
public partial interface ICoreWebView2GetProcessExtendedInfosCompletedHandler
{
    void Invoke(int errorCode, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2ProcessExtendedInfoCollection result);

}
