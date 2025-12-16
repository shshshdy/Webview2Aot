// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2NewWindowRequestedEventArgs2
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 78A35386-8488-46E1-BA73-85C815D94A35
// Assembly location: O:\webview2\V1099228\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("BBC7BAED-74C6-4C92-B63A-7F5AEAE03DE3")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2NewWindowRequestedEventArgs2 : 
    ICoreWebView2NewWindowRequestedEventArgs
  {
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] 
        [return: MarshalAs(UnmanagedType.LPWStr)]
        string Getname();
    }
}
