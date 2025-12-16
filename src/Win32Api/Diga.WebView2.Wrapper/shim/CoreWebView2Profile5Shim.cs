using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Profile5Shim : CoreWebView2Profile4Shim
    {
        private ComObjectHolder<ICoreWebView2Profile5> _Iface;
        private ICoreWebView2Profile5 Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2Profile5Shim) + "=>" + nameof(Iface) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2Profile5Shim) + "=>" + nameof(Iface) + " is null");
                }
                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2Profile5>(value);
        }
        public CoreWebView2Profile5Shim(ICoreWebView2Profile5 iface) : base(iface)
        {
            Iface = iface ?? throw new ArgumentNullException(nameof(iface));
        }

        private bool _IsDisposed;
        protected override void Dispose(bool disposing)
        {
            if (_IsDisposed) return;
            if (disposing)
            {
                _Iface = null;
                _IsDisposed = true;
            }
            base.Dispose(disposing);
        }
        public ICoreWebView2CookieManager CookieManager => this.Iface.GetCookieManager();
    }
}
