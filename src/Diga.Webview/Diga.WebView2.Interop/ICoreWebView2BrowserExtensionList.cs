using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("2ef3d2dc-bd5f-4f4d-90af-fd67798f0c2f")]
[GeneratedComInterface]
public partial interface ICoreWebView2BrowserExtensionList
{
    uint GetCount();

    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2BrowserExtension GetValueAtIndex(uint index);

}
