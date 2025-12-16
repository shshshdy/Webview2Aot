using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("6baa177e-3a2e-5ccf-9a13-fad676cd0522")]
[GeneratedComInterface]
public partial interface ICoreWebView2SaveAsUIShowingEventHandler
{
    void Invoke([MarshalAs(UnmanagedType.Interface)] ICoreWebView2 sender, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2SaveAsUIShowingEventArgs args);

}
