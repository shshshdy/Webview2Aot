// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2_3
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E8B0323-528E-4C9C-8FF8-A486637C87E1
// Assembly location: O:\webview2\V1096133\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
    [Guid("A0D6DF20-3B92-416D-AA0C-437A9C727857")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface ICoreWebView2_3 : ICoreWebView2_2
    {

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void TrySuspend([MarshalAs(UnmanagedType.Interface)] ICoreWebView2TrySuspendCompletedHandler handler);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Resume();

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetIsSuspended();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetVirtualHostNameToFolderMapping(
          [MarshalAs(UnmanagedType.LPWStr)] string hostName,
          [MarshalAs(UnmanagedType.LPWStr)] string folderPath,
           COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ClearVirtualHostNameToFolderMapping([MarshalAs(UnmanagedType.LPWStr)] string hostName);
    }
}
