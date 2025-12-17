using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2_11Shim : CoreWebView2_10Shim
    {
        private ComObjectHolder<ICoreWebView2_11> _WebView;
        private ICoreWebView2_11 WebView
        {
            get
            {
                if (this._WebView == null)
                {
                    Debug.Print(nameof(CoreWebView2_11Shim) + "." + nameof(this.WebView) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2_11Shim) + "." + nameof(this.WebView) + " is null");

                }
                return this._WebView.Interface;
            }
            set => this._WebView = new ComObjectHolder<ICoreWebView2_11>(value);
        }

        public CoreWebView2_11Shim(ICoreWebView2_11 webView) : base(webView)
        {
            this.WebView = webView ?? throw new ArgumentNullException(nameof(webView));
        }

        public void CallDevToolsProtocolMethodForSession([In, MarshalAs(UnmanagedType.LPWStr)] string sessionId, [In, MarshalAs(UnmanagedType.LPWStr)] string methodName, [In, MarshalAs(UnmanagedType.LPWStr)] string parametersAsJson, [In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler)
        {
            this.WebView.CallDevToolsProtocolMethodForSession(sessionId, methodName, parametersAsJson, handler);
        }

        public void add_ContextMenuRequested([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token)
        {
            this.WebView.add_ContextMenuRequested(eventHandler, out token);
        }

        public void remove_ContextMenuRequested([In] EventRegistrationToken token)
        {
            this.WebView.remove_ContextMenuRequested(token);
        }
    }
}
