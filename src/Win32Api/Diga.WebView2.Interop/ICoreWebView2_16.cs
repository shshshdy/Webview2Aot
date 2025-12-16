// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2_16
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2204B57-481A-4FA6-AC70-3A20AA2B2B25
// Assembly location: O:\webview2\microsoft.web.webview2.1.0.1549-prerelease\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [Guid("0EB34DC9-9F91-41E1-8639-95CD5943906B")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [GeneratedComInterface]
  public partial interface ICoreWebView2_16 : ICoreWebView2_15
  {
    
    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Print([MarshalAs(UnmanagedType.Interface)] ICoreWebView2PrintSettings printSettings, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2PrintCompletedHandler handler);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void ShowPrintUI( COREWEBVIEW2_PRINT_DIALOG_KIND printDialogKind);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void PrintToPdfStream(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2PrintSettings printSettings,
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2PrintToPdfStreamCompletedHandler handler);
  }
}
