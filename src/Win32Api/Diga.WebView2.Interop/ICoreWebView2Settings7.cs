// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2Settings7
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EA95D0FC-77DE-40CE-8C3C-89517DF28E5B
// Assembly location: O:\webview2\V10118539\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("488DC902-35EF-42D2-BC7D-94B65C4BC49C")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2Settings7 : ICoreWebView2Settings6
  {
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        COREWEBVIEW2_PDF_TOOLBAR_ITEMS GetHiddenPdfToolbarItems();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetHiddenPdfToolbarItems(COREWEBVIEW2_PDF_TOOLBAR_ITEMS value);
    }
}
