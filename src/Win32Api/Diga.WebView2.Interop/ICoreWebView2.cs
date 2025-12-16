// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E8B0323-528E-4C9C-8FF8-A486637C87E1
// Assembly location: O:\webview2\V1096133\Diga.WebView2.Interop.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace Diga.WebView2.Interop
{
    [Guid("76ECEACB-0462-4D94-AC83-423A6793775E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface ICoreWebView2
    {
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICoreWebView2Settings GetSettings();

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        string GetSource();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Navigate([MarshalAs(UnmanagedType.LPWStr)] string uri);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NavigateToString([MarshalAs(UnmanagedType.LPWStr)] string htmlContent);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_NavigationStarting(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2NavigationStartingEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_NavigationStarting(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_ContentLoading(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2ContentLoadingEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_ContentLoading(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_SourceChanged(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2SourceChangedEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_SourceChanged(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_HistoryChanged(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2HistoryChangedEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_HistoryChanged(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_NavigationCompleted(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2NavigationCompletedEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_NavigationCompleted(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_FrameNavigationStarting(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2NavigationStartingEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_FrameNavigationStarting(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_FrameNavigationCompleted(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2NavigationCompletedEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_FrameNavigationCompleted(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_ScriptDialogOpening(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2ScriptDialogOpeningEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_ScriptDialogOpening(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_PermissionRequested(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2PermissionRequestedEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_PermissionRequested(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_ProcessFailed(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2ProcessFailedEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_ProcessFailed(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void AddScriptToExecuteOnDocumentCreated(
          [MarshalAs(UnmanagedType.LPWStr)] string javaScript,
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RemoveScriptToExecuteOnDocumentCreated([MarshalAs(UnmanagedType.LPWStr)] string id);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ExecuteScript([MarshalAs(UnmanagedType.LPWStr)] string javaScript, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2ExecuteScriptCompletedHandler handler);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CapturePreview(
           COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat,
          [MarshalAs(UnmanagedType.Interface)] IStream imageStream,
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2CapturePreviewCompletedHandler handler);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Reload();

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void PostWebMessageAsJson([MarshalAs(UnmanagedType.LPWStr)] string webMessageAsJson);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void PostWebMessageAsString([MarshalAs(UnmanagedType.LPWStr)] string webMessageAsString);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_WebMessageReceived(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2WebMessageReceivedEventHandler handler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_WebMessageReceived(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CallDevToolsProtocolMethod(
          [MarshalAs(UnmanagedType.LPWStr)] string methodName,
          [MarshalAs(UnmanagedType.LPWStr)] string parametersAsJson,
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint GetBrowserProcessId();

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetCanGoBack();

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetCanGoForward();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GoBack();

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GoForward();

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICoreWebView2DevToolsProtocolEventReceiver GetDevToolsProtocolEventReceiver(
          [MarshalAs(UnmanagedType.LPWStr)] string eventName);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Stop();

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_NewWindowRequested(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2NewWindowRequestedEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_NewWindowRequested(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_DocumentTitleChanged(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2DocumentTitleChangedEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_DocumentTitleChanged(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        string GetDocumentTitle();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        //void AddHostObjectToScript([MarshalAs(UnmanagedType.LPWStr)] string name, [In][MarshalAs(UnmanagedType.Interface)] ref object @object);
        //void AddHostObjectToScript([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.Interface)] ref object @object);
        void AddHostObjectToScript([MarshalAs(UnmanagedType.LPWStr)] string name, nint @object);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RemoveHostObjectFromScript([MarshalAs(UnmanagedType.LPWStr)] string name);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void OpenDevToolsWindow();

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_ContainsFullScreenElementChanged(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_ContainsFullScreenElementChanged(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetContainsFullScreenElement();
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_WebResourceRequested(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2WebResourceRequestedEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_WebResourceRequested(EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void AddWebResourceRequestedFilter(
          [MarshalAs(UnmanagedType.LPWStr)] string uri,
           COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RemoveWebResourceRequestedFilter(
          [MarshalAs(UnmanagedType.LPWStr)] string uri,
           COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_WindowCloseRequested(
          [MarshalAs(UnmanagedType.Interface)] ICoreWebView2WindowCloseRequestedEventHandler eventHandler,
          out EventRegistrationToken token);

        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_WindowCloseRequested(EventRegistrationToken token);
    }
}
