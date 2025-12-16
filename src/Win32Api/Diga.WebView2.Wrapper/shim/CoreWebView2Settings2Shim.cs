using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Settings2Shim : CoreWebView2SettingsShim
    {
        private ComObjectHolder<ICoreWebView2Settings2> _Settings;

        private ICoreWebView2Settings2 Settings
        {
            get
            {
                if (_Settings == null)
                {
                    Debug.Print(nameof(CoreWebView2Settings2Shim) + "." + nameof(Settings) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Settings2Shim) + "." + nameof(Settings) + " is null");

                }
                return _Settings.Interface;
            }
            set
            {
                _Settings = new ComObjectHolder<ICoreWebView2Settings2>(value);
            }
        }

        public CoreWebView2Settings2Shim(ICoreWebView2Settings2 settings) : base(settings)
        {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public string UserAgent { get => Settings.GetUserAgent(); set => Settings.SetUserAgent(value); }
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
