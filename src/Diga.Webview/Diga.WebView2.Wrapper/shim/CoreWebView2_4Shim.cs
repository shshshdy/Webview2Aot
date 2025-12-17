using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public class CoreWebView2_4Shim : CoreWebView2_3Shim
    {
        private ComObjectHolder<ICoreWebView2_4> _WebView;

        private ICoreWebView2_4 WebView
        {
            get
            {
                if (this._WebView == null)
                {
                    Debug.Print(nameof(CoreWebView2_4Shim) + "." + nameof(this.WebView) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2_4Shim) + "." + nameof(this.WebView) + " is null");

                }
                return this._WebView.Interface;
            }
            set => this._WebView = new ComObjectHolder<ICoreWebView2_4>(value);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CoreWebView2_4Shim(ICoreWebView2_4 webView) : base(webView)
        {
            this.WebView = webView ?? throw new ArgumentNullException(nameof(webView));
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void add_FrameCreated([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token)
        {
            this.WebView.add_FrameCreated(eventHandler, out token);
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void remove_FrameCreated([In] EventRegistrationToken token)
        {
            this.WebView.remove_FrameCreated(token);
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void add_DownloadStarting([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token)
        {
            this.WebView.add_DownloadStarting(eventHandler, out token);
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void remove_DownloadStarting([In] EventRegistrationToken token)
        {
            try
            {
                this.WebView.remove_DownloadStarting(token);
            }
            catch (COMException comEx)
            {
                Debug.Print(nameof(remove_DownloadStarting) + " Exception" + comEx);

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
