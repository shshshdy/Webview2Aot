// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2_11
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EA95D0FC-77DE-40CE-8C3C-89517DF28E5B
// Assembly location: O:\webview2\V10118539\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("0BE78E56-C193-4051-B943-23B460C08BDB")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2_11 : ICoreWebView2_10
  {
    
    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void CallDevToolsProtocolMethodForSession(
      [MarshalAs(UnmanagedType.LPWStr)] string sessionId,
      [MarshalAs(UnmanagedType.LPWStr)] string methodName,
      [MarshalAs(UnmanagedType.LPWStr)] string parametersAsJson,
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void add_ContextMenuRequested(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2ContextMenuRequestedEventHandler eventHandler,
      out EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void remove_ContextMenuRequested( EventRegistrationToken token);
  }
}
