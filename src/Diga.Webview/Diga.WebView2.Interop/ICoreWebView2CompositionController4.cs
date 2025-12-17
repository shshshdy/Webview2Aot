using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("7C367B9B-3D2B-450F-9E58-D61A20F486AA")]
[GeneratedComInterface]
public partial interface ICoreWebView2CompositionController4 : ICoreWebView2CompositionController3
{
    COREWEBVIEW2_NON_CLIENT_REGION_KIND GetNonClientRegionAtPoint(POINT point);

    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2RegionRectCollectionView QueryNonClientRegion(COREWEBVIEW2_NON_CLIENT_REGION_KIND kind);

    void add_NonClientRegionChanged([MarshalAs(UnmanagedType.Interface)] ICoreWebView2NonClientRegionChangedEventHandler eventHandler, out EventRegistrationToken token);

    void remove_NonClientRegionChanged(EventRegistrationToken token);

}
