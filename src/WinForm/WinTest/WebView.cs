using Diga.WebView2.Wrapper;
using Diga.WebView2.Wrapper.EventArguments;
using System.ComponentModel;
using System.Diagnostics;

namespace WinTest
{
    public partial class WebView : UserControl
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Uri? Url { get; set; } = new Uri("https://www.bing.com");

        private WebView2Control? _WebViewControl;

        private bool _WasCreated = false;

        public WebView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            CreateWebViewControl(this.Handle);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (this._WebViewControl != null && this._WasCreated)
            {
                this._WebViewControl.DockToParent();
            }
        }
        private void CreateWebViewControl(nint parentHandle)
        {
            try
            {
                var cache = Path.Combine(AppContext.BaseDirectory, "Data", "Cache");
                this._WebViewControl = new WebView2Control(parentHandle, string.Empty, cache, string.Empty);
                WireEvents();
            }
            catch (Exception ex)
            {

                Debug.Print(ex.ToString());
            }

        }
        private void WireEvents()
        {
            if (this._WebViewControl != null)
            {
                this._WebViewControl.Created += OnCreated;
                this._WebViewControl.BeforeCreate += OnBeforeCreate;
                this._WebViewControl.ServerCertificateErrorDetected += OnServerCertificateErrorDetected;
            }
        }

        private void OnServerCertificateErrorDetected(object? sender, ServerCertificateErrorDetectedEventArgs e)
        {
            Debug.Print("ServerCertificateErrorDetected: " + e.ErrorStatus.ToString());
        }

        private void OnBeforeCreate(object? sender, BeforeCreateEventArgs e)
        {
            //Do something with e.Settings
            e.Settings.IsScriptEnabled = true;
            e.Settings.IsWebMessageEnabled = true;
            e.Settings.AreDefaultScriptDialogsEnabled = true;
            e.Settings.AreDevToolsEnabled = true;
        }

        private void OnCreated(object? sender, EventArgs e)
        {
            if (this._WebViewControl != null)
            {

                if (this.Url != null)
                {
                    this._WebViewControl.NavigateToUri(this.Url);
                }
            }
            this._WasCreated = true;
        }


    }
}
