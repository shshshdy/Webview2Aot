// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2Frame2
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B1615030-5202-42C2-A0A8-1F7B8FE362ED
// Assembly location: O:\webview2\V10110844\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [Guid("7A6A5834-D185-4DBF-B63F-4A9BC43107D4")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [GeneratedComInterface]
  public partial interface ICoreWebView2Frame2 : ICoreWebView2Frame
  {
   
    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void add_NavigationStarting(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2FrameNavigationStartingEventHandler eventHandler,
      out EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void remove_NavigationStarting( EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void add_ContentLoading(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2FrameContentLoadingEventHandler eventHandler,
      out EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void remove_ContentLoading( EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void add_NavigationCompleted(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2FrameNavigationCompletedEventHandler eventHandler,
      out EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void remove_NavigationCompleted( EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void add_DOMContentLoaded(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2FrameDOMContentLoadedEventHandler eventHandler,
      out EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void remove_DOMContentLoaded( EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void ExecuteScript([MarshalAs(UnmanagedType.LPWStr)] string javaScript, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2ExecuteScriptCompletedHandler handler);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void PostWebMessageAsJson([MarshalAs(UnmanagedType.LPWStr)] string webMessageAsJson);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void PostWebMessageAsString([MarshalAs(UnmanagedType.LPWStr)] string webMessageAsString);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void add_WebMessageReceived(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2FrameWebMessageReceivedEventHandler handler,
      out EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void remove_WebMessageReceived( EventRegistrationToken token);
  }
}
