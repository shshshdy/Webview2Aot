// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2_18
// Assembly: Diga.WebView2.interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86C06DAC-1E1B-4B02-A98B-B9D6F676B39A
// Assembly location: O:\webview2\microsoft.web.webview2.1.0.1901.177\Diga.WebView2.interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [Guid("7A626017-28BE-49B2-B865-3BA2B3522D90")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [GeneratedComInterface]
  public partial interface ICoreWebView2_18 : ICoreWebView2_17
  {
   
    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void add_LaunchingExternalUriScheme(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2LaunchingExternalUriSchemeEventHandler eventHandler,
      out EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void remove_LaunchingExternalUriScheme( EventRegistrationToken token);
  }
}
