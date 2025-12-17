using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CoreWebView2_7Shim : CoreWebView2_6Shim
    {
        private ComObjectHolder<ICoreWebView2_7> _WebView;
        private ICoreWebView2_7 WebView
        {
            get
            {
                if (this._WebView == null)
                {
                    Debug.Print(nameof(CoreWebView2_7Shim) + "." + nameof(this.WebView) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2_7Shim) + "." + nameof(this.WebView) + " is null");

                }
                return this._WebView.Interface;
            }
            set
            {
                this._WebView = new ComObjectHolder<ICoreWebView2_7>(value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CoreWebView2_7Shim(ICoreWebView2_7 webView) : base(webView)
        {
            this.WebView = webView ?? throw new ArgumentNullException(nameof(webView));
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void PrintToPdf([In, MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, [In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2PrintSettings printSettings, [In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2PrintToPdfCompletedHandler handler)
        {
            try
            {

                this.WebView.PrintToPdf(ResultFilePath, printSettings, handler);
            }
            catch (Exception e)
            {
                var ex = Marshal.GetExceptionForHR(e.HResult);
                Debug.Print(ex.Message);
            }

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
