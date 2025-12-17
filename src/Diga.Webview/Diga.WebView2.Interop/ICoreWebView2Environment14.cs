using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("a5e9fad9-c875-59da-9bd7-473aa5ca1cef")]
[GeneratedComInterface]
public partial interface ICoreWebView2Environment14 : ICoreWebView2Environment13
{
    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2FileSystemHandle CreateWebFileSystemFileHandle([MarshalAs(UnmanagedType.LPWStr)] string path, COREWEBVIEW2_FILE_SYSTEM_HANDLE_PERMISSION permission);

    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2FileSystemHandle CreateWebFileSystemDirectoryHandle([MarshalAs(UnmanagedType.LPWStr)] string path, COREWEBVIEW2_FILE_SYSTEM_HANDLE_PERMISSION permission);

    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2ObjectCollection CreateObjectCollection(uint length, [MarshalAs(UnmanagedType.Interface)] object items);

}
