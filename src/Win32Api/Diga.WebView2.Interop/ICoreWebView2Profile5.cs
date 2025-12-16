// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2Profile5
// Assembly: Diga.WebView2.interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86C06DAC-1E1B-4B02-A98B-B9D6F676B39A
// Assembly location: O:\webview2\microsoft.web.webview2.1.0.1901.177\Diga.WebView2.interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [Guid("2EE5B76E-6E80-4DF2-BCD3-D4EC3340A01B")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [GeneratedComInterface]
  public partial interface ICoreWebView2Profile5 : ICoreWebView2Profile4
  {
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] 
        [return: MarshalAs(UnmanagedType.Interface)]
        ICoreWebView2CookieManager GetCookieManager();
    }
}
