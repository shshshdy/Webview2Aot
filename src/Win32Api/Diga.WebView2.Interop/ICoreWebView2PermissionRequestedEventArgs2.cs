// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2PermissionRequestedEventArgs2
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EA95D0FC-77DE-40CE-8C3C-89517DF28E5B
// Assembly location: O:\webview2\V10118539\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("74D7127F-9DE6-4200-8734-42D6FB4FF741")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2PermissionRequestedEventArgs2 : 
    ICoreWebView2PermissionRequestedEventArgs
  {
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetHandled();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetHandled(int value);
    }
}
