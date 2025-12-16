using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Profile3Shim : CoreWebView2Profile2Shim
    {
        private ComObjectHolder<ICoreWebView2Profile3> _Iface;
        private ICoreWebView2Profile3 Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2Profile3Shim) + "=>" + nameof(Iface) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2Profile3Shim) + "=>" + nameof(Iface) + " is null");
                }
                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2Profile3>(value);
        }
        public CoreWebView2Profile3Shim(ICoreWebView2Profile3 iface) : base(iface)
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


        public COREWEBVIEW2_TRACKING_PREVENTION_LEVEL PreferredTrackingPreventionLevel { get => this.Iface.GetPreferredTrackingPreventionLevel(); set => this.Iface.SetPreferredTrackingPreventionLevel(value); }
    }
}
