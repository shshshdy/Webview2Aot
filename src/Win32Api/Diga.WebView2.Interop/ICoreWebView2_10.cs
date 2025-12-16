// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2_10
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1645D9E8-6474-401A-8219-075683886512
// Assembly location: O:\webview2\V10115038\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("B1690564-6F5A-4983-8E48-31D1143FECDB")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2_10 : ICoreWebView2_9
  {
   
    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void add_BasicAuthenticationRequested(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler,
      out EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void remove_BasicAuthenticationRequested( EventRegistrationToken token);
  }
}
