using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2_12Shim : CoreWebView2_11Shim
    {
        private ComObjectHolder<ICoreWebView2_12> _WebView;
        private ICoreWebView2_12 WebView
        {
            get
            {
                if (this._WebView == null)
                {
                    Debug.Print(nameof(CoreWebView2_12Shim) + "." + nameof(this.WebView) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2_12Shim) + "." + nameof(this.WebView) + " is null");

                }
                return this._WebView.Interface;
            }
            set => this._WebView = new ComObjectHolder<ICoreWebView2_12>(value);
        }

        public CoreWebView2_12Shim(ICoreWebView2_12 webView) : base(webView)
        {
            this.WebView = webView ?? throw new ArgumentNullException(nameof(webView));
        }



        public void add_StatusBarTextChanged([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token)
        {
            this.WebView.add_StatusBarTextChanged(eventHandler, out token);
        }

        public void remove_StatusBarTextChanged([In] EventRegistrationToken token)
        {
            this.WebView.remove_StatusBarTextChanged(token);
        }

        public string StatusBarText => this.WebView.GetStatusBarText();
    }
}
