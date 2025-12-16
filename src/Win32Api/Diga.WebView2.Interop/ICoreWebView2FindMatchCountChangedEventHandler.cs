using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("da0d6827-4254-5b10-a6d9-412076afc9f3")]
[GeneratedComInterface]
public partial interface ICoreWebView2FindMatchCountChangedEventHandler
{
    void Invoke([MarshalAs(UnmanagedType.Interface)] ICoreWebView2Find sender, [MarshalAs(UnmanagedType.Interface)] object args);

}
