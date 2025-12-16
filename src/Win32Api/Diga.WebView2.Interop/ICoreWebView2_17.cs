// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2_17
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1241A3C3-E886-4508-B746-7F7141E4C294
// Assembly location: O:\webview2\microsoft.web.webview2.1.0.1722.45\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("702E75D4-FD44-434D-9D70-1A68A6B1192A")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2_17 : ICoreWebView2_16
  {
   
    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void PostSharedBufferToScript(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2SharedBuffer sharedBuffer,
       COREWEBVIEW2_SHARED_BUFFER_ACCESS access,
      [MarshalAs(UnmanagedType.LPWStr)] string additionalDataAsJson);
  }
}
