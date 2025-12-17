// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2CompositionController3
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED88F383-EEB9-472A-9573-53250CD6B18B
// Assembly location: O:\webview2\Microsoft.Web.WebView2.1.0.1370.28\Diga.WebView2.Interop.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.Marshalling;
namespace Diga.WebView2.Interop
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("9570570E-4D76-4361-9EE1-F04D0DBDFB1E")]
    [GeneratedComInterface]
    public partial interface ICoreWebView2CompositionController3 : ICoreWebView2CompositionController2
    {

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint DragEnter([MarshalAs(UnmanagedType.Interface)] IDataObject dataObject, uint keyState, POINT point);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DragLeave();

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint DragOver(uint keyState, POINT point);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint Drop([MarshalAs(UnmanagedType.Interface)] IDataObject dataObject, uint keyState, POINT point);
    }
}
