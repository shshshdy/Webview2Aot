using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.ComponentModel;
using System.Diagnostics;


namespace Diga.WebView2.Wrapper.shim
{
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public class CoreWebView2_6Shim : CoreWebView2_5Shim
    {
        private ComObjectHolder<ICoreWebView2_6> _WebView;

        private ICoreWebView2_6 WebView
        {
            get
            {
                if (this._WebView == null)
                {
                    Debug.Print(nameof(CoreWebView2_6Shim) + "." + nameof(this.WebView) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2_6Shim) + "." + nameof(this.WebView) + " is null");

                }
                return this._WebView.Interface;
            }
            set => this._WebView = new ComObjectHolder<ICoreWebView2_6>(value);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CoreWebView2_6Shim(ICoreWebView2_6 webView) : base(webView)
        {
            this.WebView = webView ?? throw new ArgumentNullException(nameof(webView));
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OpenTaskManagerWindow()
        {
            this.WebView.OpenTaskManagerWindow();
        }
        private bool _IsDisposed;
        protected override void Dispose(bool disposing)
        {
            if (this._IsDisposed) return;
            if (disposing)
            {
                this._WebView = null;
                this._IsDisposed = true;
            }
            base.Dispose(disposing);
        }
    }
}
