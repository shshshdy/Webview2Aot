using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using CoreWindowsWrapper;
using CoreWindowsWrapper.Tools;
using Diga.Core.Api.Win32;
using Diga.Core.Api.Win32.GDI;
using Diga.NativeControls.WebBrowser;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace WebviewTestAot
{
    public partial class MainForm : NativeWindow
    {

        public MainForm()
        {
            InitializeComponent();
            Create += MainForm_Create;
        }

        private void MainForm_Create(object? sender, CreateEventArgs e)
        {
            if (string.IsNullOrEmpty(_webveiw.BrowserVersion))
            {
                //TODO 下载 webview2 runtime 到 ./Data/Web目录
            }
        }
    }


    public partial class MainForm
    {
        NativeWebBrowser _webveiw;
        NativeBitmap _bitmap;
        protected void InitializeComponent()
        {

            //Opacity = true;
            //ShowBodyFrame = false;
            Text = "xxx";
            Width = 800;
            Height = 600;
            StartUpPosition = WindowsStartupPosition.CenterScreen;

            var button = new NativeButton
            {
                Location = new Diga.Core.Api.Win32.Point(20, 20),
                Width = 200,
                Height = 20,
                Left = 0,
                Top = 0,
                Text = "ok",
            };
            button.Clicked += (s, e) =>
            {
                _webveiw.Height += 50;
            };
            Controls.Add(button);
            var env = Path.Combine(AppContext.BaseDirectory, "Data", "Web");
            if (!Directory.Exists(env))
            {
                env = string.Empty;
            }
            _webveiw = new NativeWebBrowser()
            {
                Url = "https://www.bing.com",
                UserDataFolder = Path.Combine(AppContext.BaseDirectory, "Data", "Cache"),
                EnvFolder = env,
                Width = 800,
                Height = 400,
                Top = 20,
                Dock = false
            };
            Controls.Add(_webveiw);
            var path = Path.Combine(AppContext.BaseDirectory, "Data", "image", "remove.png");
            var bytes = File.ReadAllBytes(path);
            _bitmap = new NativeBitmap
            {
                Source = bytes.ToUint(),
                Left = 20,
                Top = 421
            };
            _bitmap.Clicked += (s, e) =>
            {
                var result = MessageBox.Show(this.Handle, "确认退出吗?", "提示", MessageBoxOptions.OkCancel);
                if (result == MessageBoxResult.Ok)
                {
                    Close();
                }
            };
            Controls.Add(_bitmap);
            path = Path.Combine(AppContext.BaseDirectory, "Data", "image", "ok.bmp");
            var bitmap = new NativeBitmap
            {
                Source = path,
                Left = 400,
                Top = 421
            };

            bitmap.DblClicked += (s, e) => MessageBox.Show("double click");
            Controls.Add(bitmap);
        }

        protected override void OnBeforeCreate(BeforeWindowCreateEventArgs e)
        {
            e.Styles.Style = Diga.Core.Api.Win32.WindowStylesConst.WS_DLGFRAME |
                             Diga.Core.Api.Win32.WindowStylesConst.WS_SYSMENU;
        }
    }
}
