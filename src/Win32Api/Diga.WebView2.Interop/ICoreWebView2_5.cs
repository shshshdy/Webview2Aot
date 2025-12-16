// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2_5
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E8B0323-528E-4C9C-8FF8-A486637C87E1
// Assembly location: O:\webview2\V1096133\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [Guid("BEDB11B8-D63C-11EB-B8BC-0242AC130003")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [GeneratedComInterface]
  public partial interface ICoreWebView2_5 : ICoreWebView2_4
  {
  
    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void add_ClientCertificateRequested(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2ClientCertificateRequestedEventHandler eventHandler,
      out EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void remove_ClientCertificateRequested( EventRegistrationToken token);
  }
}
