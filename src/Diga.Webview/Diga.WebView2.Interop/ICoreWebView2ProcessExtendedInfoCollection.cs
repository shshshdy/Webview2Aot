using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("32efa696-407a-11ee-be56-0242ac120002")]
[GeneratedComInterface]
public partial interface ICoreWebView2ProcessExtendedInfoCollection
{
    uint GetCount();

    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2ProcessExtendedInfo GetValueAtIndex(uint index);

}
