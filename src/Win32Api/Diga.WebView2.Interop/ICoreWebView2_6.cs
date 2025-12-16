// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2_6
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 768C7F4D-BDF8-4A7A-A16F-3879CF339892
// Assembly location: O:\webview2\V10102030\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [Guid("499AADAC-D92C-4589-8A75-111BFC167795")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [GeneratedComInterface]
  public partial interface ICoreWebView2_6 : ICoreWebView2_5
  {
  
    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void OpenTaskManagerWindow();
  }
}
