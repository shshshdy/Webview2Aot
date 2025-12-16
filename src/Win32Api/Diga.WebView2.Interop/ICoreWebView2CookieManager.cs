// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2CookieManager
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E8B0323-528E-4C9C-8FF8-A486637C87E1
// Assembly location: O:\webview2\V1096133\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
    [Guid("177CD9E7-B6F5-451A-94A0-5D7A3A4C4141")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface ICoreWebView2CookieManager
    {
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICoreWebView2Cookie CreateCookie(
          [MarshalAs(UnmanagedType.LPWStr)] string name,
          [MarshalAs(UnmanagedType.LPWStr)] string value,
          [MarshalAs(UnmanagedType.LPWStr)] string Domain,
          [MarshalAs(UnmanagedType.LPWStr)] string Path);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICoreWebView2Cookie CopyCookie([MarshalAs(UnmanagedType.Interface)] ICoreWebView2Cookie cookieParam);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCookies([MarshalAs(UnmanagedType.LPWStr)] string uri, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2GetCookiesCompletedHandler handler);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void AddOrUpdateCookie([MarshalAs(UnmanagedType.Interface)] ICoreWebView2Cookie cookie);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DeleteCookie([MarshalAs(UnmanagedType.Interface)] ICoreWebView2Cookie cookie);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DeleteCookies([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string uri);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DeleteCookiesWithDomainAndPath([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string Domain, [MarshalAs(UnmanagedType.LPWStr)] string Path);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DeleteAllCookies();
    }
}
