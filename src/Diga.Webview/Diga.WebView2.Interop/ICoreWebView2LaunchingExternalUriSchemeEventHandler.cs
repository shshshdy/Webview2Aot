// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2LaunchingExternalUriSchemeEventHandler
// Assembly: Diga.WebView2.interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86C06DAC-1E1B-4B02-A98B-B9D6F676B39A
// Assembly location: O:\webview2\microsoft.web.webview2.1.0.1901.177\Diga.WebView2.interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [Guid("74F712E0-8165-43A9-A13F-0CCE597E75DF")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [GeneratedComInterface]
  public partial interface ICoreWebView2LaunchingExternalUriSchemeEventHandler
  {
    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Invoke(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2 sender,
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2LaunchingExternalUriSchemeEventArgs args);
  }
}
