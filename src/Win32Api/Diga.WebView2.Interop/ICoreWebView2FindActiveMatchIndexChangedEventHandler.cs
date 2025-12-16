using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("0054f514-9a8e-5876-aed5-30b37f8c86a5")]
[GeneratedComInterface]
public partial interface ICoreWebView2FindActiveMatchIndexChangedEventHandler
{
    void Invoke([MarshalAs(UnmanagedType.Interface)] ICoreWebView2Find sender, [MarshalAs(UnmanagedType.Interface)] object args);

}
