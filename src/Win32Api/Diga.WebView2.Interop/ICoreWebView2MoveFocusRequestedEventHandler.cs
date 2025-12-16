// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2MoveFocusRequestedEventHandler
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E8B0323-528E-4C9C-8FF8-A486637C87E1
// Assembly location: O:\webview2\V1096133\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("69035451-6DC7-4CB8-9BCE-B2BD70AD289F")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2MoveFocusRequestedEventHandler
  {
    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Invoke([MarshalAs(UnmanagedType.Interface)] ICoreWebView2Controller sender, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2MoveFocusRequestedEventArgs args);
  }
}
