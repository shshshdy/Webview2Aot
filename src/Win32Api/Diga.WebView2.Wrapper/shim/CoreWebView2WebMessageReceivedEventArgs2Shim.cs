using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2WebMessageReceivedEventArgs2Shim : CoreWebView2WebMessageReceivedEventArgsShim
    {
        private ComObjectHolder<ICoreWebView2WebMessageReceivedEventArgs2> _Iface;

        private ICoreWebView2WebMessageReceivedEventArgs2 Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2WebMessageReceivedEventArgs2Shim) + "=>" + nameof(Iface) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2WebMessageReceivedEventArgs2Shim) + "=>" + nameof(Iface) + " is null");
                }

                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2WebMessageReceivedEventArgs2>(value);
        }

        public CoreWebView2WebMessageReceivedEventArgs2Shim(ICoreWebView2WebMessageReceivedEventArgs2 iface) : base(iface)
        {
            Iface = iface ?? throw new ArgumentNullException(nameof(iface));
        }
        private bool _IsDisposed;
        protected override void Dispose(bool disposing)
        {
            if (this._IsDisposed) return;
            if (disposing)
            {
                this._Iface = null;
                this._IsDisposed = true;
            }
            base.Dispose(disposing);
        }

        public ICoreWebView2ObjectCollectionView AdditionalObjects => Iface.GetAdditionalObjects();

    }
}
