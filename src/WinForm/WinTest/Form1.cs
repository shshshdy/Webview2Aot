


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
                Text = "label1",
                Parent = this,
                Location = new Point(40, 40)
            };
            new Label
            {
                Text = AppContext.BaseDirectory,
                Parent = this,
                Location = new Point(40, 80)
            };
            _ = CreateView();


        }

        private async Task CreateView()
        {
            try
            {
#if DEBUG
                await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(@"C:\install\webview2");
#else
                var path = Path.Combine(AppContext.BaseDirectory, "webview2");
                if (Directory.Exists(path))
                {
                    await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(path);
                }
#endif
                var webview = new Microsoft.Web.WebView2.WinForms.WebView2()
                {
                    Source = new Uri("https://www.baidu.com"),
                    Parent = this,
                    Size = new Size(800, 300),
                    Location = new Point(0, 81),
                };
                await Task.CompletedTask;
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
