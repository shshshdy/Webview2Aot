using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("c65100ac-0de2-5551-a362-23d9bd1d0e1f")]
[GeneratedComInterface]
public partial interface ICoreWebView2FileSystemHandle
{
    COREWEBVIEW2_FILE_SYSTEM_HANDLE_KIND GetKind();

    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetPath();

    COREWEBVIEW2_FILE_SYSTEM_HANDLE_PERMISSION GetPermission();

}
