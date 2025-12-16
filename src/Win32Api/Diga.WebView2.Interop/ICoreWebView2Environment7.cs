// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2Environment7
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C9A383B-96B7-439F-BB3D-B460D16D2875
// Assembly location: O:\webview2\V10105431\Diga.WebView2.Interop.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("43C22296-3BBD-43A4-9C00-5C0DF6DD29A2")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2Environment7 : ICoreWebView2Environment6
  {
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] 
        [return: MarshalAs(UnmanagedType.LPWStr)]
        string GetUserDataFolder();
    }
}
