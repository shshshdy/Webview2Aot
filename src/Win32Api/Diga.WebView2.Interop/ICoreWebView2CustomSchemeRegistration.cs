// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2CustomSchemeRegistration
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2BA7B24E-98CF-4C8D-98F5-352A5D059C6B
// Assembly location: O:\webview2\microsoft.web.webview2.1.0.1587.40\Diga.WebView2.Interop.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D60AC92C-37A6-4B26-A39E-95CFE59047BB")]
    [ComConversionLoss]
    [GeneratedComInterface]
    public partial interface ICoreWebView2CustomSchemeRegistration
    {
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        string GetSchemeName();

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetTreatAsSecure();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetTreatAsSecure(int value);
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetAllowedOrigins(out uint allowedOriginsCount, IntPtr allowedOrigins);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetAllowedOrigins(uint allowedOriginsCount, [MarshalAs(UnmanagedType.LPWStr)] ref string allowedOrigins);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetHasAuthorityComponent();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetHasAuthorityComponent(int value);
    }
}
