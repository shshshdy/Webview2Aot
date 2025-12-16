// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2_12
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EA95D0FC-77DE-40CE-8C3C-89517DF28E5B
// Assembly location: O:\webview2\V10118539\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("35D69927-BCFA-4566-9349-6B3E0D154CAC")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2_12 : ICoreWebView2_11
  {
   

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void add_StatusBarTextChanged(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2StatusBarTextChangedEventHandler eventHandler,
      out EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void remove_StatusBarTextChanged( EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] 
        [return: MarshalAs(UnmanagedType.LPWStr)]
        string GetStatusBarText();
    }
}
