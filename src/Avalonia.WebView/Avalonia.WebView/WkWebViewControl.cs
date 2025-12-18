using System;
using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Platform;

#if !WINDOWS
namespace Avalonia.WebView
{
    public class WKWebView : IWebViewControl
    {
        // P/Invoke 导入动态库接口（macOS下动态库前缀为lib，后缀为.dylib）
        [DllImport("libWKWebViewBridge.dylib", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CreateWKWebView(IntPtr parentView, int x, int y, int width, int height);

        [DllImport("libWKWebViewBridge.dylib", CallingConvention = CallingConvention.Cdecl)]
        private static extern void WKWebViewLoadURL(string urlStr);

        [DllImport("libWKWebViewBridge.dylib", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DestroyWKWebView();

        private IntPtr _webViewPtr;

        // 初始化WKWebView并嵌入Avalonia窗口
        public string? Url { get; set; }

        public void Initialize(Window parentWindow, int x, int y, int width, int height)
        {
            if (OperatingSystem.IsMacOS())
            {
                // 获取Avalonia窗口的原生NSView句柄
                var handle = parentWindow.TryGetPlatformHandle() as IMacOSTopLevelPlatformHandle;
                IntPtr nsViewPtr = handle?.NSView ?? IntPtr.Zero;
                
                if (nsViewPtr != IntPtr.Zero)
                {
                    _webViewPtr = CreateWKWebView(nsViewPtr, x, y, width, height);
                    if(!string.IsNullOrEmpty(Url))
                        WKWebViewLoadURL(Url);
                }
            }
        }

        // 加载URL
        public void LoadUrl(string url)
        {
            WKWebViewLoadURL(url);
        }

        // 释放资源
        public void Dispose()
        {
            DestroyWKWebView();
            _webViewPtr = IntPtr.Zero;
        }
    }
}
#endif