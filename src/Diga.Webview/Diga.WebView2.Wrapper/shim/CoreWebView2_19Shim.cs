using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2_19Shim : CoreWebView2_18Shim//, ICoreWebView2_19
    {
        private ComObjectHolder<ICoreWebView2_19> _WebView;
        private ICoreWebView2_19 WebView
        {
            get
            {
                if (this._WebView == null)
                {
                    Debug.Print(nameof(CoreWebView2_19Shim) + "." + nameof(this.WebView) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2_19Shim) + "." + nameof(this.WebView) + " is null");

                }
                return this._WebView.Interface;
            }
            set => this._WebView = new ComObjectHolder<ICoreWebView2_19>(value);
        }

        public CoreWebView2_19Shim(ICoreWebView2_19 webView) : base(webView)
        {
            this.WebView = webView ?? throw new ArgumentNullException(nameof(webView));
        }

        public COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL MemoryUsageTargetLevel { get => this.WebView.GetMemoryUsageTargetLevel(); set => this.WebView.SetMemoryUsageTargetLevel(value); }
    }
}
