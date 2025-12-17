using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("7c7ecf51-e918-5caf-853c-e9a2bcc27775")]
[GeneratedComInterface]
public partial interface ICoreWebView2EnvironmentOptions8
{
    COREWEBVIEW2_SCROLLBAR_STYLE GetScrollBarStyle();

    void SetScrollBarStyle(COREWEBVIEW2_SCROLLBAR_STYLE value);

}
