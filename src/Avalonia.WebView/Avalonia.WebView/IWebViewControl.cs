using System;
using Avalonia.Controls;

namespace Avalonia.WebView;

public interface IWebViewControl:IDisposable
{
    string? Url { get; set; }
    void Initialize(Window parentWindow, int x, int y, int width, int height);
    void LoadUrl(string url);
}