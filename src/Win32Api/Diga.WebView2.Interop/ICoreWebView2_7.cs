// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2_7
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 768C7F4D-BDF8-4A7A-A16F-3879CF339892
// Assembly location: O:\webview2\V10102030\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [Guid("79C24D83-09A3-45AE-9418-487F32A58740")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [GeneratedComInterface]
  public partial interface ICoreWebView2_7 : ICoreWebView2_6
  {
   

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void PrintToPdf(
      [MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath,
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2PrintSettings printSettings,
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2PrintToPdfCompletedHandler handler);
  }
}
