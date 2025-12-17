using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Settings8Shim : CoreWebView2Settings7Shim//, ICoreWebView2Settings8
    {
        private ComObjectHolder<ICoreWebView2Settings8> _Settings;

        private ICoreWebView2Settings8 Settings
        {
            get
            {
                if (_Settings == null)
                {
                    Debug.Print(nameof(CoreWebView2Settings8Shim) + "." + nameof(Settings) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Settings8Shim) + "." + nameof(Settings) + " is null");

                }
                return _Settings.Interface;
            }
            set => _Settings = new ComObjectHolder<ICoreWebView2Settings8>(value);
        }
        public CoreWebView2Settings8Shim(ICoreWebView2Settings8 settings) : base(settings)
        {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }
        public int IsReputationCheckingRequired { get => Settings.GetIsReputationCheckingRequired(); set => Settings.SetIsReputationCheckingRequired(value); }

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
