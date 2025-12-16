// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2CompositionController
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E8B0323-528E-4C9C-8FF8-A486637C87E1
// Assembly location: O:\webview2\V1096133\Diga.WebView2.Interop.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComConversionLoss]
    [Guid("3DF9B733-B9AE-4A15-86B4-EB9EE9826469")]
    [GeneratedComInterface]
    public partial interface ICoreWebView2CompositionController
    {
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        object GetRootVisualTarget();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]

        void SetRootVisualTarget([param: MarshalAs(UnmanagedType.Interface)] object value);
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SendMouseInput(
       COREWEBVIEW2_MOUSE_EVENT_KIND eventKind,
       COREWEBVIEW2_MOUSE_EVENT_VIRTUAL_KEYS virtualKeys,
       uint mouseData,
       POINT point);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SendPointerInput(
           COREWEBVIEW2_POINTER_EVENT_KIND eventKind,
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2PointerInfo pointerInfo);

        [DispId(1610678276)]
        IntPtr GetCursor();

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint GetSystemCursorId();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_CursorChanged(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2CursorChangedEventHandler eventHandler,
      out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_CursorChanged(EventRegistrationToken token);
    }
}
