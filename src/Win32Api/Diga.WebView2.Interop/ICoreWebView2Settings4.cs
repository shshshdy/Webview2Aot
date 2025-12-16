// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2Settings4
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E8B0323-528E-4C9C-8FF8-A486637C87E1
// Assembly location: O:\webview2\V1096133\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("CB56846C-4168-4D53-B04F-03B6D6796FF2")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2Settings4 : ICoreWebView2Settings3
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
