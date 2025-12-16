using CoreWindowsWrapper;
using Diga.Core.Api.Win32;
using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper;
using Diga.WebView2.Wrapper.EventArguments;
using MimeTypeExtension;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Diga.NativeControls.WebBrowser
{
    //public class RpcEventHandlerArgs : EventArgs
    //{
    //    public IRpcObject RpcObject { get; }
    //    public string EventName { get; }
    //    public string ObjectId { get; }

    //    public RpcEventHandlerArgs(string id, string eventName, IRpcObject rpc)
    //    {
    //        this.ObjectId = id;
    //        this.EventName = eventName;
    //        this.RpcObject = rpc;
    //    }
    //}

    public class NativeWebBrowser : NativeControlBase
    {
        private readonly RpcHandler _RpcHandler = new RpcHandler();
        private NativeWindow _ParentNativeWindow = null;
        private WebView2Control _WebViewControl;
        //private static int ControlCounter = 0;
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
        public event EventHandler<AddScriptToExecuteOnDocumentCreatedCompletedEventArgs>
            ScriptToExecuteOnDocumentCreatedCompleted;
        public event EventHandler<EnvironmentCompletedHandlerArgs> BeforeEnvironmentCompleted;
        public event EventHandler<DownloadStartingEventArgs> DownloadStarting;
        public event EventHandler<FrameCreatedEventArgs> FrameCreated;
        public event EventHandler<WebView2EventArgs> RasterizationScaleChanged;
        public event EventHandler<RpcEventHandlerArgs> ScriptEvent;
        public event EventHandler<DOMContentLoadedEventArgs> DOMContentLoaded;
        public event EventHandler<WebResourceResponseReceivedEventArgs> WebResourceResponseReceived;
        //private Action _CleanUp;
        public event EventHandler WebViewCreated;

        public event EventHandler BeforeWebViewDestroy;

        public event EventHandler<WebView2EventArgs> WindowCloseRequested;
        public event EventHandler<WebView2EventArgs> IsMutedChanged;
        public event EventHandler<WebView2EventArgs> IsDocumentPlayingAudioChanged;
        public event EventHandler<WebView2EventArgs> IsDefaultDownloadDialogOpenChanged;

        public event EventHandler DocumentLoading;
        public event EventHandler DocumentUnload;
        private event EventHandler<IExecuteScriptCompletedEventArgs> ExecuteScriptCompletedInterface;
        //event EventHandler<IExecuteScriptCompletedEventArgs> IWebViewControlEvents.ExecuteScriptCompleted
        //{
        //    add
        //    {
        //        this.ExecuteScriptCompletedInterface += value;
        //    }

        //    remove
        //    {
        //        this.ExecuteScriptCompletedInterface -= value;
        //    }
        //}

        //public event EventHandler<WebViewButtonDownEventArgs> MouseButtonDown;
        public event EventHandler<ContextMenuRequestedEventArgs> ContextMenuRequested;

        public event EventHandler<ServerCertificateErrorDetectedEventArgs> ServerCertificateErrorDetected;

        public bool Dock { get; set; } = true;
        public WebView2View WebView2 => this._WebViewControl.WebView;
        private bool IsBrowserEnded = false;
        private string _Url;
        private bool IsCreated { get; set; }
        protected override void Initialize()
        {
            base.Initialize();
            this.ControlType = CoreWindowsWrapper.Win32ApiForm.ControlType.Label;

            this.TypeIdentifier = "static";
            this.Style = WindowStylesConst.WS_VISIBLE | WindowStylesConst.WS_CHILD | StaticControlStyles.SS_NOTIFY;
            this.BackColor = CoreWindowsWrapper.Tools.ColorTool.White;
            this.ForeColor = CoreWindowsWrapper.Tools.ColorTool.Black;
        }
        private void CreateWebViewControl(IntPtr parent)
        {
            try
            {
                this._RpcHandler.RpcEvent += OnRpcEventIntern;
                this._RpcHandler.RpcDomUnloadEvent += OnRpcDomUnloadEvent;
                this._WebViewControl = new WebView2Control(parent, EnvFolder, UserDataFolder, "");
                WireEvents(this._WebViewControl);
            }
            catch (Exception ex)
            {
                Debug.Print(nameof(CreateWebViewControl), ex);

            }
        }

      

        private void WireEvents(WebView2Control control)
        {
            if (control == null) return;
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
            control.CompoisitionControllerCursorChanged += OnCompoisitionControllerCursorChanged;
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
            control.ServerCertificateErrorDetected += OnServerCertificateErrorDetectedIntern;
        }

        private void OnServerCertificateErrorDetectedIntern(object sender, ServerCertificateErrorDetectedEventArgs e)
        {
            OnServerCertificateErrorDetected(sender, e);
        }

        private void OnServerCertificateErrorDetected(object sender, ServerCertificateErrorDetectedEventArgs e)
        {
            ServerCertificateErrorDetected?.Invoke(this, e);
        }

        private void OnCompoisitionControllerCursorChanged(object sender, CursorChangedEventArgs e)
        {
            
        }

        private void OnNavigationCompleted(object sender, NavigationCompletedEventArgs e)
        {
            
            Debug.Print("OnNavigationCompleted:" + e.IsSuccess);
        }

        private void OnWebWindowCreated(object sender, EventArgs e)
        {
            WebWindowInitAction();


            this.DoDock();
            if (NativeWindow.TryGetWindow(this.ParentHandle, out NativeWindow wnd))
            {
                this._ParentNativeWindow = wnd;
                this._ParentNativeWindow.Size += OnParentSize;
            }

            OnWebViewCreated();
        }

        private bool CheckIsCreatedOrEnded
        {
            get
            {
                if (!this.IsCreated) return false;
                if (this.IsBrowserEnded) return false;
                return true;
            }
        }
        public string Url
        {
            get => this._Url;
            set
            {
                this._Url = value;
                if (this.CheckIsCreatedOrEnded)
                {
                    Navigate(value);
                }
            }
        }
        public void Navigate(string url)
        {
            this._Url = url;
            if (this.CheckIsCreatedOrEnded && !string.IsNullOrEmpty(this.Url))
            {
                try
                {
                    this._WebViewControl.Navigate(this._Url);
                }
                catch (Exception e)
                {
                    MessageBox.Show(this.Handle, e.Message, "Navigation Error!", MessageBoxOptions.OkOnly | MessageBoxOptions.IconError);

                }

            }

        }
        private void WebWindowInitAction()
        {
            this.IsCreated = true;
            //AddRemoteObject("RpcHandler", this._RpcHandler);
            AddScriptToExecuteOnDocumentCreated(
               "class ScriptErrorObject{constructor(e,t,r,n,i,c){this.name=e,this.message=t,this.fileName=r,this.lineNumber=n,this.columnNumber=i,this.stack=c}}window.external={sendMessage:function(e){window.chrome.webview.postMessage(e)},receiveMessage:function(e){window.chrome.webview.addEventListener(\"message\",(function(t){e(t.data)}))},evalScript:function(e){try{return eval(e)}catch(e){let t=new ScriptErrorObject(e.name,e.message,e.fileName,e.lineNumber,e.columnNumber,e.stack);return JSON.stringify(t)}},executeScript:function(e){try{return new Function(e)()}catch(e){let t=new ScriptErrorObject(e.name,e.message,e.fileName,e.lineNumber,e.columnNumber,e.stack);return JSON.stringify(t)}}};");
            AddScriptToExecuteOnDocumentCreated(
                "window.external.raiseRpcEvent= async function(action, obj,objName,eventObj) { if(window.diga == undefined) window.diga = new Object(); try { const rpcHandler = window.chrome.webview.hostObjects.RpcHandler;const rpcObj = await rpcHandler.GetNewRpc(); let vn=await rpcObj.idName;window.diga[vn]=eventObj;rpcObj.objId = obj.id;rpcObj.action = action;rpcObj.varname=objName; rpcObj.param = \"empty\";rpcObj.item=document.getElementById(obj.id);let r = await rpcHandler.Handle(await rpcObj.id, await rpcObj.action, rpcObj);let b = await rpcHandler.ReleaseObject(rpcObj); } catch (e) { alert(e); } }; console.log('script_loaded'); window.addEventListener(\"beforeunload\",(e)=>{ window.chrome.webview.hostObjects.sync.RpcHandler.UnloadDom(); });");

            if (!string.IsNullOrEmpty(this._Url))
            {
                Navigate(this.Url);
               
            }
        }

        private void OnParentSize(object sender, SizeEventArgs e)
        {
            this.DoDock();
        }
        protected override void AfterCreate()
        {
            if (this.Handle != IntPtr.Zero)
            {
                CreateWebViewControl(this.Handle);

            }
            else
            {
                throw new Exception("Cannot create WebView");
            }


        }
        public override bool Create(nint parentId)
        {
            this.ParentHandle = parentId;
            bool created = base.Create(parentId);
            return created;
        }

        public void DoDock()
        {
            //if (this.CheckIsCreatedOrEnded)
            //{

            //    if (this.AutoDock)
            //    {
            if (NativeWindow.TryGetWindow(this.ParentHandle, out NativeWindow wnd))
            {
                Rect rect = wnd.GetClientRect();
                if (Dock)
                {
                    this.Left = rect.Left;
                    this.Top = rect.Top;
                    this.Width = rect.Width;
                    this.Height = rect.Height;
                }

                User32.MoveWindow(this.Handle, Left, Top, Width, Height, bRepaint: true);

            }
            else
            {
                if (User32.GetClientRect(this.ParentHandle, out Rect rect))
                {
                    if (Dock)
                    {
                        this.Left = rect.Left;
                        this.Top = rect.Top;
                        this.Width = rect.Width;
                        this.Height = rect.Height;
                    }
                    User32.MoveWindow(this.Handle, Left, Top, Width, Height, bRepaint: true);
                }

            }
            //}
            this._WebViewControl.DockToParent();
            //}


        }

        protected virtual void OnWebResourceRequested(WebResourceRequestedEventArgs e)
        {
            using (var def = e.GetDeferral())
            {


                CheckMonitoring(e);


                WebResourceRequested?.Invoke(this, e);
            }
        }
        private ConcurrentQueue<ResponseInfo> _InfoCollection = new ConcurrentQueue<ResponseInfo>();
        private void CheckMonitoring(WebResourceRequestedEventArgs e)
        {
            string uri = e.Request.Uri;
            bool isMonitroingUrl = IsMonitoringUrl(uri);
            if(isMonitroingUrl)
            {
                RequestInfo requestInfo = new RequestInfo(e.Request);
                if(GetMonitoringFile(requestInfo, out var responseInfo))
                {
                
                    var response = this.CreateResponse(responseInfo);
                    e.Response = response;
                    //_CleanUp = () =>
                    //{
                    //    responseInfo.Dispose();
                    //};
                    
                    _InfoCollection.Enqueue(responseInfo);
                    //responseInfo.Dispose();
                }
            }

        }
       
        public WebResourceResponse CreateResponse(ResponseInfo responseInfo)
        {
            WebResourceResponse response = null;
            if (this.CheckIsCreatedOrEnded)
            {
                response = this._WebViewControl.GetResponseStream(responseInfo.Stream, responseInfo.StatusCode,
                    responseInfo.StatusText, responseInfo.HeaderToString(), responseInfo.ContentType);
            }

            return response;
        }
        public string MonitoringFolder { get; set; }
        private bool MonitoringFileExist(string file)
        {
            if (file.StartsWith("/"))
                file = file.Substring(1);
            file = file.Replace("/", "\\");
            string fullName = Path.Combine(this.MonitoringFolder, file);
            return File.Exists(fullName);
        }
        private bool GetMonitoringFile(RequestInfo requestInfo, out ResponseInfo responseInfo)
        {
            string url = requestInfo.Uri;
            if (!url.StartsWith(this.MonitoringUrl))
            {
                responseInfo = null;
                return false;
            }

            Uri uri = new Uri(url);


            //TestMimeTypes();
            string baseDirectory = this.MonitoringFolder;

            string file = MonitoringFileExist(uri.AbsolutePath) ? uri.AbsolutePath : "";

            if (file == "/")
                file = "";
            if (file.StartsWith("/"))
                file = file.Substring(1);
            if (string.IsNullOrEmpty(file))
                file = "index.html";
            file = file.Replace("/", "\\");
            file = Path.Combine(baseDirectory, file);
            FileInfo fileInfo = new FileInfo(file);
            if (!fileInfo.Exists)
            {
                responseInfo = new ResponseInfo("<h1>Server Error</h1><h5>file not found:" + file + "</h5>");
                responseInfo.Header.Add("content-type", "text/html; charset=utf-8");
                responseInfo.ContentType = "content-type: text/html; charset=utf-8";
                responseInfo.StatusCode = 404;
                responseInfo.StatusText = "Not Found";

                return true;
            }

            string contentType = fileInfo.MimeTypeOrDefault();
            if (contentType == "document")
                Debug.Print(contentType);
            try
            {
                byte[] bytes = File.ReadAllBytes(file);
                responseInfo = new ResponseInfo(bytes);
                string utf8Extension = GetUtf8IfNeeded(contentType);

                responseInfo.Header.Add("content-type", contentType + utf8Extension);

                responseInfo.ContentType = "content-type: " + contentType + utf8Extension;
                responseInfo.StatusCode = 200;
                responseInfo.StatusText = "OK";

                return true;
            }
            catch (Exception e)
            {
                string message = "Error:" + e.Message;
                responseInfo = new ResponseInfo(message);
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
                return "";

            bool needUtf8 = false;

            switch (contentType)
            {
                case "application/x-javascript":
                case "text/html":
                case "text/css":
                case "application/javascript":
                case "application/json":
                    needUtf8 = true;
                    break;
            }

            if (needUtf8)
                return "; charset=utf-8";
            return "";
        }

        public bool EnableMonitoring {  get; set; }
        public string MonitoringUrl { get; set; }
        private bool IsMonitoringUrl(string url)
        {
            if (!this.EnableMonitoring)
                return false;
            if (string.IsNullOrEmpty(url))
                return false;
            if (url.StartsWith(this.MonitoringUrl))
                return true;
            return false;
        }

        public bool AreBrowserAcceleratorKeysEnabled { get; set; } = true;
        public bool AreDefaultContextMenusEnabled { get; set; } = true;
        public bool AreDefaultScriptDialogsEnabled { get; set; } = true;
        public bool AreDevToolsEnabled { get; set; } = true;
        public bool AreHostObjectsAllowed { get; set; } = true;
        public bool IsGeneralAutofillEnabled { get; set; } = true;
        public bool IsPasswordAutosaveEnabled { get; set; } = true;
        public bool IsScriptEnabled { get; set; } = true;
        public bool IsStatusBarEnabled { get; set; } = true;
        public bool IsWebMessageEnabled { get; set; } = true;
        public bool IsZoomControlEnabled { get; set; } = true;
        public bool IsBuiltInErrorPageEnabled { get; set; } = true;
        public bool IsPinchZoomEnabled { get; set; } = true;
        public bool IsSwipeNavigationEnabled { get; set; } = true;
        public bool IsReputationCheckingRequired { get; set; } = true;

        /// <summary>
        /// 用户缓存目录
        /// </summary>
        public string UserDataFolder { get; set; } = AppContext.BaseDirectory;
        /// <summary>
        /// 运行环境目录
        /// </summary>
        public string EnvFolder { get; set; } = string.Empty;
        private void WebWindowInitSettings(BeforeCreateEventArgs e)
        {
            e.Settings.AreBrowserAcceleratorKeysEnabled = this.AreBrowserAcceleratorKeysEnabled;
            e.Settings.AreDefaultContextMenusEnabled = this.AreDefaultContextMenusEnabled;
            e.Settings.AreDefaultScriptDialogsEnabled = this.AreDefaultScriptDialogsEnabled;
            e.Settings.AreDevToolsEnabled = this.AreDevToolsEnabled;
            e.Settings.AreHostObjectsAllowed = this.AreHostObjectsAllowed;
            e.Settings.IsGeneralAutofillEnabled = this.IsGeneralAutofillEnabled;
            e.Settings.IsPasswordAutosaveEnabled = this.IsPasswordAutosaveEnabled;
            e.Settings.IsScriptEnabled = this.IsScriptEnabled;
            e.Settings.IsStatusBarEnabled = this.IsStatusBarEnabled;
            e.Settings.IsWebMessageEnabled = this.IsWebMessageEnabled;
            e.Settings.IsZoomControlEnabled = this.IsZoomControlEnabled;
            e.Settings.IsBuiltInErrorPageEnabled = this.IsBuiltInErrorPageEnabled;
            e.Settings.IsPinchZoomEnabled = this.IsPinchZoomEnabled;
            e.Settings.IsSwipeNavigationEnabled = this.IsSwipeNavigationEnabled;
            e.Settings.IsReputationCheckingRequired = this.IsReputationCheckingRequired;
            
            //e.Settings.HiddenPdfToolbarItems = COREWEBVIEW2_PDF_TOOLBAR_ITEMS.COREWEBVIEW2_PDF_TOOLBAR_ITEMS_DEFAULT;
            
        }
        
        private void OnWebWindowBeforeCreate(object sender, BeforeCreateEventArgs e)
        {
            
            WebWindowInitSettings(e);
        }
        protected virtual void OnNavigationStart(NavigationStartingEventArgs e)
        {
            NavigationStart?.Invoke(this, e);
        }

        protected virtual void OnContentLoading(ContentLoadingEventArgs e)
        {
            ContentLoading?.Invoke(this, e);
        }

        protected virtual void OnSourceChanged(SourceChangedEventArgs e)
        {
            SourceChanged?.Invoke(this, e);
        }

        protected virtual void OnHistoryChanged(WebView2EventArgs e)
        {
            HistoryChanged?.Invoke(this, e);
        }

        protected virtual void OnNavigationCompleted(NavigationCompletedEventArgs e)
        {

         
            try
            {
                if (_InfoCollection.Count > 1)
                {
                   
                    while (_InfoCollection.TryDequeue(out var info))
                    {
                        info.Dispose();
                        if (_InfoCollection.Count <= 1)
                            break;
                        else
                            Debug.Print("More to delete!");
                    }


                }

            }
            catch (Exception ex)
            {

                Debug.Print("OnWebResourceResponseReceived ResponseInfo.Dispoase error:" + ex.Message);
            }

            NavigationCompleted?.Invoke(this, e);
        }

        protected virtual void OnAcceleratorKeyPressed(AcceleratorKeyPressedEventArgs e)
        {
            AcceleratorKeyPressed?.Invoke(this, e);
        }


        protected virtual void OnContainsFullScreenElementChanged(WebView2EventArgs e)
        {
            ContainsFullScreenElementChanged?.Invoke(this, e);
        }

        protected virtual void OnDocumentTitleChanged(WebView2EventArgs e)
        {
            DocumentTitleChanged?.Invoke(this, e);
        }

        protected virtual void OnFrameNavigationStarting(NavigationStartingEventArgs e)
        {
            FrameNavigationStarting?.Invoke(this, e);
        }

        protected virtual void OnScriptDialogOpening(ScriptDialogOpeningEventArgs e)
        {
            ScriptDialogOpening?.Invoke(this, e);
        }

        protected virtual void OnWindowCloseRequested(WebView2EventArgs e)
        {
            WindowCloseRequested?.Invoke(this, e);
        }

        protected virtual void OnScriptToExecuteOnDocumentCreatedCompleted(
            AddScriptToExecuteOnDocumentCreatedCompletedEventArgs e)
        {
            ScriptToExecuteOnDocumentCreatedCompleted?.Invoke(this, e);
        }

        protected virtual void OnWebMessageReceived(WebMessageReceivedEventArgs e)
        {

            WebMessageReceived?.Invoke(this, e);
        }

        protected virtual void OnProcessFailed(ProcessFailedEventArgs e)
        {
            ProcessFailed?.Invoke(this, e);
        }

        protected virtual void OnExecuteScriptCompleted(ExecuteScriptCompletedEventArgs e)
        {
            try
            {
                ExecuteScriptCompletedInterface?.Invoke(this, e);
            }
            catch (Exception exception)
            {
                Debug.Print("ExecuteScriptCompleted Exception:" + exception.ToString());
            }

            ExecuteScriptCompleted?.Invoke(this, e);

        }

        protected virtual void OnNewWindowRequested(NewWindowRequestedEventArgs e)
        {

            NewWindowRequested?.Invoke(this, e);
        }

        protected virtual void OnPermissionRequested(PermissionRequestedEventArgs e)
        {
            PermissionRequested?.Invoke(this, e);
        }


        protected virtual void OnZoomFactorChanged(WebView2EventArgs e)
        {
            ZoomFactorChanged?.Invoke(this, e);
        }


        protected virtual void OnWebViewGotFocus(WebView2EventArgs e)
        {
            WebViewGotFocus?.Invoke(this, e);
        }

        protected virtual void OnWebViewLostFocus(WebView2EventArgs e)
        {
            WebViewLostFocus?.Invoke(this, e);
        }

        protected virtual void OnMoveFocusRequested(MoveFocusRequestedEventArgs e)
        {
            MoveFocusRequested?.Invoke(this, e);
        }
        public string BrowserVersion => this._WebViewControl.BrowserInfo;

        protected virtual void OnWebViewCreated()
        {
            WebViewCreated?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnFrameNavigationCompleted(NavigationCompletedEventArgs e)
        {
            FrameNavigationCompleted?.Invoke(this, e);
        }
        private static void BeforeProcessExitCatch(object sender, EventArgs e)
        {
            
            Debug.Print("BeforeProcessExitCatch");
            //DateTime n = DateTime.Now;
            //DateTime x = DateTime.Now;
            //TimeSpan diff = x - n;
            //while (diff.Seconds < 5)
            //{
            //    UIDispatcher.UIThread.DoEvents();
            //    x = DateTime.Now;
            //    diff = x - n;
            //}
        }
        protected virtual void OnDocumentLoading()
        {
            //DOMWindow window = this.GetDOMWindow();
            //if (this._Docuemnt != null)
            //    this._Docuemnt.DomEvent -= OnDomEvent;
            //UIDispatcher.UIThread.Post(() =>
            //{
            //    try
            //    {
            //        this._Window = this.GetDOMWindow();//.GetCopy();
            //        this._Window.addEventListener("error", new DOMEventListenerScript(this._Window, "error"), true);
            //        this._Window.DomEvent += OnDomEvent;
            //        this.GetDOMConsole().log("Document_Loading");
            //    }
            //    catch (Exception e)
            //    {

            //        Debug.Print(e.ToString());
            //    }


                DocumentLoading?.Invoke(this, EventArgs.Empty);

            //});
        }
        private void OnDomEvent(object sender, RpcEventHandlerArgs e)
        {
            switch (e.EventName)
            {
                case "error":
                    {
                        Debug.Print("Error");
                    }
                    break;

            }
        }

        protected virtual void OnDomContentLoaded(DOMContentLoadedEventArgs e)
        {


            
            DOMContentLoaded?.Invoke(this, e);
            OnDocumentLoading();
            //UIDispatcher.UIThread.InvokeAsync(OnDocumentLoading);
        }

        protected virtual void OnWebResourceResponseReceived(WebResourceResponseReceivedEventArgs e)
        {
            
           

            WebResourceResponseReceived?.Invoke(this, e);
            //CleanUpResponses(e);
        }

        protected virtual void OnBeforeEnvironmentCompleted(EnvironmentCompletedHandlerArgs e)
        {
            BeforeEnvironmentCompleted?.Invoke(this, e);
        }

        protected virtual void OnDownloadStarting(DownloadStartingEventArgs e)
        {
            DownloadStarting?.Invoke(this, e);
        }

        protected virtual void OnFrameCreated(FrameCreatedEventArgs e)
        {
            FrameCreated?.Invoke(this, e);
        }

        protected virtual void OnRasterizationScaleChanged(WebView2EventArgs e)
        {
            RasterizationScaleChanged?.Invoke(this, e);
        }

        protected virtual void OnScriptEvent(RpcEventHandlerArgs e)
        {
            ScriptEvent?.Invoke(this, e);
        }
        private void OnRpcEventIntern(object sender, RpcEventHandlerArgs e)
        {
            OnScriptEvent(e);
        }
        protected virtual void OnDocumentUnload()
        {
            Task.Run(() =>
            {

                DocumentUnload?.Invoke(this, EventArgs.Empty);


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

        private void ScriptToExecuteOnDocumentCreatedCompletedIntern(object sender,
            AddScriptToExecuteOnDocumentCreatedCompletedEventArgs e)
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
                this.IsBrowserEnded = true;
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
            IsMutedChanged?.Invoke(this, e);
        }
        protected virtual void OnIsDocumentPlayingAudioChanged(WebView2EventArgs e)
        {
            IsDocumentPlayingAudioChanged?.Invoke(this, e);
        }

        protected virtual void OnIsDefaultDownloadDialogOpenChanged(WebView2EventArgs e)
        {
            IsDefaultDownloadDialogOpenChanged?.Invoke(this, e);
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
            ContextMenuRequested?.Invoke(this, e);
        }
        private void BeforeDisposeWebView()
        {
            this.BeforeWebViewDestroy?.Invoke(this, EventArgs.Empty);
            UnWireEvents(this._WebViewControl);
        }
        private bool _UnWireExecuted;
        private void UnWireEvents(WebView2Control control)
        {
            if (this._UnWireExecuted) return;

            if (control == null) return;
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
            control.CompoisitionControllerCursorChanged -= OnCompoisitionControllerCursorChanged;
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

        public WebView2SharedBuffer CreateSharedBuffer(ulong size)
        {
            if(this.CheckIsCreatedOrEnded)
            {
                return this._WebViewControl.CreateSharedBuffer(size);
            }
            return null;
        }
        public void OpenDefaultDownloadDialog()
        {
            if (this.CheckIsCreatedOrEnded)
            {
                this._WebViewControl.OpenDefaultDownloadDialog();
            }
        }

        public void PostSharedBufferToScript(WebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson)
        {
            if(this.CheckIsCreatedOrEnded)
            {
                this._WebViewControl.PostSharedBufferToScript(sharedBuffer, access, additionalDataAsJson);
            }
        }

        public void AddRemoteObject(string name, object obj)
        {
            if (this.CheckIsCreatedOrEnded)
            {
                

                this._WebViewControl.AddRemoteObject(name, obj);
            }
        }
        public void AddScriptToExecuteOnDocumentCreated(string javaScript)
        {
            if (!this.CheckIsCreatedOrEnded) return;
            this._WebViewControl.AddScriptToExecuteOnDocumentCreated(javaScript);
        }

    }
}
