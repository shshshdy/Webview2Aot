// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2_9
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03E6B0A7-E6B7-472F-A8B3-541AB2D8627C
// Assembly location: O:\webview2\V10107254\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("4D7B2EAB-9FDC-468D-B998-A9260B5ED651")]
  [GeneratedComInterface]
  public partial interface ICoreWebView2_9 : ICoreWebView2_8
  {

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void add_IsDefaultDownloadDialogOpenChanged(
      [MarshalAs(UnmanagedType.Interface)] ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler,
      out EventRegistrationToken token);

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void remove_IsDefaultDownloadDialogOpenChanged( EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetIsDefaultDownloadDialogOpen();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void OpenDefaultDownloadDialog();

    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void CloseDefaultDownloadDialog();

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT GetDefaultDownloadDialogCornerAlignment();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetDefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        POINT GetDefaultDownloadDialogMargin();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetDefaultDownloadDialogMargin(POINT value);
    }
}
