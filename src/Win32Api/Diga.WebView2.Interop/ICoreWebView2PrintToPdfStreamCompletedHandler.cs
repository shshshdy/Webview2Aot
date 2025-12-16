// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2PrintToPdfStreamCompletedHandler
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2204B57-481A-4FA6-AC70-3A20AA2B2B25
// Assembly location: O:\webview2\microsoft.web.webview2.1.0.1549-prerelease\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("4C9F8229-8F93-444F-A711-2C0DFD6359D5")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2PrintToPdfStreamCompletedHandler
  {
    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Invoke([MarshalAs(UnmanagedType.Error)] int errorCode, [MarshalAs(UnmanagedType.Interface)] IStream pdfStream);
  }
}
