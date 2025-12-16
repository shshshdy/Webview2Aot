// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2_19
// Assembly: Diga.WebView2.interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86C06DAC-1E1B-4B02-A98B-B9D6F676B39A
// Assembly location: O:\webview2\microsoft.web.webview2.1.0.1901.177\Diga.WebView2.interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("6921F954-79B0-437F-A997-C85811897C68")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2_19 : ICoreWebView2_18
  {
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL GetMemoryUsageTargetLevel();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetMemoryUsageTargetLevel(COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);
    }
}
