using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2_20Shim : CoreWebView2_19Shim//, ICoreWebView2_20
    {
        private ComObjectHolder<ICoreWebView2_20> _Iface;
        private ICoreWebView2_20 Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2_20Shim) + "=>" + nameof(Iface) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2_20Shim) + "=>" + nameof(Iface) + " is null");
                }
                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2_20>(value);
        }
        public CoreWebView2_20Shim(ICoreWebView2_20 iface) : base(iface)
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

        public uint FrameId => this.Iface.GetFrameId();
    }
}
