// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2_15
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED88F383-EEB9-472A-9573-53250CD6B18B
// Assembly location: O:\webview2\Microsoft.Web.WebView2.1.0.1370.28\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("517B2D1D-7DAE-4A66-A4F4-10352FFB9518")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2_15 : ICoreWebView2_14
  {
   
    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void add_FaviconChanged(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2FaviconChangedEventHandler eventHandler,
      out EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void remove_FaviconChanged( EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] 
        [return: MarshalAs(UnmanagedType.LPWStr)]
        string GetFaviconUri();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void GetFavicon(
       COREWEBVIEW2_FAVICON_IMAGE_FORMAT format,
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2GetFaviconCompletedHandler completedHandler);
  }
}
