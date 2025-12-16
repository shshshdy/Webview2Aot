using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("ab71d500-0820-4a52-809c-48db04ff93bf")]
[GeneratedComInterface]
public partial interface ICoreWebView2NonClientRegionChangedEventArgs
{
    COREWEBVIEW2_NON_CLIENT_REGION_KIND GetRegionKind();

}
