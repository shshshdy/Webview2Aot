// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2EnvironmentOptions4
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2BA7B24E-98CF-4C8D-98F5-352A5D059C6B
// Assembly location: O:\webview2\microsoft.web.webview2.1.0.1587.40\Diga.WebView2.Interop.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("AC52D13F-0D38-475A-9DCA-876580D6793E")]

  [GeneratedComInterface]
  public unsafe partial interface ICoreWebView2EnvironmentOptions4 //:ICoreWebView2EnvironmentOptions3
  {


        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        int GetCustomSchemeRegistrations(out uint Count, nint schemeRegistrations);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        int SetCustomSchemeRegistrations(uint Count,ref ICoreWebView2CustomSchemeRegistration  schemeRegistrations);
  }
}
