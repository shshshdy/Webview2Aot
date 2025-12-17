using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("333353b8-48bf-4449-8fcc-22697faf5753")]
[GeneratedComInterface]
public partial interface ICoreWebView2RegionRectCollectionView
{
    uint GetCount();

    RECT GetValueAtIndex(uint index);

}
