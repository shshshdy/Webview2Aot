using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("5cfec11c-25bd-4e8d-9e1a-7acdaeeec047")]
[GeneratedComInterface]
public partial interface ICoreWebView2ObjectCollection : ICoreWebView2ObjectCollectionView
{
    void RemoveValueAtIndex(uint index);

    void InsertValueAtIndex(uint index, [MarshalAs(UnmanagedType.Interface)] object value);

}
