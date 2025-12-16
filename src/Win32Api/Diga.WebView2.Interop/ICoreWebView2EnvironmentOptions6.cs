using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("57d29cc3-c84f-42a0-b0e2-effbd5e179de")]
[GeneratedComInterface]
public partial interface ICoreWebView2EnvironmentOptions6
{
    [return: MarshalAs(UnmanagedType.Bool)]
    bool GetAreBrowserExtensionsEnabled();

    void SetAreBrowserExtensionsEnabled([MarshalAs(UnmanagedType.Bool)] bool value);

}
