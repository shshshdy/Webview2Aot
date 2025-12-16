using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("4a794e66-aa6c-46bd-93a3-382196837680")]
[GeneratedComInterface]
public partial interface ICoreWebView2NonClientRegionChangedEventHandler
{
    void Invoke([MarshalAs(UnmanagedType.Interface)] ICoreWebView2CompositionController sender, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2NonClientRegionChangedEventArgs args);

}
