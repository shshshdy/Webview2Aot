using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("508f0db5-90c4-5872-90a7-267a91377502")]
[GeneratedComInterface]
public partial interface ICoreWebView2_23 : ICoreWebView2_22
{
    void PostWebMessageAsJsonWithAdditionalObjects([MarshalAs(UnmanagedType.LPWStr)] string webMessageAsJson, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2ObjectCollectionView additionalObjects);

}
