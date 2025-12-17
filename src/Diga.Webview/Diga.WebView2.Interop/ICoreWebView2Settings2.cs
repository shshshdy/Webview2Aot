// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2Settings2
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E8B0323-528E-4C9C-8FF8-A486637C87E1
// Assembly location: O:\webview2\V1096133\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("EE9A0F68-F46C-4E32-AC23-EF8CAC224D2A")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2Settings2 : ICoreWebView2Settings
  {
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] 
        [return: MarshalAs(UnmanagedType.LPWStr)]
        string GetUserAgent();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] 
        void SetUserAgent([param: MarshalAs(UnmanagedType.LPWStr)] string value);
    }
}
