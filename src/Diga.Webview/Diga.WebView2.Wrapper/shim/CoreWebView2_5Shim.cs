using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public class CoreWebView2_5Shim : CoreWebView2_4Shim
    {
        private ComObjectHolder<ICoreWebView2_5> _WebView;
        private ICoreWebView2_5 WebView
        {
            get
            {
                if (this._WebView == null)
                {
                    Debug.Print(nameof(CoreWebView2_5Shim) + "." + nameof(this.WebView) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2_5Shim) + "." + nameof(this.WebView) + " is null");

                }
                return this._WebView.Interface;
            }
            set => this._WebView = new ComObjectHolder<ICoreWebView2_5>(value);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CoreWebView2_5Shim(ICoreWebView2_5 webView) : base(webView)
        {
            this.WebView = webView ?? throw new ArgumentNullException(nameof(webView));
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void add_ClientCertificateRequested([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token)
        {
            this.WebView.add_ClientCertificateRequested(eventHandler, out token);
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void remove_ClientCertificateRequested([In] EventRegistrationToken token)
        {
            try
            {
                this.WebView.remove_ClientCertificateRequested(token);
            }
            catch (AccessViolationException accessViolation)
            {

                Debug.Print("AccessViolation Exception:" + accessViolation.ToString());
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
