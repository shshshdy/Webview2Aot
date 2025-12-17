using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2_13Shim : CoreWebView2_12Shim
    {
        private ComObjectHolder<ICoreWebView2_13> _WebView;
        private ICoreWebView2_13 WebView
        {
            get
            {
                if (this._WebView == null)
                {
                    Debug.Print(nameof(CoreWebView2_13Shim) + "." + nameof(this.WebView) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2_13Shim) + "." + nameof(this.WebView) + " is null");

                }
                return this._WebView.Interface;
            }
            set => this._WebView = new ComObjectHolder<ICoreWebView2_13>(value);
        }

        public CoreWebView2_13Shim(ICoreWebView2_13 webView) : base(webView)
        {
            this.WebView = webView ?? throw new ArgumentNullException(nameof(webView));
        }

        public ICoreWebView2Profile Profile => this.WebView.GetProfile();
    }
}
