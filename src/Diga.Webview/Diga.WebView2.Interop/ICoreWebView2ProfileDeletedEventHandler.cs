using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("df35055d-772e-4dbe-b743-5fbf74a2b258")]
[GeneratedComInterface]
public partial interface ICoreWebView2ProfileDeletedEventHandler
{
    void Invoke([MarshalAs(UnmanagedType.Interface)] ICoreWebView2Profile sender, [MarshalAs(UnmanagedType.Interface)] object args);

}
