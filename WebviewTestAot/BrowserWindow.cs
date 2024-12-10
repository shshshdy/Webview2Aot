using System.Diagnostics;
using System.Runtime.CompilerServices;
using CoreWindowsWrapper;
using Diga.Core.Api.Win32;
using Diga.NativeControls.WebBrowser;
using Diga.WebView2.Wrapper.EventArguments;

namespace WebviewTestAot
{
    public class BrowserWindow : NativeWindow
    {
        public string UserDataFolder
        {
            get => _Browser.UserDataFolder; set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _Browser.UserDataFolder = value;
                }
            }
        }
        public string EnvFolder
        {
            get => _Browser.EnvFolder;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _Browser.EnvFolder = value;
                }
            }
        }
        private string _url;
        public string Url
        {
            get => _url; 
            set
            {
                if (_url == value) return;
                if (!string.IsNullOrEmpty(value))
                {
                    _url = value;
                    if (_loaded)
                    {
                        _Browser.Navigate(value);
                    }
                }
            }
        }
        public BrowserWindow()
        {

        }

        private bool _loaded = false;
        private NativeWebBrowser _Browser;
        private string envFolder;

        protected override void InitControls()
        {
            this.Text = "WebBrowser";
            this.Name = "BrowserWindow";
            this.StatusBar = false;
            this.IconFile = "Browser.ico";
            this.Width = 800;
            this.Height = 400;
            this.Left = 0;
            this.Top = 20;
            this.StartUpPosition = WindowsStartupPosition.Normal;
            this.SetWindowState(WindowState.Normal);
            this._Browser = new NativeWebBrowser()
            {
                Width = this.Width,
                Height = this.Height,
                //IsStatusBarEnabled = true,
                //DefaultContextMenusEnabled = false,
                //DevToolsEnabled = false,
                //EnableMonitoring = false,
                //MonitoringFolder = ".\\wwwroot",
                //MonitoringUrl = "http://localhost:1/",
                //AutoDock = true
            };
            this.Create += Browser_Create;
            this._Browser.DocumentTitleChanged += OnDocumentTitleChanged;
            this._Browser.NavigationStart += OnNavigationStart;
            this._Browser.NavigationCompleted += OnNaviationCompleted;
            this._Browser.WebResourceRequested += OnWebResourceRequested;
            this.Controls.Add(this._Browser);
        }


        private void Browser_Create(object? sender, CreateEventArgs e)
        {
            var style = GetWindowStyle();
            var tempStyle = style & ~WindowStylesConst.WS_CAPTION & ~WindowStylesConst.WS_SYSMENU & ~WindowStylesConst.WS_SIZEBOX;
            UpdateStyle(tempStyle);
            var exStyle = GetWindowExStyle();
            var tempExStyle = exStyle & ~WindowStylesConst.WS_EX_WINDOWEDGE & ~WindowStylesConst.WS_EX_DLGMODALFRAME;
            UpdateExStyle(tempExStyle);
            StatusBar = false;
            _Browser.Navigate(this.Url);
            _loaded = true;
        }
        private void OnWebResourceRequested(object sender, WebResourceRequestedEventArgs e)
        {
            Debug.Print(e.Request.Uri);
        }

        private void OnNaviationCompleted(object sender, NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
                this.Text = e.IsSuccess + "";
            else
                this.Text = "Navigation-Error=>" + e.GetErrorText();

        }
        private void OnNavigationStart(object sender, NavigationStartingEventArgs e)
        {

            this.Text = "Start-Navigate" + e.uri;
        }
        private void OnDocumentTitleChanged(object sender, WebView2EventArgs e)
        {

        }

        protected override void OnSize(SizeEventArgs e)
        {
            if (e.Width == 0) return;
            base.OnSize(e);

            this._Browser.Left = e.X;
            this._Browser.Top = e.Y;
            this._Browser.Width = e.Width;
            this._Browser.Height = e.Height;
            this._Browser.DoDock();
        }
    }
}