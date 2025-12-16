using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("db75dfc7-a857-4632-a398-6969dde26c0a")]
[GeneratedComInterface]
public partial interface ICoreWebView2_22 : ICoreWebView2_21
{
    void AddWebResourceRequestedFilterWithRequestSourceKinds([MarshalAs(UnmanagedType.LPWStr)] string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext, COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);

    void RemoveWebResourceRequestedFilterWithRequestSourceKinds([MarshalAs(UnmanagedType.LPWStr)] string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext, COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);

}
