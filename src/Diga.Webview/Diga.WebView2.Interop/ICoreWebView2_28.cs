using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("62e50381-5bf5-51a8-aae0-f20a3a9c8a90")]
[GeneratedComInterface]
public partial interface ICoreWebView2_28 : ICoreWebView2_27
{
    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2Find GetFind();

}
