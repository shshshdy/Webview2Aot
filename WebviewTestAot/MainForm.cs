using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using CoreWindowsWrapper;
using CoreWindowsWrapper.Tools;
using Diga.Core.Api.Win32;
using Diga.Core.Api.Win32.GDI;
using Diga.NativeControls.WebBrowser;


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
            Opacity = true;
            //ShowBodyFrame = false;
        }

        private void OkButton_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {



        }
    }


    public partial class MainForm
    {
        NativeWebBrowser _webveiw;
        NativeBitmap _bitmap;
        protected void InitializeComponent()
        {
            BackColor = ColorTool.Yellow;
            this.Text = "xxx";
            this.Width = 800;
            this.Height = 600;
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
                //_webveiw.Url = "https://www.baidu.com";
            };
            this.StartUpPosition = WindowsStartupPosition.CenterScreen;
            _webveiw = new NativeWebBrowser()
            {
                Url = "https://www.bing.com",
                UserDataFolder = Path.Combine(AppContext.BaseDirectory, "Data", "Cache"),
                Width = 800,
                Height = 400,
                Top = 20,
                Dock = false
            };
            Controls.Add(button);
            Controls.Add(_webveiw);
            var path = Path.Combine(AppContext.BaseDirectory, "Data", "image", "remove.bmp");
            var bytes = File.ReadAllBytes(Path.Combine(AppContext.BaseDirectory, "Data", "image", "remove.bmp"));
            _bitmap = new NativeBitmap
            {
                Data = bytes,
                //BitMap = path,
                Left = 20,
                Top = 421
            };
            _bitmap.Clicked += (s, e) => Debug.WriteLine("click");
            _bitmap.DblClicked += (s, e) => MessageBox.Show("double click");
            Controls.Add(_bitmap);

            path = Path.Combine(AppContext.BaseDirectory, "Data", "image", "ok.bmp");
            var bitmap = new NativeBitmap
            {
                //Data = bytes,
                BitMap = path,
                Left = 400,
                Top = 421
            };
            Controls.Add(bitmap);
        }

        protected override void OnBeforeCreate(BeforeWindowCreateEventArgs e)
        {
            e.Styles.Style = Diga.Core.Api.Win32.WindowStylesConst.WS_DLGFRAME |
                             Diga.Core.Api.Win32.WindowStylesConst.WS_SYSMENU;
        }
    }
}
