// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2PermissionRequestedEventArgs3
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1241A3C3-E886-4508-B746-7F7141E4C294
// Assembly location: O:\webview2\microsoft.web.webview2.1.0.1722.45\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("E61670BC-3DCE-4177-86D2-C629AE3CB6AC")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2PermissionRequestedEventArgs3 : 
    ICoreWebView2PermissionRequestedEventArgs2
  {
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetSavesInProfile();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetSavesInProfile(int value);
    }
}
