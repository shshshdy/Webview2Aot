using CoreWindowsWrapper;
using CoreWindowsWrapper.Tools;
using CoreWindowsWrapper.Win32ApiForm;
using Diga.Core.Api.Win32;
using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper;
using Diga.WebView2.Wrapper.EventArguments;
using MimeTypeExtension;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Diga.NativeControls.WebBrowser
{
    public class NativeWebBrowser : NativeControlBase
    {
        public NativeWebBrowser()
        {

        }
        private readonly RpcHandler _RpcHandler = new RpcHandler();

        private NativeWindow _ParentNativeWindow = null;

        private WebView2Control _WebViewControl;

        private static int ControlCounter;

        private bool IsBrowserEnded = false;

        private string _Url;

        private ConcurrentQueue<ResponseInfo> _InfoCollection = new ConcurrentQueue<ResponseInfo>();

        private bool _UnWireExecuted;

        private bool IsCreated { get; set; }

        private bool CheckIsCreatedOrEnded
        {
            get
            {
                if (!IsCreated)
                {
                    return false;
                }
                if (IsBrowserEnded)
                {
                    return false;
                }
                return true;
            }
        }

        public string Url
        {
            get
            {
                return _Url;
            }
            set
            {
                _Url = value;
                if (CheckIsCreatedOrEnded)
                {
                    Navigate(value);
                }
            }
        }

        public bool Dock { get; set; } = true;
        public string MonitoringFolder { get; set; }
        /// <summary>
        /// 运行环境目录
        /// </summary>
        public string EnvFolder { get; set; } = string.Empty;

        public bool EnableMonitoring { get; set; }

        public string MonitoringUrl { get; set; }
        /// <summary>
        /// 用户缓存目录
        /// </summary>
        public string UserDataFolder { get; set; } = AppContext.BaseDirectory;

        public string BrowserVersion => _WebViewControl.BrowserInfo;

        public event EventHandler<NavigationStartingEventArgs> NavigationStart;

        public event EventHandler<ContentLoadingEventArgs> ContentLoading;

        public event EventHandler<SourceChangedEventArgs> SourceChanged;

        public event EventHandler<WebView2EventArgs> HistoryChanged;

        public event EventHandler<NavigationCompletedEventArgs> NavigationCompleted;

        public event EventHandler<WebResourceRequestedEventArgs> WebResourceRequested;

        public event EventHandler<AcceleratorKeyPressedEventArgs> AcceleratorKeyPressed;

        public event EventHandler<WebView2EventArgs> WebViewGotFocus;

        public event EventHandler<WebView2EventArgs> WebViewLostFocus;

        public event EventHandler<MoveFocusRequestedEventArgs> MoveFocusRequested;

        public event EventHandler<WebView2EventArgs> ZoomFactorChanged;

        public event EventHandler<WebView2EventArgs> DocumentTitleChanged;

        public event EventHandler<WebView2EventArgs> ContainsFullScreenElementChanged;

        public event EventHandler<NewWindowRequestedEventArgs> NewWindowRequested;

        public event EventHandler<PermissionRequestedEventArgs> PermissionRequested;

        public event EventHandler<NavigationCompletedEventArgs> FrameNavigationCompleted;

        public event EventHandler<NavigationStartingEventArgs> FrameNavigationStarting;

        public event EventHandler<ExecuteScriptCompletedEventArgs> ExecuteScriptCompleted;

        public event EventHandler<ProcessFailedEventArgs> ProcessFailed;

        public event EventHandler<ScriptDialogOpeningEventArgs> ScriptDialogOpening;

        public event EventHandler<WebMessageReceivedEventArgs> WebMessageReceived;

        public event EventHandler<AddScriptToExecuteOnDocumentCreatedCompletedEventArgs> ScriptToExecuteOnDocumentCreatedCompleted;

        public event EventHandler<EnvironmentCompletedHandlerArgs> BeforeEnvironmentCompleted;

        public event EventHandler<DownloadStartingEventArgs> DownloadStarting;

        public event EventHandler<FrameCreatedEventArgs> FrameCreated;

        public event EventHandler<WebView2EventArgs> RasterizationScaleChanged;

        public event EventHandler<RpcEventHandlerArgs> ScriptEvent;

        public event EventHandler<DOMContentLoadedEventArgs> DOMContentLoaded;

        public event EventHandler<WebResourceResponseReceivedEventArgs> WebResourceResponseReceived;

        public event EventHandler WebViewCreated;

        public event EventHandler BeforeWebViewDestroy;

        public event EventHandler<WebView2EventArgs> WindowCloseRequested;

        public event EventHandler<WebView2EventArgs> IsMutedChanged;

        public event EventHandler<WebView2EventArgs> IsDocumentPlayingAudioChanged;

        public event EventHandler<WebView2EventArgs> IsDefaultDownloadDialogOpenChanged;

        public event EventHandler DocumentLoading;

        public event EventHandler DocumentUnload;

        private event EventHandler<IExecuteScriptCompletedEventArgs> ExecuteScriptCompletedInterface;

        public event EventHandler<WebViewButtonDownEventArgs> MouseButtonDown;

        public event EventHandler<ContextMenuRequestedEventArgs> ContextMenuRequested;

        protected override void Initialize()
        {
            base.Initialize();
            base.ControlType = ControlType.Label;
            base.TypeIdentifier = "static";
            base.Style = 1342177536u;
            base.BackColor = ColorTool.White;
            base.ForeColor = ColorTool.Black;
           
        }

        private void CreateWebViewControl(IntPtr parent)
        {
            try
            {
                _RpcHandler.RpcEvent += OnRpcEventIntern;
                _RpcHandler.RpcDomUnloadEvent += OnRpcDomUnloadEvent;
                _WebViewControl = new WebView2Control(parent, EnvFolder, UserDataFolder, "");
                WireEvents(_WebViewControl);
            }
            catch (Exception ex)
            {
                Debug.Print("CreateWebViewControl", ex);
            }
        }

        private void WireEvents(WebView2Control control)
        {
            if (control != null)
            {
                control.Created += OnWebWindowCreated;
                control.BeforeCreate += OnWebWindowBeforeCreate;
                control.NavigateStart += OnNavigationStartIntern;
                control.AcceleratorKeyPressed += OnAcceleratorKeyPressedIntern;
                control.GotFocus += OnGotFocusIntern;
                control.LostFocus += OnLostFocusIntern;
                control.MoveFocusRequested += OnMoveFocusRequestedIntern;
                control.ZoomFactorChanged += OnZoomFactorChangedIntern;
                control.ContainsFullScreenElementChanged += OnContainsFullScreenElementChangedIntern;
                control.NewWindowRequested += OnNewWindowRequestedIntern;
                control.PermissionRequested += OnPermissionRequestedIntern;
                control.DocumentTitleChanged += OnDocumentTitleChangedIntern;
                control.FrameNavigationCompleted += OnFrameNavigationCompletedIntern;
                control.FrameNavigationStarting += OnFrameNavigationStartingIntern;
                control.ProcessFailed += OnProcessFailedIntern;
                control.ScriptDialogOpening += OnScriptDialogOpeningIntern;
                control.WebMessageReceived += OnWebMessageReceivedIntern;
                control.ScriptToExecuteOnDocumentCreatedCompleted += ScriptToExecuteOnDocumentCreatedCompletedIntern;
                control.WindowCloseRequested += OnWindowCloseRequestedIntern;
                control.ExecuteScriptCompleted += OnExecuteScriptCompletedIntern;
                control.WebResourceRequested += OnWebResourceRequestedIntern;
                control.ContentLoading += OnContentLoadingIntern;
                control.SourceChanged += OnSourceChangedIntern;
                control.HistoryChanged += OnHistoryChangedIntern;
                control.NavigationCompleted += OnNavigationCompletedIntern;
                control.NewBrowserVersionAvailable += OnNewBrowserVersionAvailableIntern;
                control.DOMContentLoaded += OnDOMContentLoadedIntern;
                control.WebResourceResponseReceived += WebResourceResponseReceivedIntern;
                control.DownloadStarting += OnDownalodStartingIntern;
                control.FrameCreated += OnFrameCreatedIntern;
                control.RasterizationScaleChanged += OnRasterizationScaleChangedIntern;
                control.IsMutedChanged += OnIsMutedChangedIntern;
                control.IsDocumentPlayingAudioChanged += OnIsDocumentPlayingAudioChangedIntern;
                control.IsDefaultDownloadDialogOpenChanged += OnIsDefaultDownloadDialogOpenChangedIntern;
                control.ContextMenuRequested += OnContextMenuRequestedIntern;
            }
        }

        private void OnNavigationCompleted(object sender, NavigationCompletedEventArgs e)
        {
            Debug.Print("OnNavigationCompleted:" + e.IsSuccess);
        }

        private void OnWebWindowCreated(object sender, EventArgs e)
        {
            WebWindowInitAction();
            DoDock();
            if (NativeWindow.TryGetWindow(base.ParentHandle, out var wnd))
            {
                _ParentNativeWindow = wnd;
                _ParentNativeWindow.Size += OnParentSize;
            }
            OnWebViewCreated();

            TopChanged += (s, e) => DoDock();
            LeftChanged += (s, e) => DoDock();
            WidthChanged += (s, e) => DoDock();
            HeightChanged += (s, e) => DoDock();
        }

        public void Navigate(string url)
        {
            _Url = url;
            if (CheckIsCreatedOrEnded && !string.IsNullOrEmpty(Url))
            {
                try
                {
                    _WebViewControl.Navigate(_Url);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(base.Handle, ex.Message, "Navigation Error!", MessageBoxOptions.IconHand);
                }
            }
        }

        private void WebWindowInitAction()
        {
            IsCreated = true;
            if (!string.IsNullOrEmpty(_Url))
            {
                Navigate(Url);
            }
        }

        private void OnParentSize(object sender, SizeEventArgs e)
        {
            DoDock();
        }

        public override bool Create(IntPtr parentId)
        {
            bool result = base.Create(parentId);
            if (base.Handle != IntPtr.Zero)
            {
                CreateWebViewControl(base.Handle);
                return result;
            }
            throw new Exception("Cannot create WebView");
        }

        public void DoDock()
        {
            var rect = new Rect { Left = Left, Top = Top, Height = Height, Width = Width };

            if (NativeWindow.TryGetWindow(base.ParentHandle, out var wnd))
            {
                Rect clientRect = Dock ? wnd.GetClientRect() : rect;
                User32.MoveWindow(base.Handle, clientRect.Left, clientRect.Top, clientRect.Width, clientRect.Height, bRepaint: true);
            }
            else if (User32.GetClientRect(base.ParentHandle, out Rect lpRect))
            {
                if (Dock)
                    lpRect = rect;
                User32.MoveWindow(base.Handle, lpRect.Left, lpRect.Top, lpRect.Width, lpRect.Height, bRepaint: true);
            }
            _WebViewControl.DockToParent();
        }

        protected virtual void OnWebResourceRequested(WebResourceRequestedEventArgs e)
        {
            using (e.GetDeferral())
            {
                CheckMonitoring(e);
                this.WebResourceRequested?.Invoke(this, e);
            }
        }

        private void CheckMonitoring(WebResourceRequestedEventArgs e)
        {
            string uri = e.Request.Uri;
            if (IsMonitoringUrl(uri))
            {
                RequestInfo requestInfo = new RequestInfo(e.Request);
                if (GetMonitoringFile(requestInfo, out var responseInfo))
                {
                    WebResourceResponse webResourceResponse2 = (e.Response = CreateResponse(responseInfo));
                    _InfoCollection.Enqueue(responseInfo);
                }
            }
        }

        public WebResourceResponse CreateResponse(ResponseInfo responseInfo)
        {
            WebResourceResponse result = null;
            if (CheckIsCreatedOrEnded)
            {
                result = _WebViewControl.GetResponseStream(responseInfo.Stream, responseInfo.StatusCode, responseInfo.StatusText, responseInfo.HeaderToString(), responseInfo.ContentType);
            }
            return result;
        }

        private bool MonitoringFileExist(string file)
        {
            if (file.StartsWith("/"))
            {
                file = file.Substring(1);
            }
            file = file.Replace("/", "\\");
            string path = Path.Combine(MonitoringFolder, file);
            return File.Exists(path);
        }

        private bool GetMonitoringFile(RequestInfo requestInfo, out ResponseInfo responseInfo)
        {
            string uri = requestInfo.Uri;
            if (!uri.StartsWith(MonitoringUrl))
            {
                responseInfo = null;
                return false;
            }
            Uri uri2 = new Uri(uri);
            string monitoringFolder = MonitoringFolder;
            string text = (MonitoringFileExist(uri2.AbsolutePath) ? uri2.AbsolutePath : "");
            if (text == "/")
            {
                text = "";
            }
            if (text.StartsWith("/"))
            {
                text = text.Substring(1);
            }
            if (string.IsNullOrEmpty(text))
            {
                text = "index.html";
            }
            text = text.Replace("/", "\\");
            text = Path.Combine(monitoringFolder, text);
            FileInfo fileInfo = new FileInfo(text);
            if (!fileInfo.Exists)
            {
                responseInfo = new ResponseInfo("<h1>Server Error</h1><h5>file not found:" + text + "</h5>");
                responseInfo.Header.Add("content-type", "text/html; charset=utf-8");
                responseInfo.ContentType = "content-type: text/html; charset=utf-8";
                responseInfo.StatusCode = 404;
                responseInfo.StatusText = "Not Found";
                return true;
            }
            string text2 = fileInfo.MimeTypeOrDefault();
            if (text2 == "document")
            {
                Debug.Print(text2);
            }
            try
            {
                byte[] bytes = File.ReadAllBytes(text);
                responseInfo = new ResponseInfo(bytes);
                string utf8IfNeeded = GetUtf8IfNeeded(text2);
                responseInfo.Header.Add("content-type", text2 + utf8IfNeeded);
                responseInfo.ContentType = "content-type: " + text2 + utf8IfNeeded;
                responseInfo.StatusCode = 200;
                responseInfo.StatusText = "OK";
                return true;
            }
            catch (Exception ex)
            {
                string content = "Error:" + ex.Message;
                responseInfo = new ResponseInfo(content);
                responseInfo.Header.Add("content-type", "text/html; charset=utf-8");
                responseInfo.ContentType = "content-type; charset=utf-8";
                responseInfo.StatusCode = 500;
                responseInfo.StatusText = "Internal Server Error";
                return true;
            }
        }

        private static string GetUtf8IfNeeded(string contentType)
        {
            if (string.IsNullOrEmpty(contentType))
            {
                return "";
            }
            bool flag = false;
            switch (contentType)
            {
                case "application/x-javascript":
                case "text/html":
                case "text/css":
                case "application/javascript":
                case "application/json":
                    flag = true;
                    break;
            }
            if (flag)
            {
                return "; charset=utf-8";
            }
            return "";
        }

        private bool IsMonitoringUrl(string url)
        {
            if (!EnableMonitoring)
            {
                return false;
            }
            if (string.IsNullOrEmpty(url))
            {
                return false;
            }
            if (url.StartsWith(MonitoringUrl))
            {
                return true;
            }
            return false;
        }

        private void WebWindowInitSettings(BeforeCreateEventArgs e)
        {
            e.Settings.AreBrowserAcceleratorKeysEnabled = true;
            e.Settings.AreDefaultContextMenusEnabled = true;
            e.Settings.AreDefaultScriptDialogsEnabled = true;
            e.Settings.AreDevToolsEnabled = true;
            e.Settings.AreHostObjectsAllowed = true;
            e.Settings.IsGeneralAutofillEnabled = true;
            e.Settings.IsPasswordAutosaveEnabled = true;
            e.Settings.IsScriptEnabled = true;
            e.Settings.IsStatusBarEnabled = true;
            e.Settings.IsWebMessageEnabled = true;
            e.Settings.IsZoomControlEnabled = true;
            e.Settings.IsBuiltInErrorPageEnabled = true;
            e.Settings.IsPinchZoomEnabled = true;
        }

        private void OnWebWindowBeforeCreate(object sender, BeforeCreateEventArgs e)
        {
            WebWindowInitSettings(e);
        }

        protected virtual void OnNavigationStart(NavigationStartingEventArgs e)
        {
            this.NavigationStart?.Invoke(this, e);
        }

        protected virtual void OnContentLoading(ContentLoadingEventArgs e)
        {
            this.ContentLoading?.Invoke(this, e);
        }

        protected virtual void OnSourceChanged(SourceChangedEventArgs e)
        {
            this.SourceChanged?.Invoke(this, e);
        }

        protected virtual void OnHistoryChanged(WebView2EventArgs e)
        {
            this.HistoryChanged?.Invoke(this, e);
        }

        protected virtual void OnNavigationCompleted(NavigationCompletedEventArgs e)
        {
            try
            {
                if (_InfoCollection.Count > 1)
                {
                    ResponseInfo result;
                    while (_InfoCollection.TryDequeue(out result))
                    {
                        result.Dispose();
                        if (_InfoCollection.Count <= 1)
                        {
                            break;
                        }
                        Debug.Print("More to delete!");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print("OnWebResourceResponseReceived ResponseInfo.Dispoase error:" + ex.Message);
            }
            this.NavigationCompleted?.Invoke(this, e);
        }

        protected virtual void OnAcceleratorKeyPressed(AcceleratorKeyPressedEventArgs e)
        {
            this.AcceleratorKeyPressed?.Invoke(this, e);
        }

        protected virtual void OnContainsFullScreenElementChanged(WebView2EventArgs e)
        {
            this.ContainsFullScreenElementChanged?.Invoke(this, e);
        }

        protected virtual void OnDocumentTitleChanged(WebView2EventArgs e)
        {
            this.DocumentTitleChanged?.Invoke(this, e);
        }

        protected virtual void OnFrameNavigationStarting(NavigationStartingEventArgs e)
        {
            this.FrameNavigationStarting?.Invoke(this, e);
        }

        protected virtual void OnScriptDialogOpening(ScriptDialogOpeningEventArgs e)
        {
            this.ScriptDialogOpening?.Invoke(this, e);
        }

        protected virtual void OnWindowCloseRequested(WebView2EventArgs e)
        {
            this.WindowCloseRequested?.Invoke(this, e);
        }

        protected virtual void OnScriptToExecuteOnDocumentCreatedCompleted(AddScriptToExecuteOnDocumentCreatedCompletedEventArgs e)
        {
            this.ScriptToExecuteOnDocumentCreatedCompleted?.Invoke(this, e);
        }

        protected virtual void OnWebMessageReceived(WebMessageReceivedEventArgs e)
        {
            this.WebMessageReceived?.Invoke(this, e);
        }

        protected virtual void OnProcessFailed(ProcessFailedEventArgs e)
        {
            this.ProcessFailed?.Invoke(this, e);
        }

        protected virtual void OnExecuteScriptCompleted(ExecuteScriptCompletedEventArgs e)
        {
            try
            {
                this.ExecuteScriptCompletedInterface?.Invoke(this, e);
            }
            catch (Exception ex)
            {
                Debug.Print("ExecuteScriptCompleted Exception:" + ex.ToString());
            }
            this.ExecuteScriptCompleted?.Invoke(this, e);
        }

        protected virtual void OnNewWindowRequested(NewWindowRequestedEventArgs e)
        {
            this.NewWindowRequested?.Invoke(this, e);
        }

        protected virtual void OnPermissionRequested(PermissionRequestedEventArgs e)
        {
            this.PermissionRequested?.Invoke(this, e);
        }

        protected virtual void OnZoomFactorChanged(WebView2EventArgs e)
        {
            this.ZoomFactorChanged?.Invoke(this, e);
        }

        protected virtual void OnWebViewGotFocus(WebView2EventArgs e)
        {
            this.WebViewGotFocus?.Invoke(this, e);
        }

        protected virtual void OnWebViewLostFocus(WebView2EventArgs e)
        {
            this.WebViewLostFocus?.Invoke(this, e);
        }

        protected virtual void OnMoveFocusRequested(MoveFocusRequestedEventArgs e)
        {
            this.MoveFocusRequested?.Invoke(this, e);
        }

        protected virtual void OnWebViewCreated()
        {
            this.WebViewCreated?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnFrameNavigationCompleted(NavigationCompletedEventArgs e)
        {
            this.FrameNavigationCompleted?.Invoke(this, e);
        }

        private static void BeforeProcessExitCatch(object sender, EventArgs e)
        {
            Debug.Print("BeforeProcessExitCatch");
        }

        protected virtual void OnDocumentLoading()
        {
            this.DocumentLoading?.Invoke(this, EventArgs.Empty);
        }

        private void OnDomEvent(object sender, RpcEventHandlerArgs e)
        {
            string eventName = e.EventName;
            string text = eventName;
            if (text == "error")
            {
                Debug.Print("Error");
            }
        }

        protected virtual void OnDomContentLoaded(DOMContentLoadedEventArgs e)
        {
            this.DOMContentLoaded?.Invoke(this, e);
        }

        protected virtual void OnWebResourceResponseReceived(WebResourceResponseReceivedEventArgs e)
        {
            this.WebResourceResponseReceived?.Invoke(this, e);
        }

        protected virtual void OnBeforeEnvironmentCompleted(EnvironmentCompletedHandlerArgs e)
        {
            this.BeforeEnvironmentCompleted?.Invoke(this, e);
        }

        protected virtual void OnDownloadStarting(DownloadStartingEventArgs e)
        {
            this.DownloadStarting?.Invoke(this, e);
        }

        protected virtual void OnFrameCreated(FrameCreatedEventArgs e)
        {
            this.FrameCreated?.Invoke(this, e);
        }

        protected virtual void OnRasterizationScaleChanged(WebView2EventArgs e)
        {
            this.RasterizationScaleChanged?.Invoke(this, e);
        }

        protected virtual void OnScriptEvent(RpcEventHandlerArgs e)
        {
            this.ScriptEvent?.Invoke(this, e);
        }

        private void OnRpcEventIntern(object sender, RpcEventHandlerArgs e)
        {
            OnScriptEvent(e);
        }

        protected virtual void OnDocumentUnload()
        {
            Task.Run(delegate
            {
                this.DocumentUnload?.Invoke(this, EventArgs.Empty);
            });
        }

        private void OnRpcDomUnloadEvent(object sender, EventArgs e)
        {
            OnDocumentUnload();
        }

        private void OnRasterizationScaleChangedIntern(object sender, WebView2EventArgs e)
        {
            OnRasterizationScaleChanged(e);
        }

        private void OnFrameCreatedIntern(object sender, FrameCreatedEventArgs e)
        {
            OnFrameCreated(e);
        }

        private void OnDownalodStartingIntern(object sender, DownloadStartingEventArgs e)
        {
            OnDownloadStarting(e);
        }

        private void WebResourceResponseReceivedIntern(object sender, WebResourceResponseReceivedEventArgs e)
        {
            OnWebResourceResponseReceived(e);
        }

        private void OnDOMContentLoadedIntern(object sender, DOMContentLoadedEventArgs e)
        {
            OnDomContentLoaded(e);
        }

        private void OnNewBrowserVersionAvailableIntern(object sender, WebView2EventArgs e)
        {
        }

        private void OnFrameNavigationCompletedIntern(object sender, NavigationCompletedEventArgs e)
        {
            OnFrameNavigationCompleted(e);
        }

        private void OnMoveFocusRequestedIntern(object sender, MoveFocusRequestedEventArgs e)
        {
            OnMoveFocusRequested(e);
        }

        private void OnLostFocusIntern(object sender, WebView2EventArgs e)
        {
            OnWebViewLostFocus(e);
        }

        private void OnGotFocusIntern(object sender, WebView2EventArgs e)
        {
            OnWebViewGotFocus(e);
        }

        private void OnZoomFactorChangedIntern(object sender, WebView2EventArgs e)
        {
            OnZoomFactorChanged(e);
        }

        private void OnPermissionRequestedIntern(object sender, PermissionRequestedEventArgs e)
        {
            OnPermissionRequested(e);
        }

        private void OnNewWindowRequestedIntern(object sender, NewWindowRequestedEventArgs e)
        {
            OnNewWindowRequested(e);
        }

        private void OnExecuteScriptCompletedIntern(object sender, ExecuteScriptCompletedEventArgs e)
        {
            OnExecuteScriptCompleted(e);
        }

        private void OnWebMessageReceivedIntern(object sender, WebMessageReceivedEventArgs e)
        {
            OnWebMessageReceived(e);
        }

        private void ScriptToExecuteOnDocumentCreatedCompletedIntern(object sender, AddScriptToExecuteOnDocumentCreatedCompletedEventArgs e)
        {
            OnScriptToExecuteOnDocumentCreatedCompleted(e);
        }

        private void OnWindowCloseRequestedIntern(object sender, WebView2EventArgs e)
        {
            OnWindowCloseRequested(e);
        }

        private void OnScriptDialogOpeningIntern(object sender, ScriptDialogOpeningEventArgs e)
        {
            OnScriptDialogOpening(e);
        }

        private void OnProcessFailedIntern(object sender, ProcessFailedEventArgs e)
        {
            if (e.ProcessFailedKind == COREWEBVIEW2_PROCESS_FAILED_KIND.COREWEBVIEW2_PROCESS_FAILED_KIND_BROWSER_PROCESS_EXITED)
            {
                IsBrowserEnded = true;
            }
            OnProcessFailed(e);
        }

        private void OnFrameNavigationStartingIntern(object sender, NavigationStartingEventArgs e)
        {
            OnFrameNavigationStarting(e);
        }

        private void OnDocumentTitleChangedIntern(object sender, WebView2EventArgs e)
        {
            OnDocumentTitleChanged(e);
        }

        private void OnContainsFullScreenElementChangedIntern(object sender, WebView2EventArgs e)
        {
            OnContainsFullScreenElementChanged(e);
        }

        private void OnAcceleratorKeyPressedIntern(object sender, AcceleratorKeyPressedEventArgs e)
        {
            OnAcceleratorKeyPressed(e);
        }

        private void OnWebResourceRequestedIntern(object sender, WebResourceRequestedEventArgs e)
        {
            OnWebResourceRequested(e);
        }

        private void OnNavigationCompletedIntern(object sender, NavigationCompletedEventArgs e)
        {
            OnNavigationCompleted(e);
        }

        private void OnHistoryChangedIntern(object sender, WebView2EventArgs e)
        {
            OnHistoryChanged(e);
        }

        private void OnSourceChangedIntern(object sender, SourceChangedEventArgs e)
        {
            OnSourceChanged(e);
        }

        private void OnContentLoadingIntern(object sender, ContentLoadingEventArgs e)
        {
            OnContentLoading(e);
        }

        private void OnNavigationStartIntern(object sender, NavigationStartingEventArgs e)
        {
            OnNavigationStart(e);
        }

        private void OnIsMutedChangedIntern(object sender, WebView2EventArgs e)
        {
            OnIsMutedChanged(e);
        }

        protected virtual void OnIsMutedChanged(WebView2EventArgs e)
        {
            this.IsMutedChanged?.Invoke(this, e);
        }

        protected virtual void OnIsDocumentPlayingAudioChanged(WebView2EventArgs e)
        {
            this.IsDocumentPlayingAudioChanged?.Invoke(this, e);
        }

        protected virtual void OnIsDefaultDownloadDialogOpenChanged(WebView2EventArgs e)
        {
            this.IsDefaultDownloadDialogOpenChanged?.Invoke(this, e);
        }

        private void OnIsDocumentPlayingAudioChangedIntern(object sender, WebView2EventArgs e)
        {
            OnIsDocumentPlayingAudioChanged(e);
        }

        private void OnIsDefaultDownloadDialogOpenChangedIntern(object sender, WebView2EventArgs e)
        {
            OnIsDefaultDownloadDialogOpenChanged(e);
        }

        private void OnContextMenuRequestedIntern(object sender, ContextMenuRequestedEventArgs e)
        {
            OnContextMenuRequested(e);
        }

        protected virtual void OnContextMenuRequested(ContextMenuRequestedEventArgs e)
        {
            this.ContextMenuRequested?.Invoke(this, e);
        }


        private void BeforeDisposeWebView()
        {
            this.BeforeWebViewDestroy?.Invoke(this, EventArgs.Empty);
            UnWireEvents(_WebViewControl);
        }

        private void UnWireEvents(WebView2Control control)
        {
            if (!_UnWireExecuted && control != null)
            {
                control.Created -= OnWebWindowCreated;
                control.BeforeCreate -= OnWebWindowBeforeCreate;
                control.NavigateStart -= OnNavigationStartIntern;
                control.AcceleratorKeyPressed -= OnAcceleratorKeyPressedIntern;
                control.GotFocus -= OnGotFocusIntern;
                control.LostFocus -= OnLostFocusIntern;
                control.MoveFocusRequested -= OnMoveFocusRequestedIntern;
                control.ZoomFactorChanged -= OnZoomFactorChangedIntern;
                control.ContainsFullScreenElementChanged -= OnContainsFullScreenElementChangedIntern;
                control.NewWindowRequested -= OnNewWindowRequestedIntern;
                control.PermissionRequested -= OnPermissionRequestedIntern;
                control.DocumentTitleChanged -= OnDocumentTitleChangedIntern;
                control.FrameNavigationCompleted -= OnFrameNavigationCompletedIntern;
                control.FrameNavigationStarting -= OnFrameNavigationStartingIntern;
                control.ProcessFailed -= OnProcessFailedIntern;
                control.ScriptDialogOpening -= OnScriptDialogOpeningIntern;
                control.WebMessageReceived -= OnWebMessageReceivedIntern;
                control.ScriptToExecuteOnDocumentCreatedCompleted -= ScriptToExecuteOnDocumentCreatedCompletedIntern;
                control.WindowCloseRequested -= OnWindowCloseRequestedIntern;
                control.ExecuteScriptCompleted -= OnExecuteScriptCompletedIntern;
                control.WebResourceRequested -= OnWebResourceRequestedIntern;
                control.ContentLoading -= OnContentLoadingIntern;
                control.SourceChanged -= OnSourceChangedIntern;
                control.HistoryChanged -= OnHistoryChangedIntern;
                control.NavigationCompleted -= OnNavigationCompletedIntern;
                control.NewBrowserVersionAvailable -= OnNewBrowserVersionAvailableIntern;
                control.DOMContentLoaded -= OnDOMContentLoadedIntern;
                control.WebResourceResponseReceived -= WebResourceResponseReceivedIntern;
                control.DownloadStarting -= OnDownalodStartingIntern;
                control.FrameCreated -= OnFrameCreatedIntern;
                control.RasterizationScaleChanged -= OnRasterizationScaleChangedIntern;
                control.IsMutedChanged -= OnIsMutedChangedIntern;
                control.IsDocumentPlayingAudioChanged -= OnIsDocumentPlayingAudioChangedIntern;
                control.IsDefaultDownloadDialogOpenChanged -= OnIsDefaultDownloadDialogOpenChangedIntern;
                control.ContextMenuRequested -= OnContextMenuRequestedIntern;
                _UnWireExecuted = true;
            }
        }

        public WebView2SharedBuffer CreateSharedBuffer(ulong size)
        {
            if (CheckIsCreatedOrEnded)
            {
                return _WebViewControl.CreateSharedBuffer(size);
            }
            return null;
        }

        public void PostSharedBufferToScript(WebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson)
        {
            if (CheckIsCreatedOrEnded)
            {
                _WebViewControl.PostSharedBufferToScript(sharedBuffer, access, additionalDataAsJson);
            }
        }
    }
}
