using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("9c562c24-b219-4d7f-92f6-b187fbbadd56")]
[GeneratedComInterface]
public partial interface ICoreWebView2WebResourceRequestedEventArgs2 : ICoreWebView2WebResourceRequestedEventArgs
{
    COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS GetRequestedSourceKind();

}
