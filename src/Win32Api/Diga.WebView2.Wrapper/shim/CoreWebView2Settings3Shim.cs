using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Settings3Shim : CoreWebView2Settings2Shim
    {
        private ComObjectHolder<ICoreWebView2Settings3> _Settings;
        private ICoreWebView2Settings3 Settings
        {
            get
            {
                if (_Settings == null)
                {
                    Debug.Print(nameof(CoreWebView2Settings3Shim) + "." + nameof(Settings) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Settings3Shim) + "." + nameof(Settings) + " is null");

                }
                return _Settings.Interface;
            }
            set => _Settings = new ComObjectHolder<ICoreWebView2Settings3>(value);
        }
        public CoreWebView2Settings3Shim(ICoreWebView2Settings3 settings) : base(settings)
        {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public int AreBrowserAcceleratorKeysEnabled { get => Settings.GetAreBrowserAcceleratorKeysEnabled(); set => Settings.SetAreBrowserAcceleratorKeysEnabled(value); }
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
