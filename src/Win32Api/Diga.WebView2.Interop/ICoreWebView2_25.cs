using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("b5a86092-df50-5b4f-a17b-6c8f8b40b771")]
[GeneratedComInterface]
public partial interface ICoreWebView2_25 : ICoreWebView2_24
{
    void add_SaveAsUIShowing([MarshalAs(UnmanagedType.Interface)] ICoreWebView2SaveAsUIShowingEventHandler eventHandler, out EventRegistrationToken token);

    void remove_SaveAsUIShowing(EventRegistrationToken token);

    void ShowSaveAsUI([MarshalAs(UnmanagedType.Interface)] ICoreWebView2ShowSaveAsUICompletedHandler handler);

}
