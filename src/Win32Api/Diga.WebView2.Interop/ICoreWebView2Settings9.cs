using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("0528a73b-e92d-49f4-927a-e547dddaa37d")]
[GeneratedComInterface]
public partial interface ICoreWebView2Settings9 : ICoreWebView2Settings8
{
    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetIsNonClientRegionSupportEnabled();

    void SetIsNonClientRegionSupportEnabled([MarshalAs(UnmanagedType.Bool)] bool value);

}
