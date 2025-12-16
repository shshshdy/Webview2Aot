using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("b32b191a-8998-57ca-b7cb-e04617e4ce4a")]
[GeneratedComInterface]
public partial interface ICoreWebView2ControllerOptions3 : ICoreWebView2ControllerOptions2
{
    COREWEBVIEW2_COLOR GetDefaultBackgroundColor();

    void SetDefaultBackgroundColor(COREWEBVIEW2_COLOR value);

}
