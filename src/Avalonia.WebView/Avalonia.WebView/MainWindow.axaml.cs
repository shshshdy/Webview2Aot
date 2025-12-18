using System;
using Avalonia.Controls;

namespace Avalonia.WebView;

public partial class MainWindow : Window
{
    private IWebViewControl? _webview;
    public MainWindow()
    {
        InitializeComponent();
        Loaded += MainWindow_Loaded;
        Closed += MainWindow_Closed;
    }
    private void MainWindow_Loaded(object? sender, Interactivity.RoutedEventArgs e)
    {
        // 初始化WKWebView（嵌入窗口，坐标x=10, y=10，宽800，高600）
#if WINDOWS
        _webview = new Webview2Control();
#else
        _webview =  new WKWebView();
#endif
        _webview.Url = "https://www.bing.com";
        _webview.Initialize(this, 0, 0, 800, 600);
        
    }

    private void MainWindow_Closed(object? sender, EventArgs e)
    {
        // 释放资源
        _webview?.Dispose();
    }
}