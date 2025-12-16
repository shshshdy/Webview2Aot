using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2_18Shim : CoreWebView2_17Shim//, ICoreWebView2_18
    {
        private ComObjectHolder<ICoreWebView2_18> _WebView;

        private ICoreWebView2_18 WebView
        {
            get
            {
                if (this._WebView == null)
                {
                    Debug.Print(nameof(CoreWebView2_18Shim) + "." + nameof(this.WebView) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2_18Shim) + "." + nameof(this.WebView) + " is null");

                }
                return this._WebView.Interface;
            }
            set => this._WebView = new ComObjectHolder<ICoreWebView2_18>(value);
        }

        public CoreWebView2_18Shim(ICoreWebView2_18 webView) : base(webView)
        {
            this.WebView = webView ?? throw new ArgumentNullException(nameof(webView));
        }

        public void add_LaunchingExternalUriScheme([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2LaunchingExternalUriSchemeEventHandler eventHandler, out EventRegistrationToken token)
        {
            this.WebView.add_LaunchingExternalUriScheme(eventHandler, out token);
        }

        public void remove_LaunchingExternalUriScheme([In] EventRegistrationToken token)
        {
            this.WebView.remove_LaunchingExternalUriScheme(token);
        }
    }
}
