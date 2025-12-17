// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2Profile4
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1241A3C3-E886-4508-B746-7F7141E4C294
// Assembly location: O:\webview2\microsoft.web.webview2.1.0.1722.45\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("8F4AE680-192E-4EC8-833A-21CFADAEF628")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2Profile4 : ICoreWebView2Profile3
  {
   
    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SetPermissionState(
       COREWEBVIEW2_PERMISSION_KIND PermissionKind,
      [MarshalAs(UnmanagedType.LPWStr)] string origin,
       COREWEBVIEW2_PERMISSION_STATE State,
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2SetPermissionStateCompletedHandler completedHandler);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void GetNonDefaultPermissionSettings(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2GetNonDefaultPermissionSettingsCompletedHandler completedHandler);
  }
}
