// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2_8
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03E6B0A7-E6B7-472F-A8B3-541AB2D8627C
// Assembly location: O:\webview2\V10107254\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("E9632730-6E1E-43AB-B7B8-7B2C9E62E094")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2_8 : ICoreWebView2_7
  {
    
    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void add_IsMutedChanged(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2IsMutedChangedEventHandler eventHandler,
      out EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void remove_IsMutedChanged( EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetIsMuted();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetIsMuted(int value);
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void add_IsDocumentPlayingAudioChanged(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler,
      out EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void remove_IsDocumentPlayingAudioChanged( EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetIsDocumentPlayingAudio();
    }
}
