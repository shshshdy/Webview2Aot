using CoreWindowsWrapper;
using Diga.Core.Api.Win32;
using Diga.NativeControls.WebBrowser;
using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using WebviewTestAot;

namespace WebviewTestAot
{

    public class RpcData
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
    }
    public class Rpc
    {
        public Guid id { get; set; }
        public string? bufferType { get; set; }

        public List<RpcData> data { get; set; } = new List<RpcData>();

    }

    [JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Rpc))]
    [JsonSerializable(typeof(RpcData))]
    public partial class RpcContext : JsonSerializerContext
    {

    }
    public class WebViewCreateEventArgs : EventArgs
    {
        public string Url { get; set; }
        public string MonitoringUrl { get; }
        public WebViewCreateEventArgs(string url, string monitoringUrl)
        {
            this.Url = url;
            this.MonitoringUrl = monitoringUrl;
        }
    }

    class BrowserWindow : NativeWindow
    {

        public event EventHandler<WebViewCreateEventArgs>? WebViewCreate;
        private NativeTimer? _Timer;
        private NativeWebBrowser? _Browser;
        protected override void InitControls()
        {
            base.InitControls();
            this.Text = "WebBrowser";
            this.Name = "BrowserWindow";
            this.Width = 600;
            this.Height = 400;
            this.StatusBar = false;

            this.StartUpPosition = WindowsStartupPosition.Maximized;
            Guid guid = Guid.NewGuid();
            this._Browser = new NativeWebBrowser
            {
                Width = this.Width,
                Height = this.Height,
                Url = $"https://{guid.ToString()}/",
                MonitoringUrl = $"https://{guid.ToString()}/",
                MonitoringFolder = ".\\wwwroot",
                EnableMonitoring = true,
                AreDevToolsEnabled = true,
                AreDefaultContextMenusEnabled = true,
                IsStatusBarEnabled = false,
                UserDataFolder = Path.Combine(AppContext.BaseDirectory, "data")

            };
            this._Timer = new NativeTimer
            {
                Interval = 100,
                Enabled = true,
            };
            this._Timer.Tick += Timer_Tick;
            this._Browser.WebViewCreated += webView1_Created;

            this._Browser.WebResourceRequested += webView1_WebResouceRequested;
            this._Browser.NavigationCompleted += webView1_NavigationCompleted;
            this._Browser.NavigationStart += webView1_NavigationStart;
            this._Browser.AcceleratorKeyPressed += webView1_AcceleratorKeyPressed;
            this._Browser.WebMessageReceived += webView1_WebMessageReceived;
            this._Browser.DownloadStarting += WebView1_DownloadStarting;
            this._Browser.ServerCertificateErrorDetected += WebView1_ServerCertificateErrorDetected;

            this.Controls.Add(this._Browser);
            this.Controls.Add(this._Timer);

        }

        private void WebView1_ServerCertificateErrorDetected(object? sender, ServerCertificateErrorDetectedEventArgs e)
        {
            if (e.ServerCertificate.Issuer == Program.ServerPrivateCertAllow)
            {
                e.Action = COREWEBVIEW2_SERVER_CERTIFICATE_ERROR_ACTION.COREWEBVIEW2_SERVER_CERTIFICATE_ERROR_ACTION_ALWAYS_ALLOW;

            }
        }

        private void WebView1_DownloadStarting(object? sender, DownloadStartingEventArgs e)
        {
            var opt = e.DownloadOperation;
            opt.BytesReceivedChanged += Opt_BytesReceivedChanged;
            opt.EstimatedEndTimeChanged += Opt_EstimatedEndTimeChanged;
            opt.StateChanged += Opt_StateChanged;
        }

        private void Opt_StateChanged(object? sender, WebView2EventArgs e)
        {
            if (sender is WebView2DownloadOperation opt)
            {
                Debug.Print("Download State Changed:" + opt.State.ToString());
            }
        }

        private void Opt_EstimatedEndTimeChanged(object? sender, WebView2EventArgs e)
        {
            if (sender is WebView2DownloadOperation opt)
            {
                Debug.Print("EstimatedEndTime:" + opt.EstimatedEndTime);

            }
        }

        private void Opt_BytesReceivedChanged(object? sender, WebView2EventArgs e)
        {
            if (sender is WebView2DownloadOperation opt)
            {
                Debug.WriteLine($"BytesReceived: {opt.BytesReceived}");
            }
        }

        private bool IsTickRunning = false;
        private bool DoSendMessage = false;
        private string MessageToSend = string.Empty;
        private void Timer_Tick(object? sender, EventArgs e)
        {

            if (IsTickRunning)
            {
                return;
            }

            IsTickRunning = true;

            if (DoSendMessage)
            {
                if (!string.IsNullOrEmpty(MessageToSend))
                {

                }
                SendMessage();
                DoSendMessage = false;
            }


            IsTickRunning = false;
        }

        private void webView1_WebMessageReceived(object? sender, WebMessageReceivedEventArgs e)
        {

            string message = e.TryGetWebMessageAsString();
            if (message != null)
            {
                switch (message)
                {
                    case "DIGA_GET_ONE_TIME_SHARED_BUFFER":
                        {
                            DoSendMessage = true;
                        }
                        break;
                    default: break;
                }
            }
        }

        private void SendMessage()
        {
            //            string data = @$"{{
            //""id"":""{Guid.NewGuid()}"",
            //""bufferType"":""bufferType1"",
            //""data"":[]
            //}}
            //";

            //            JsonNode node = JsonNode.Parse(data);
            if (this._Browser == null) return;
            Rpc rpc = new Rpc();
            rpc.id = Guid.NewGuid();
            rpc.bufferType = "bufferType1";
            rpc.data.Add(new RpcData { Name = "Wert1", Value = "100" });
            var options = new JsonSerializerOptions { TypeInfoResolver = RpcContext.Default };
            string jsString = JsonSerializer.Serialize(rpc, RpcContext.Default.Rpc);// "";//node.ToJsonString();
            byte[] arr = Encoding.UTF8.GetBytes(jsString);

            var sharedBuffer = this._Browser.CreateSharedBuffer((uint)arr.Length);
            var strem = sharedBuffer.OpenStream();
            strem.Write(arr, 0, arr.Length);

            this._Browser.PostSharedBufferToScript(sharedBuffer, Diga.WebView2.Interop.COREWEBVIEW2_SHARED_BUFFER_ACCESS.COREWEBVIEW2_SHARED_BUFFER_ACCESS_READ_ONLY, jsString);
            sharedBuffer.Close();
        }

        private const uint NoneStyle = 385941504;

        private const uint NoneExStyle = 327680;
        private uint OldStyle;
        private uint OldExStyle;
        private void webView1_AcceleratorKeyPressed(object? sender, AcceleratorKeyPressedEventArgs e)
        {
            uint currentStyle = GetWindowStyle();
            uint currentExStyle = GetWindowExStyle();
            if (e.KeyEventKind == Diga.WebView2.Interop.COREWEBVIEW2_KEY_EVENT_KIND.COREWEBVIEW2_KEY_EVENT_KIND_KEY_DOWN && e.VirtualKey == VirtualKeys.VK_F11)
            {
                if (currentStyle == NoneStyle && currentExStyle == NoneExStyle)
                {
                    SetWindowState(WindowState.Normal);
                    UpdateStyle(this.OldStyle);
                    UpdateExStyle(this.OldExStyle);
                    UpdateWidow();
                }
                else
                {
                    this.OldStyle = currentStyle;
                    this.OldExStyle = currentExStyle;
                    SetWindowState(WindowState.Maximized);
                    UpdateStyle(NoneStyle);
                    UpdateExStyle(NoneExStyle);
                    UpdateWidow();
                    IntPtr hMon = User32.MonitorFromWindow(this.Handle, MonitorDefaultFlags.MONITOR_DEFAULTTONEAREST);
                    if (hMon != IntPtr.Zero)
                    {
                        MonitorInfo info = new MonitorInfo();

                        info.cbSize = 40;
                        if (User32.GetMonitorInfo(hMon, ref info))
                        {
                            Rect r = info.rcMonitor;
                            this.Left = r.Left;
                            this.Top = r.Top;
                            this.Width = r.Width;
                            this.Height = r.Height;
                        }
                    }
                }
            }
        }

        private void webView1_Created(object? sender, EventArgs e)
        {
            if (_Browser == null) return;
            if (_Timer == null) return;
            this._Browser.OpenDefaultDownloadDialog();
            WebViewCreateEventArgs args = new WebViewCreateEventArgs(this._Browser.Url, this._Browser.MonitoringUrl);
            WebViewCreate?.Invoke(this, args);
            if (args.Url != this._Browser.Url)
            {
                this._Browser.Url = args.Url;
            }
            this._Timer.StartTimer();
        }

        private void webView1_NavigationStart(object? sender, NavigationStartingEventArgs e)
        {
            //IntPtr h = Diga.Core.Api.Win32.User32.GetDlgItem(this.Handle, 100);
            //if (h != IntPtr.Zero)
            //{
            //    Diga.Core.Api.Win32.User32.SendMessage(h, (int)Diga.Core.Api.Win32.WindowsMessages.WM_SETTEXT, IntPtr.Zero, e.uri);
            //}

        }

        private void webView1_NavigationCompleted(object? sender, NavigationCompletedEventArgs e)
        {
            //
        }

        private void webView1_WebResouceRequested(object? sender, WebResourceRequestedEventArgs e)
        {
            //IntPtr h = Diga.Core.Api.Win32.User32.GetDlgItem(this.Handle, 100);
            //if (h != IntPtr.Zero)
            //{
            //    Diga.Core.Api.Win32.User32.SendMessage(h,(int) Diga.Core.Api.Win32.WindowsMessages.WM_SETTEXT,IntPtr.Zero, e.Request.Uri) ;
            //}

            Debug.WriteLine(e.Request.Uri);
            Debug.WriteLine(e.Request.Method);
        }
    }
}
