// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2Profile6
// Assembly: Diga.WebView2.interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86C06DAC-1E1B-4B02-A98B-B9D6F676B39A
// Assembly location: O:\webview2\microsoft.web.webview2.1.0.1901.177\Diga.WebView2.interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [Guid("BD82FA6A-1D65-4C33-B2B4-0393020CC61B")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [GeneratedComInterface]
  public partial interface ICoreWebView2Profile6 : ICoreWebView2Profile5
  {
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetIsPasswordAutosaveEnabled();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetIsPasswordAutosaveEnabled(int value);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetIsGeneralAutofillEnabled();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetIsGeneralAutofillEnabled(int value);
    }
}
