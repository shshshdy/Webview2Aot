using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Settings7Shim : CoreWebView2Settings6Shim
    {
        private ComObjectHolder<ICoreWebView2Settings7> _Settings;
        private ICoreWebView2Settings7 Settings
        {
            get
            {
                if (_Settings == null)
                {
                    Debug.Print(nameof(CoreWebView2Settings7Shim) + "." + nameof(Settings) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Settings7Shim) + "." + nameof(Settings) + " is null");

                }
                return _Settings.Interface;
            }
            set => _Settings = new ComObjectHolder<ICoreWebView2Settings7>(value);
        }

        public CoreWebView2Settings7Shim(ICoreWebView2Settings7 settings) : base(settings)
        {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

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

        public COREWEBVIEW2_PDF_TOOLBAR_ITEMS HiddenPdfToolbarItems { get => Settings.GetHiddenPdfToolbarItems(); set => Settings.SetHiddenPdfToolbarItems(value); }
    }
}
