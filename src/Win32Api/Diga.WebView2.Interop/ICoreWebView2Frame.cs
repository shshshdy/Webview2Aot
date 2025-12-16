// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2Frame
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E8B0323-528E-4C9C-8FF8-A486637C87E1
// Assembly location: O:\webview2\V1096133\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
namespace Diga.WebView2.Interop
{
    [Guid("F1131A5E-9BA9-11EB-A8B3-0242AC130003")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface ICoreWebView2Frame
    {
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        string Getname();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_NameChanged(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2FrameNameChangedEventHandler eventHandler,
      out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_NameChanged(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void AddHostObjectToScriptWithOrigins([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.Interface)] object @object, uint originsCount, [MarshalAs(UnmanagedType.LPWStr)] string origins);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RemoveHostObjectFromScript([MarshalAs(UnmanagedType.LPWStr)] string name);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_Destroyed(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2FrameDestroyedEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_Destroyed(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int IsDestroyed();
    }
}
