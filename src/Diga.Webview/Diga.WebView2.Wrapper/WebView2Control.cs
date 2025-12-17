using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using Diga.WebView2.Wrapper.Types;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper
{

    public class WebView2Control : IDisposable
    {
        private static int RefCounter;
        private string _BrowserInfo;

        public event EventHandler Created;
        public event EventHandler<BeforeCreateEventArgs> BeforeCreate;
        public event EventHandler<NavigationStartingEventArgs> NavigateStart;
        public event EventHandler<ContentLoadingEventArgs> ContentLoading;
        public event EventHandler<SourceChangedEventArgs> SourceChanged;
        public event EventHandler<WebView2EventArgs> HistoryChanged;
        public event EventHandler<NavigationCompletedEventArgs> NavigationCompleted;
        public event EventHandler<WebResourceRequestedEventArgs> WebResourceRequested;
        public event EventHandler<WebView2EventArgs> ContainsFullScreenElementChanged;
        public event EventHandler<AcceleratorKeyPressedEventArgs> AcceleratorKeyPressed;
        public event EventHandler<WebView2EventArgs> GotFocus;
        public event EventHandler<WebView2EventArgs> LostFocus;
        public event EventHandler<MoveFocusRequestedEventArgs> MoveFocusRequested;
        public event EventHandler<WebView2EventArgs> ZoomFactorChanged;
        public event EventHandler<WebView2EventArgs> DocumentTitleChanged;
        public event EventHandler<NewWindowRequestedEventArgs> NewWindowRequested;
        public event EventHandler<PermissionRequestedEventArgs> PermissionRequested;
        public event EventHandler<NavigationCompletedEventArgs> FrameNavigationCompleted;
        public event EventHandler<NavigationStartingEventArgs> FrameNavigationStarting;
        public event EventHandler<ExecuteScriptCompletedEventArgs> ExecuteScriptCompleted;
        public event EventHandler<ProcessFailedEventArgs> ProcessFailed;
        public event EventHandler<ScriptDialogOpeningEventArgs> ScriptDialogOpening;
        public event EventHandler<WebMessageReceivedEventArgs> WebMessageReceived;
        public event EventHandler<WebView2EventArgs> WindowCloseRequested;
        public event EventHandler<AddScriptToExecuteOnDocumentCreatedCompletedEventArgs>
            ScriptToExecuteOnDocumentCreatedCompleted;
        public event EventHandler<DOMContentLoadedEventArgs> DOMContentLoaded;
        public event EventHandler<WebResourceResponseReceivedEventArgs> WebResourceResponseReceived;
        public event EventHandler<WebView2EventArgs> NewBrowserVersionAvailable;
        public event EventHandler<EnvironmentCompletedHandlerArgs> BeforeEnvironmentCompleted;
        public event EventHandler<DownloadStartingEventArgs> DownloadStarting;
        public event EventHandler<FrameCreatedEventArgs> FrameCreated;
        public event EventHandler<ClientCertificateRequestedEventArgs> ClientCertificateRequested;
        public event EventHandler<WebView2EventArgs> RasterizationScaleChanged;
        public event EventHandler<CompositionControllerCompletedEventArgs> CompositionControllerCompleted;
        public event EventHandler<CursorChangedEventArgs> CompoisitionControllerCursorChanged;
        public event EventHandler<BrowserProcessExitedEventArgs> BrowserProcessExited;
        public event EventHandler<WebView2EventArgs> IsMutedChanged;
        public event EventHandler<WebView2EventArgs> IsDocumentPlayingAudioChanged;
        public event EventHandler<WebView2EventArgs> IsDefaultDownloadDialogOpenChanged;
        public event EventHandler<BasicAuthenticationRequestedEventArgs> BasicAuthenticationRequested;
        public event EventHandler<ContextMenuRequestedEventArgs> ContextMenuRequested;
        public event EventHandler<PrintToPdfCompleteEventArgs> PrintToPdfCompleted;
        public event EventHandler<ServerCertificateErrorDetectedEventArgs> ServerCertificateErrorDetected;
        public string BrowserInfo => _BrowserInfo;
        public WebView2Environment Environment { get; private set; }
        public WebView2View WebView { get; set; }
        private WebView2Controller Controller { get; set; }
        private WebView2Settings Settings { get; set; }
        private WebView2CompositionController CompositionController { get; set; }
        public CookieManager GetCookieManager => this.WebView.CookieManager;

        private HandleRef _ParentHandle { get; set; }
        public string BrowserExecutableFolder { get; }
        public string AdditionalBrowserArguments { get; }
        public string UserDataFolder { get; }
        private WebView2EnvironmentOptions Options { get; set; }

        private readonly Dictionary<string, object> _RemoteObjects = new Dictionary<string, object>();
        public List<SchemeRegistration> SchemeRegistrations { get; } = new List<SchemeRegistration>();
        public WebView2Control(IntPtr parentHandle) : this(parentHandle, string.Empty, string.Empty, string.Empty, null)
        {

        }
        public WebView2Control(IntPtr parentHandle, string browserExecutableFolder, string userDataFolder,
          string additionalBrowserArguments, List<SchemeRegistration> registrations)
        {
            if (registrations != null)
            {
                this.SchemeRegistrations = registrations;
            }
            this._ParentHandle = new HandleRef(this, parentHandle);
            this.BrowserExecutableFolder = browserExecutableFolder;
            this.UserDataFolder = userDataFolder;
            this.AdditionalBrowserArguments = additionalBrowserArguments;

            CreateWebView();
            RefCounter += 1;
        }
        public WebView2Control(IntPtr parentHandle, string browserExecutableFolder, string userDataFolder, string additionalBrowserArguments)
        {
            this._ParentHandle = new HandleRef(this, parentHandle);
            this.BrowserExecutableFolder = browserExecutableFolder;
            this.UserDataFolder = userDataFolder;
            this.AdditionalBrowserArguments = additionalBrowserArguments;
            CreateWebView();
            RefCounter += 1;
        }
        private void CreateWebView()
        {
            var handler = new EnvironmentCompletedHandler(this._ParentHandle.Handle);
            handler.ControllerCompleted += OnControllerCompleted;
            handler.BeforeEnvironmentCompleted += OnBeforeEnvironmentCompletedIntern;
            handler.AfterEnvironmentCompleted += OnAfterEnvironmentCompletedIntern;
            handler.PrepareControllerCreate += OnBeforeControllerCreateIntern;
            handler.CompositionControllerCompleted += OnCompositionControllerCompletedIntern;
            Native.GetAvailableVersion(this.BrowserExecutableFolder, out string browserInfo);
            this._BrowserInfo = browserInfo;
            this.Options = new WebView2EnvironmentOptions();
            this.Options.SetAdditionalBrowserArguments(this.AdditionalBrowserArguments);
            Native.CompareVersion(browserInfo, this.Options.GetTargetCompatibleBrowserVersion(), out int result);
            if (result == -1)
            {
                throw new Exception("The installed Browser-Version is older than (" +
                                    this.Options.GetTargetCompatibleBrowserVersion() + ")");
            }

            WebView2CustomSchemeRegistration reg = new WebView2CustomSchemeRegistration("diga");
            reg.AllowedOrgins.Add("*");
            reg.SetTreatAsSecure((CBOOL)true);
            reg.SetHasAuthorityComponent((CBOOL)true);

            this.Options.CustomSchemeRegistrations.Add(reg);

            foreach (var registration in this.SchemeRegistrations)
            {
                if (registration.SchemeName != "diga")
                {
                    WebView2CustomSchemeRegistration csr = registration.GetAsWebView2CustomSchemeRegistration();
                    if (!string.IsNullOrEmpty(csr.GetSchemeName()))
                    {
                        Options.CustomSchemeRegistrations.Add(csr);
                    }
                }
            }

            Native.CreateEnvironmentWithOptions(BrowserExecutableFolder, this.UserDataFolder, this.Options, handler);

        }

        public WebResourceResponse GetResponseStream(Stream stream, int statusCode, string statusText, string headers,
          string contentType)
        {
            var mStream = new ManagedIStream(ref stream);


            var responseInterface = this.Environment.CreateWebResourceResponse(mStream, statusCode, statusText, headers);
            WebResourceResponse wrapper = new WebResourceResponse(responseInterface);
            return wrapper;
        }
        private void UnWireEvents()
        {
            if (this.Environment != null)
            {
                this.Environment.NewBrowserVersionAvailable -= OnNewBrowserVersionAvailableIntern;
                this.Environment.BrowserProcessExited -= OnBrowserProcessExitedIntern;
            }
            if (this.Controller != null)
            {
                this.Controller.AcceleratorKeyPressed -= OnAcceleratorKeyPressedIntern;
                this.Controller.GotFocus -= OnGotFocusIntern;
                this.Controller.LostFocus -= OnLostFocusIntern;
                this.Controller.MoveFocusRequested -= OnMoveFocusRequestedIntern;
                this.Controller.ZoomFactorChanged -= OnZoomFactorChangedIntern;
                this.Controller.RasterizationScaleChanged -= OnRasterizationScaleChangedIntern;

            }

            if (this.CompositionController != null)
            {
                this.CompositionController.CursorChanged -= OnCompositionControllerCursorChangedIntern;
            }
            if (this.WebView != null)
            {
                this.WebView.ClientCertificateRequested -= OnClientCertificateRequestedIntern;
                this.WebView.ContainsFullScreenElementChanged -= OnContainsFullScreenElementChangedIntern;
                this.WebView.ContentLoading -= OnContentLoadingIntern;
                this.WebView.DocumentTitleChanged -= OnDocumentTitleChangedIntern;
                this.WebView.DOMContentLoaded -= OnDOMContentLoadedIntern;
                this.WebView.DownloadStarting -= OnDownloadStartingIntern;
                this.WebView.ExecuteScriptCompleted -= OnExecuteScriptCompletedIntern;
                this.WebView.FrameCreated -= OnFrameCreatedIntern;
                this.WebView.FrameNavigationCompleted -= OnFrameNavigationCompletedIntern;
                this.WebView.FrameNavigationStarting -= OnFrameNavigationStartingIntern;
                this.WebView.HistoryChanged -= OnHistoryChangedInternal;
                this.WebView.NavigationCompleted -= OnNavigationCompletedIntern;
                this.WebView.NavigationStarting -= OnNavigateStartIntern;
                this.WebView.NewWindowRequested -= OnNewWindowRequestedIntern;
                this.WebView.PermissionRequested -= OnPermissionRequestedIntern;
                this.WebView.ProcessFailed -= OnProcessFailedIntern;
                this.WebView.ScriptDialogOpening -= OnScriptDialogOpeningIntern;
                this.WebView.ScriptToExecuteOnDocumentCreated -= OnScriptToExecuteOnDocumentCreatedIntern;
                this.WebView.SourceChanged -= OnSourceChangedInternal;
                this.WebView.WebMessageReceived -= OnWebMessageReceivedIntern;
                this.WebView.WebResourceRequested -= OnWebResourceRequestedIntern;
                this.WebView.WebResourceResponseReceived -= OnWebResourceResponseReceivedIntern;
                this.WebView.WindowCloseRequested -= OnWindowCloseRequestedIntern;
                this.WebView.IsMutedChanged -= OnIsMutedChangedIntern;
                this.WebView.IsDocumentPlayingAudioChanged -= OnIsDocumentPlayingAudioChangedÍntern;
                this.WebView.IsDefaultDownloadDialogOpenChanged -= OnIsDefaultDownloadDialogOpenChangedIntern;
                this.WebView.BasicAuthenticationRequested -= OnBasicAuthenticationRequestedIntern;
                this.WebView.ContextMenuRequested -= OnContextMenuRequestedIntern;
                this.WebView.PrintToPdfCompleted -= OnPrintToPdfCompletedIntern;
                this.WebView.ServerCertificateErrorDetected -= OnServerCertificateErrorDetectedIntern;

            }
        }

        private void CleanupControls()
        {
            UnWireEvents();
            RefCounter -= 1;

            this._ParentHandle = new HandleRef(this, IntPtr.Zero);
            this.WebView?.Dispose();
            this.WebView = null;

            this.Environment?.Dispose();
            this.Environment = null;
            this.CompositionController?.Dispose();
            this.CompositionController = null;
            this.Controller?.Dispose();
            this.Controller = null;

        }

        private void OnServerCertificateErrorDetectedIntern(object sender, ServerCertificateErrorDetectedEventArgs e)
        {
            OnServerCertificateErrorDetected(e);
        }

        private void OnServerCertificateErrorDetected(ServerCertificateErrorDetectedEventArgs e)
        {
            ServerCertificateErrorDetected?.Invoke(this, e);
        }

        private void OnBasicAuthenticationRequestedIntern(object sender, BasicAuthenticationRequestedEventArgs e)
        {
            OnBasicAuthenticationRequested(e);
        }
        private void OnIsDefaultDownloadDialogOpenChangedIntern(object sender, WebView2EventArgs e)
        {
            OnIsDefaultDownloadDialogOpenChanged(e);
        }
        private void OnIsDocumentPlayingAudioChangedÍntern(object sender, WebView2EventArgs e)
        {
            OnIsDocumentPlayingAudioChanged(e);
        }

        private void OnIsMutedChangedIntern(object sender, WebView2EventArgs e)
        {
            OnIsMutedChanged(e);
        }


        private void OnDownloadStartingIntern(object sender, DownloadStartingEventArgs e)
        {
            OnDownloadStarting(e);
        }

        private void OnFrameCreatedIntern(object sender, FrameCreatedEventArgs e)
        {
            OnFrameCreated(e);
        }
        private void OnClientCertificateRequestedIntern(object sender, ClientCertificateRequestedEventArgs e)
        {
            OnClientCertificateRequested(e);
        }
        private void OnRasterizationScaleChangedIntern(object sender, WebView2EventArgs e)
        {
            OnRasterizationScaleChanged(e);
        }

        private void OnCompositionControllerCompletedIntern(object sender, CompositionControllerCompletedEventArgs e)
        {
            this.CompositionController = e.CompositionController;
            this.CompositionController.CursorChanged += OnCompositionControllerCursorChangedIntern;

            OnCompositionControllerCompleted(e);
        }
        private void OnCompositionControllerCursorChangedIntern(object sender, CursorChangedEventArgs e)
        {
            OnCompoisitionControllerCursorChanged(e);
        }

        private void OnBeforeControllerCreateIntern(object sender, BeforeControllerCreateEventArgs e)
        {
            OnBeforeCreate(new BeforeCreateEventArgs(e.Settings));
        }

        private void OnAfterEnvironmentCompletedIntern(object sender, EnvironmentCompletedHandlerArgs e)
        {
            this.Environment = e.Environment;
            this.Environment.BrowserProcessExited += OnBrowserProcessExitedIntern;
            this.Environment.NewBrowserVersionAvailable += OnNewBrowserVersionAvailableIntern;
        }
        private void OnBrowserProcessExitedIntern(object sender, BrowserProcessExitedEventArgs e)
        {
            OnBrowserProcessExited(e);
        }

        private void OnNewBrowserVersionAvailableIntern(object sender, WebView2EventArgs e)
        {
            OnNewBrowserVersionAvailable(e);
        }
        private void OnBeforeEnvironmentCompletedIntern(object sender, EnvironmentCompletedHandlerArgs e)
        {

        }
        private void OnControllerCompleted(object sender, ControllerCompletedArgs e)
        {
            this.Controller = new WebView2Controller(e.Controller);
            this.Controller.AcceleratorKeyPressed += OnAcceleratorKeyPressedIntern;
            this.Controller.GotFocus += OnGotFocusIntern;
            this.Controller.LostFocus += OnLostFocusIntern;
            this.Controller.MoveFocusRequested += OnMoveFocusRequestedIntern;
            this.Controller.RasterizationScaleChanged += OnRasterizationScaleChangedIntern;
            this.Controller.ZoomFactorChanged += OnZoomFactorChangedIntern;

            this.WebView = new WebView2View((ICoreWebView2_21)e.WebView);
            this.WebView.ClientCertificateRequested += OnClientCertificateRequestedIntern;
            this.WebView.ContainsFullScreenElementChanged += OnContainsFullScreenElementChangedIntern;
            this.WebView.ContentLoading += OnContentLoadingIntern;
            this.WebView.DocumentTitleChanged += OnDocumentTitleChangedIntern;
            this.WebView.DOMContentLoaded += OnDOMContentLoadedIntern;
            this.WebView.DownloadStarting += OnDownloadStartingIntern;
            this.WebView.ExecuteScriptCompleted += OnExecuteScriptCompletedIntern;
            this.WebView.FrameCreated += OnFrameCreatedIntern;
            this.WebView.FrameNavigationCompleted += OnFrameNavigationCompletedIntern;
            this.WebView.FrameNavigationStarting += OnFrameNavigationStartingIntern;
            this.WebView.HistoryChanged += OnHistoryChangedInternal;
            this.WebView.NavigationCompleted += OnNavigationCompletedIntern;
            this.WebView.NavigationStarting += OnNavigateStartIntern;
            this.WebView.NewWindowRequested += OnNewWindowRequestedIntern;
            this.WebView.PermissionRequested += OnPermissionRequestedIntern;
            this.WebView.ProcessFailed += OnProcessFailedIntern;
            this.WebView.ScriptDialogOpening += OnScriptDialogOpeningIntern;
            this.WebView.ScriptToExecuteOnDocumentCreated += OnScriptToExecuteOnDocumentCreatedIntern;
            this.WebView.SourceChanged += OnSourceChangedInternal;
            this.WebView.WebMessageReceived += OnWebMessageReceivedIntern;
            this.WebView.WebResourceRequested += OnWebResourceRequestedIntern;
            this.WebView.WebResourceResponseReceived += OnWebResourceResponseReceivedIntern;
            this.WebView.WindowCloseRequested += OnWindowCloseRequestedIntern;
            this.WebView.IsMutedChanged += OnIsMutedChangedIntern;
            this.WebView.IsDocumentPlayingAudioChanged += OnIsDocumentPlayingAudioChangedÍntern;
            this.WebView.IsDefaultDownloadDialogOpenChanged += OnIsDefaultDownloadDialogOpenChangedIntern;
            this.WebView.BasicAuthenticationRequested += OnBasicAuthenticationRequestedIntern;
            this.WebView.ContextMenuRequested += OnContextMenuRequestedIntern;
            this.WebView.PrintToPdfCompleted += OnPrintToPdfCompletedIntern;
            this.WebView.ServerCertificateErrorDetected += OnServerCertificateErrorDetectedIntern;


            this.Settings = this.WebView.Settings;
            object wwIterface = e.WebView;

            if (wwIterface is ICoreWebView2Staging staging)
            {
                StagingHostHelper statingHostHelper = new StagingHostHelper();
                staging.AddHostObjectHelper(statingHostHelper);

            }
            OnCreated();
        }

        public void DockToParent()
        {
            if (this._ParentHandle.Handle == IntPtr.Zero) return;
            Native.GetClientRect(this._ParentHandle.Handle, out var rect);
            this.Controller.Bounds = rect;
        }
        public void AddScriptToExecuteOnDocumentCreated(string javaScript)
        {
            this.WebView?.AddScriptToExecuteOnDocumentCreated(javaScript);
        }

        public void PostWebMessageAsJson(string webMessageAsJson)
        {
            this.WebView?.PostWebMessageAsJson(webMessageAsJson);
        }

        public void PostWebMessageAsString(string webMessageAsString)
        {
            this.WebView.PostWebMessageAsString(webMessageAsString);
        }


        public void Navigate(string url)
        {
            this.WebView?.Navigate(url);
        }
        public void NavigateToString(string htmlContent)
        {
            this.WebView?.NavigateToString(htmlContent);
        }
        public void NavigateToUri(Uri uri)
        {
            if (uri == null)
                throw new ArgumentNullException("uri");

            string url = uri.IsAbsoluteUri ? uri.AbsoluteUri : uri.AbsolutePath;

            this.Navigate(url);

        }

        public void NavigateWithWebResourceRequest(WebResourceRequest request)
        {
            this.WebView?.NavigateWithWebResourceRequest(request.ToInterface());
        }
        public void ExecuteScript(string javaScript)
        {

            this.WebView?.ExecuteScript(javaScript);
        }
        public async Task<string> ExecuteScriptAsync(string javaScript)
        {
            return await this.WebView.ExecuteScriptAsync(javaScript);
        }
        public string InvokeScript(string javaScript, Action<string, int, string> actionToInvoke)
        {
            return this.WebView.InvokeScript(javaScript, actionToInvoke);
        }

        public WebResourceRequest CreateNewRequest(string url, string method, Stream requestBodyStream, string headerData)
        {
            WebResourceRequest request = GetWebResourceRequest(url, method, requestBodyStream, headerData);
            return request;


        }
        public WebResourceRequest GetWebResourceRequest(string url, string method, Stream postDataStream,
           string headers)
        {

            if (this.Environment == null)
            {
                throw new InvalidOperationException("Environment not created");
            }

            var newRequest = this.Environment.CreateWebResourceRequest(url, method, postDataStream, headers);
            return newRequest;

        }

        public void GoBack()
        {
            this.WebView?.GoBack();

        }

        public void GoForward()
        {
            this.WebView?.GoForward();

        }

        public void Close()
        {
            this.Controller?.Close();
        }
        public void Reload()
        {
            this.WebView?.Reload();
        }
        public bool CanGoBack => (CBOOL)this.WebView.CanGoBack;
        public bool CanGoForward => (CBOOL)this.WebView.CanGoForward;
        public string DocumentTitle => this.WebView.DocumentTitle;

        public string Source => this.WebView.Source;

        private bool _IsDisposed;
        public virtual void Dispose(bool dispose)
        {
            if (_IsDisposed) return;
            if (dispose)
            {
                CleanupControls();
                this._IsDisposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);


        }

        protected virtual void OnContextMenuRequested(ContextMenuRequestedEventArgs e)
        {
            EventHandler<ContextMenuRequestedEventArgs> handler = this.ContextMenuRequested;

            if (handler != null)
                handler(this, e);
            //ContextMenuRequested?.Invoke(this, e);
        }
        private void OnPrintToPdfCompletedIntern(object sender, PrintToPdfCompleteEventArgs e)
        {
            OnPrintToPdfCompleted(e);
        }

        private void OnContextMenuRequestedIntern(object sender, ContextMenuRequestedEventArgs e)
        {
            OnContextMenuRequested(e);
        }

        private void OnWebResourceResponseReceivedIntern(object sender, WebResourceResponseReceivedEventArgs e)
        {
            OnWebResourceResponseReceived(e);
        }

        private void OnDOMContentLoadedIntern(object sender, DOMContentLoadedEventArgs e)
        {
            OnDomContentLoaded(e);
        }

        private void OnFrameNavigationCompletedIntern(object sender, NavigationCompletedEventArgs e)
        {
            OnFrameNavigationCompleted(e);
        }

        private void OnZoomFactorChangedIntern(object sender, WebView2EventArgs e)
        {

            OnZoomFactorChanged(e);
        }

        private void OnScriptToExecuteOnDocumentCreatedIntern(object sender, AddScriptToExecuteOnDocumentCreatedCompletedEventArgs e)
        {
            OnScriptToExecuteOnDocumentCreatedCompleted(e);
        }

        private void OnWindowCloseRequestedIntern(object sender, WebView2EventArgs e)
        {
            OnWindowCloseRequested(e);
        }

        private void OnWebMessageReceivedIntern(object sender, WebMessageReceivedEventArgs e)
        {
            OnWebMessageReceived(e);
        }

        private void OnScriptDialogOpeningIntern(object sender, ScriptDialogOpeningEventArgs e)
        {
            OnScriptDialogOpening(e);
        }

        private void OnProcessFailedIntern(object sender, ProcessFailedEventArgs e)
        {
            OnProcessFailed(e);
        }

        private void OnExecuteScriptCompletedIntern(object sender, ExecuteScriptCompletedEventArgs e)
        {
            OnExecuteScriptCompleted(e);

        }

        private void OnFrameNavigationStartingIntern(object sender, NavigationStartingEventArgs e)
        {
            OnFrameNavigationStarting(e);
        }

        private void OnPermissionRequestedIntern(object sender, PermissionRequestedEventArgs e)
        {
            OnPermissionRequested(e);
        }

        private void OnNewWindowRequestedIntern(object sender, NewWindowRequestedEventArgs e)
        {
            OnNewWindowRequested(e);
        }

        private void OnDocumentTitleChangedIntern(object sender, WebView2EventArgs e)
        {
            OnDocumentTitleChanged(e);
        }

        private void OnContainsFullScreenElementChangedIntern(object sender, WebView2EventArgs e)
        {
            OnContainsFullScreenElementChanged(e);
        }

        private void OnMoveFocusRequestedIntern(object sender, MoveFocusRequestedEventArgs e)
        {
            OnMoveFocusRequested(e);
        }

        private void OnLostFocusIntern(object sender, WebView2EventArgs e)
        {
            OnLostFocus(e);
        }

        private void OnGotFocusIntern(object sender, WebView2EventArgs e)
        {
            OnGotFocus(e);
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

        private void OnHistoryChangedInternal(object sender, WebView2EventArgs e)
        {
            OnHistoryChanged(e);
        }

        private void OnSourceChangedInternal(object sender, SourceChangedEventArgs e)
        {
            OnSourceChanged(e);
        }

        private void OnContentLoadingIntern(object sender, ContentLoadingEventArgs e)
        {
            OnContentLoading(e);
        }

        private void OnNavigateStartIntern(object sender, NavigationStartingEventArgs e)
        {
            OnNavigateStart(e);
        }


        protected virtual void OnCreated()
        {
            Created?.Invoke(this, EventArgs.Empty);

        }

        protected virtual void OnBeforeCreate(BeforeCreateEventArgs e)
        {
            BeforeCreate?.Invoke(this, e);
        }

        protected virtual void OnNavigateStart(NavigationStartingEventArgs e)
        {
            NavigateStart?.Invoke(this, e);
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
            NavigationCompleted?.Invoke(this, e);
        }

        protected virtual void OnWebResourceRequested(WebResourceRequestedEventArgs e)
        {
            WebResourceRequested?.Invoke(this, e);
        }

        protected virtual void OnAcceleratorKeyPressed(AcceleratorKeyPressedEventArgs e)
        {
            AcceleratorKeyPressed?.Invoke(this, e);
        }

        protected virtual void OnGotFocus(WebView2EventArgs e)
        {
            GotFocus?.Invoke(this, e);
        }

        protected virtual void OnLostFocus(WebView2EventArgs e)
        {
            LostFocus?.Invoke(this, e);
        }

        protected virtual void OnMoveFocusRequested(MoveFocusRequestedEventArgs e)
        {
            MoveFocusRequested?.Invoke(this, e);
        }

        protected virtual void OnZoomFactorChanged(WebView2EventArgs e)
        {
            ZoomFactorChanged?.Invoke(this, e);
        }

        protected virtual void OnContainsFullScreenElementChanged(WebView2EventArgs e)
        {
            ContainsFullScreenElementChanged?.Invoke(this, e);
        }

        protected virtual void OnDocumentTitleChanged(WebView2EventArgs e)
        {
            DocumentTitleChanged?.Invoke(this, e);
        }

        protected virtual void OnNewWindowRequested(NewWindowRequestedEventArgs e)
        {
            NewWindowRequested?.Invoke(this, e);
        }

        protected virtual void OnPermissionRequested(PermissionRequestedEventArgs e)
        {
            PermissionRequested?.Invoke(this, e);
        }

        protected virtual void OnFrameNavigationStarting(NavigationStartingEventArgs e)
        {
            FrameNavigationStarting?.Invoke(this, e);
        }

        protected virtual void OnExecuteScriptCompleted(ExecuteScriptCompletedEventArgs e)
        {
            ExecuteScriptCompleted?.Invoke(this, e);
        }

        protected virtual void OnProcessFailed(ProcessFailedEventArgs e)
        {
            ProcessFailed?.Invoke(this, e);
        }

        protected virtual void OnScriptDialogOpening(ScriptDialogOpeningEventArgs e)
        {
            ScriptDialogOpening?.Invoke(this, e);
        }

        protected virtual void OnWebMessageReceived(WebMessageReceivedEventArgs e)
        {
            WebMessageReceived?.Invoke(this, e);
        }

        protected virtual void OnWindowCloseRequested(WebView2EventArgs e)
        {
            WindowCloseRequested?.Invoke(this, e);
        }

        protected virtual void OnScriptToExecuteOnDocumentCreatedCompleted(AddScriptToExecuteOnDocumentCreatedCompletedEventArgs e)
        {
            ScriptToExecuteOnDocumentCreatedCompleted?.Invoke(this, e);
        }

        protected virtual void OnFrameNavigationCompleted(NavigationCompletedEventArgs e)
        {
            FrameNavigationCompleted?.Invoke(this, e);
        }

        protected virtual void OnNewBrowserVersionAvailable(WebView2EventArgs e)
        {
            NewBrowserVersionAvailable?.Invoke(this, e);
        }

        protected virtual void OnBeforeEnvironmentCompleted(EnvironmentCompletedHandlerArgs e)
        {
            BeforeEnvironmentCompleted?.Invoke(this, e);
        }

        protected virtual void OnDomContentLoaded(DOMContentLoadedEventArgs e)
        {
            DOMContentLoaded?.Invoke(this, e);
        }

        protected virtual void OnWebResourceResponseReceived(WebResourceResponseReceivedEventArgs e)
        {


            WebResourceResponseReceived?.Invoke(this, e);
        }

        protected virtual void OnFrameCreated(FrameCreatedEventArgs e)
        {
            FrameCreated?.Invoke(this, e);
        }

        protected virtual void OnDownloadStarting(DownloadStartingEventArgs e)
        {
            DownloadStarting?.Invoke(this, e);
        }

        protected virtual void OnRasterizationScaleChanged(WebView2EventArgs e)
        {
            RasterizationScaleChanged?.Invoke(this, e);
        }

        protected virtual void OnCompositionControllerCompleted(CompositionControllerCompletedEventArgs e)
        {
            CompositionControllerCompleted?.Invoke(this, e);
        }

        protected virtual void OnClientCertificateRequested(ClientCertificateRequestedEventArgs e)
        {
            ClientCertificateRequested?.Invoke(this, e);
        }

        protected virtual void OnCompoisitionControllerCursorChanged(CursorChangedEventArgs e)
        {
            CompoisitionControllerCursorChanged?.Invoke(this, e);
        }

        protected virtual void OnBrowserProcessExited(BrowserProcessExitedEventArgs e)
        {
            BrowserProcessExited?.Invoke(this, e);
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

        protected virtual void OnBasicAuthenticationRequested(BasicAuthenticationRequestedEventArgs e)
        {
            BasicAuthenticationRequested?.Invoke(this, e);
        }

        protected virtual void OnPrintToPdfCompleted(PrintToPdfCompleteEventArgs e)
        {
            PrintToPdfCompleted?.Invoke(this, e);
        }
        public WebView2Profile Profile
        {
            get
            {
                if (this.WebView == null)
                    return null;
                return this.WebView.Profile;
            }
        }

        public void OpenDefaultDownloadDialog()
        {
            this.WebView?.OpenDefaultDownloadDialog();
        }

        public WebView2SharedBuffer CreateSharedBuffer(ulong size)
        {
            return this.Environment.CreateSharedBuffer(size);
        }

        public void PostSharedBufferToScript(WebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson)
        {
            this.WebView.PostSharedBufferToScript(sharedBuffer.ToInterface(), access, additionalDataAsJson);
        }

        public async Task<WebView2ExecuteScriptResult> ExecuteScriptWithResultAsync(string javaScript)
        {
            return await this.WebView.ExecuteScriptWithResultAsync(javaScript);
        }

        public void AddRemoteObject(string name, object obj)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be empty");
            if(this._RemoteObjects.ContainsKey(name))
                throw new ArgumentException("Name already exists");

            object localObject = obj;
            
#pragma warning disable CA1416 // Plattformkompatibilität überprüfen
            

#pragma warning restore CA1416 // Plattformkompatibilität überprüfen
            this._RemoteObjects.Add(name, localObject);

            var localObjectPtr = obj;

            this.WebView.AddRemoteObject(name, localObjectPtr);
        }

        public void RemoveRemoteObject(string name)
        {
            this.WebView.RemoveRemoteObject(name);
        }
    }
}
