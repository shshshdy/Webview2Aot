using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Settings5Shim : CoreWebView2Settings4Shim
    {
        private ComObjectHolder<ICoreWebView2Settings5> _Settings;
        private ICoreWebView2Settings5 Settings
        {
            get
            {
                if (_Settings == null)
                {
                    Debug.Print(nameof(CoreWebView2Settings5Shim) + "." + nameof(Settings) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Settings5Shim) + "." + nameof(Settings) + " is null");

                }
                return _Settings.Interface;
            }
            set => _Settings = new ComObjectHolder<ICoreWebView2Settings5>(value);
        }
        public CoreWebView2Settings5Shim(ICoreWebView2Settings5 settings) : base(settings)
        {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public int IsPinchZoomEnabled { get => Settings.GetIsPinchZoomEnabled(); set => Settings.SetIsPinchZoomEnabled(value); }
        private bool _IsDisposed;
        protected override void Dispose(bool disposing)
        {
            if (_IsDisposed) return;
            if (disposing)
            {
                _Settings = null;
                _IsDisposed = true;
            }


            base.Dispose(disposing);
        }
    }
}
