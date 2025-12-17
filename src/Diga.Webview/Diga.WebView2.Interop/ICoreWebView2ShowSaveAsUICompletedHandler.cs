using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("e24b07e3-8169-5c34-994a-7f6478946a3c")]
[GeneratedComInterface]
public partial interface ICoreWebView2ShowSaveAsUICompletedHandler
{
    void Invoke(int errorCode, COREWEBVIEW2_SAVE_AS_UI_RESULT result);

}
