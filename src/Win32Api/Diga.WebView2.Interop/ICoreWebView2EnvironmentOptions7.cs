using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("c48d539f-e39f-441c-ae68-1f66e570bdc5")]
[GeneratedComInterface]
public partial interface ICoreWebView2EnvironmentOptions7
{
    COREWEBVIEW2_CHANNEL_SEARCH_KIND GetChannelSearchKind();

    void SetChannelSearchKind(COREWEBVIEW2_CHANNEL_SEARCH_KIND value);

    COREWEBVIEW2_RELEASE_CHANNELS GetReleaseChannels();

    void SetReleaseChannels(COREWEBVIEW2_RELEASE_CHANNELS value);

}
