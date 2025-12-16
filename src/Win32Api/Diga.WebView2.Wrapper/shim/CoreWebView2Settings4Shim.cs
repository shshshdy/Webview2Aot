using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Settings4Shim : CoreWebView2Settings3Shim
    {
        private ComObjectHolder<ICoreWebView2Settings4> _Settings;
        private ICoreWebView2Settings4 Settings
        {
            get
            {
                if (_Settings == null)
                {
                    Debug.Print(nameof(CoreWebView2Settings4Shim) + "." + nameof(Settings) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Settings4Shim) + "." + nameof(Settings) + " is null");

                }
                return _Settings.Interface;
            }
            set => _Settings = new ComObjectHolder<ICoreWebView2Settings4>(value);
        }
        public CoreWebView2Settings4Shim(ICoreWebView2Settings4 settings) : base(settings)
        {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public int IsPasswordAutosaveEnabled { get => Settings.GetIsPasswordAutosaveEnabled(); set => Settings.SetIsPasswordAutosaveEnabled(value); }
        public int IsGeneralAutofillEnabled { get => Settings.GetIsGeneralAutofillEnabled(); set => Settings.SetIsGeneralAutofillEnabled(value); }
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
