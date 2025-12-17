using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2_8Shim : CoreWebView2_7Shim
    {
        private ComObjectHolder<ICoreWebView2_8> _WebView;
        private ICoreWebView2_8 WebView
        {
            get
            {
                if (this._WebView == null)
                {
                    Debug.Print(nameof(CoreWebView2_8Shim) + "." + nameof(this.WebView) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2_8Shim) + "." + nameof(this.WebView) + " is null");

                }
                return this._WebView.Interface;
            }
            set => this._WebView = new ComObjectHolder<ICoreWebView2_8>(value);
        }
        public CoreWebView2_8Shim(ICoreWebView2_8 webView) : base(webView)
        {
            this.WebView = webView ?? throw new ArgumentNullException(nameof(webView));
        }

        public void add_IsMutedChanged([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token)
        {
            this.WebView.add_IsMutedChanged(eventHandler, out token);
        }

        public void remove_IsMutedChanged([In] EventRegistrationToken token)
        {
            this.WebView.remove_IsMutedChanged(token);
        }

        public int IsMuted { get => this.WebView.GetIsMuted(); set => this.WebView.SetIsMuted(value); }

        public void add_IsDocumentPlayingAudioChanged([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token)
        {
            this.WebView.add_IsDocumentPlayingAudioChanged(eventHandler, out token);
        }

        public void remove_IsDocumentPlayingAudioChanged([In] EventRegistrationToken token)
        {
            this.WebView.remove_IsDocumentPlayingAudioChanged(token);
        }

        public int IsDocumentPlayingAudio => this.WebView.GetIsDocumentPlayingAudio();

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
