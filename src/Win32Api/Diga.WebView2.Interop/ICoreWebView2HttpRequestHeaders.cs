// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2HttpRequestHeaders
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E8B0323-528E-4C9C-8FF8-A486637C87E1
// Assembly location: O:\webview2\V1096133\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E86CAC0E-5523-465C-B536-8FB9FC8C8C60")]
    [GeneratedComInterface]
    public partial interface ICoreWebView2HttpRequestHeaders
    {
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        string GetHeader([MarshalAs(UnmanagedType.LPWStr)] string name);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICoreWebView2HttpHeadersCollectionIterator GetHeaders(
          [MarshalAs(UnmanagedType.LPWStr)] string name);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int Contains([MarshalAs(UnmanagedType.LPWStr)] string name);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetHeader([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RemoveHeader([MarshalAs(UnmanagedType.LPWStr)] string name);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICoreWebView2HttpHeadersCollectionIterator GetIterator();
    }
}
