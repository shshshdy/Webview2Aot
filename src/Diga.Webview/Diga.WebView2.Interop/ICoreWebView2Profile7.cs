using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("7b4c7906-a1aa-4cb4-b723-db09f813d541")]
[GeneratedComInterface]
public partial interface ICoreWebView2Profile7 : ICoreWebView2Profile6
{
    void AddBrowserExtension([MarshalAs(UnmanagedType.LPWStr)] string extensionFolderPath, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2ProfileAddBrowserExtensionCompletedHandler handler);

    void GetBrowserExtensions([MarshalAs(UnmanagedType.Interface)] ICoreWebView2ProfileGetBrowserExtensionsCompletedHandler handler);

}
