// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2EnvironmentOptions3
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2204B57-481A-4FA6-AC70-3A20AA2B2B25
// Assembly location: O:\webview2\microsoft.web.webview2.1.0.1549-prerelease\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("4A5C436E-A9E3-4A2E-89C3-910D3513F5CC")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2EnvironmentOptions3//:ICoreWebView2EnvironmentOptions2
  {
  
        int GetIsCustomCrashReportingEnabled();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetIsCustomCrashReportingEnabled(int value);
    }
}
