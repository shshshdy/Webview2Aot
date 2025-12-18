#if WINDOWS
using Avalonia.Controls;
using Diga.WebView2.Wrapper;
using System;
using System.Diagnostics;
using System.IO;

namespace Avalonia.WebView;

public class Webview2Control:IWebViewControl
{
    public string? Url { get; set; } = "https://www.bing.com";

    private WebView2Control? _WebViewControl;

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
        if (_WebViewControl != null)
        {
            _WebViewControl.Created += OnCreated;
          
        }
    }
    private void OnCreated(object? sender, EventArgs e)
    {
        if (_WebViewControl != null)
        {

            if (Url != null)
            {
                _WebViewControl.NavigateToUri(new Uri(Url));
            }
        }
    }

    public void Dispose()
    {
        _WebViewControl?.Dispose();
    }

    public void Initialize(Window parentWindow, int x, int y, int width, int height)
    {
        var handle = parentWindow.TryGetPlatformHandle();

        CreateWebViewControl(handle?.Handle ?? IntPtr.Zero);
    }

    public void LoadUrl(string url)
    {
        _WebViewControl?.NavigateToUri(new Uri(url));
    }
}
#endif
