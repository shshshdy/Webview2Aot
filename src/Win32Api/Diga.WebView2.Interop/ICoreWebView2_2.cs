// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2_2
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E8B0323-528E-4C9C-8FF8-A486637C87E1
// Assembly location: O:\webview2\V1096133\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
    [Guid("9E8F0CF8-E670-4B5E-B2BC-73E061E3184C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface ICoreWebView2_2 : ICoreWebView2
    {
      
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_WebResourceResponseReceived(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_WebResourceResponseReceived(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NavigateWithWebResourceRequest([MarshalAs(UnmanagedType.Interface)] ICoreWebView2WebResourceRequest Request);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_DOMContentLoaded(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2DOMContentLoadedEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_DOMContentLoaded(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICoreWebView2CookieManager GetCookieManager();

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICoreWebView2Environment GetEnvironment();
    }
}
