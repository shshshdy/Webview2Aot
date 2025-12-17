// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2Environment9
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EA95D0FC-77DE-40CE-8C3C-89517DF28E5B
// Assembly location: O:\webview2\V10118539\Diga.WebView2.Interop.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("F06F41BF-4B5A-49D8-B9F6-FA16CD29F274")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2Environment9 : ICoreWebView2Environment8
  {
   
    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2ContextMenuItem CreateContextMenuItem(
      [MarshalAs(UnmanagedType.LPWStr)] string Label,
      [MarshalAs(UnmanagedType.Interface)] IStream iconStream,
       COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND Kind);
  }
}
