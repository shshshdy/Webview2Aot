// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2WebResourceResponseReceivedEventArgs
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E8B0323-528E-4C9C-8FF8-A486637C87E1
// Assembly location: O:\webview2\V1096133\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("D1DB483D-6796-4B8B-80FC-13712BB716F4")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2WebResourceResponseReceivedEventArgs
  {
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] 
        [return: MarshalAs(UnmanagedType.Interface)]
        ICoreWebView2WebResourceRequest GetRequest();

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] 
        [return: MarshalAs(UnmanagedType.Interface)]
        ICoreWebView2WebResourceResponseView GetResponse();
    }
}
