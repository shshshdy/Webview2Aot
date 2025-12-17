using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2_15Shim : CoreWebView2_14Shim
    {
        private ComObjectHolder<ICoreWebView2_15> _WebView;
        private ICoreWebView2_15 WebView
        {
            get
            {
                if (this._WebView == null)
                {
                    Debug.Print(nameof(CoreWebView2_15Shim) + "." + nameof(this.WebView) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2_15Shim) + "." + nameof(this.WebView) + " is null");

                }
                return this._WebView.Interface;
            }
            set => this._WebView = new ComObjectHolder<ICoreWebView2_15>(value);
        }

        public ICoreWebView2_15 GetInterface()
        {
            return this.WebView;
        }
        public CoreWebView2_15Shim(ICoreWebView2_15 webView) : base(webView)
        {
            this.WebView = webView ?? throw new ArgumentNullException(nameof(webView));
        }

        public void add_FaviconChanged([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2FaviconChangedEventHandler eventHandler, out EventRegistrationToken token)
        {
            this.WebView.add_FaviconChanged(eventHandler, out token);
        }

        public void remove_FaviconChanged([In] EventRegistrationToken token)
        {
            this.WebView.remove_FaviconChanged(token);
        }

        public string FaviconUri => this.WebView.GetFaviconUri();

        public void GetFavicon([In] COREWEBVIEW2_FAVICON_IMAGE_FORMAT format, [In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2GetFaviconCompletedHandler completedHandler)
        {
            this.WebView.GetFavicon(format, completedHandler);
        }
    }
}
