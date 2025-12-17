using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2_14Shim : CoreWebView2_13Shim
    {
        private ComObjectHolder<ICoreWebView2_14> _WebView;
        private ICoreWebView2_14 WebView
        {
            get
            {
                if (this._WebView == null)
                {
                    Debug.Print(nameof(CoreWebView2_14Shim) + "." + nameof(this.WebView) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2_14Shim) + "." + nameof(this.WebView) + " is null");

                }
                return this._WebView.Interface;
            }
            set => this._WebView = new ComObjectHolder<ICoreWebView2_14>(value);
        }
        public CoreWebView2_14Shim(ICoreWebView2_14 webView) : base(webView)
        {
            this.WebView = webView ?? throw new ArgumentNullException(nameof(webView));
        }

        public void add_ServerCertificateErrorDetected([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2ServerCertificateErrorDetectedEventHandler eventHandler, out EventRegistrationToken token)
        {
            this.WebView.add_ServerCertificateErrorDetected(eventHandler, out token);
        }

        public void remove_ServerCertificateErrorDetected([In] EventRegistrationToken token)
        {
            this.WebView.remove_ServerCertificateErrorDetected(token);
        }

        public void ClearServerCertificateErrorActions([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler)
        {
            this.WebView.ClearServerCertificateErrorActions(handler);
        }
    }
}
