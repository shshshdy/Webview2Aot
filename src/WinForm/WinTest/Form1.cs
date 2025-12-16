namespace WinTest
{
    public partial class Form1 : Form
    {
        Label _label;
        public Form1()
        {
            InitializeComponent();
            var button = new Button
            {
                Size = new Size(60, 20),
                Text = "≤‚ ‘",
                Parent = this
            };
            button.Click += Button_Click;

            _label = new Label
            {
                Text = "clicked",
                Parent = this,
                Location = new Point(40, 40)
            };
            _ = CreateView();


        }

        private async Task CreateView()
        {
            try
            {
                string? envFolder = null;
                string userDataFolder = Path.Combine(AppContext.BaseDirectory, "Data", "Cache");
                var path = Path.Combine(AppContext.BaseDirectory, "Data", "Web");
                if (Directory.Exists(path))
                {
                    envFolder = path;
                }
                if (!Directory.Exists(userDataFolder))
                {
                    Directory.CreateDirectory(userDataFolder);
                }
#if !DEBUG
                Microsoft.Web.WebView2.Core.CoreWebView2Environment.SetLoaderDllFolderPath(Path.Combine(AppContext.BaseDirectory, "Data","Lib"));
#endif
                var environment = await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(envFolder, userDataFolder);
                var webview = new Microsoft.Web.WebView2.WinForms.WebView2()
                {
                    Parent = this,
                    Size = new Size(800, 300),
                    Location = new Point(0, 81),
                };
                await webview.EnsureCoreWebView2Async(environment);
                webview.Source = new Uri("https://www.baidu.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int _count = 0;
        private void Button_Click(object? sender, EventArgs e)
        {
            _count++;
            _label.Text = "clicked" + _count;
        }
    }
}
