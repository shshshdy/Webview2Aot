using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{


    public class CoreWebView2Profile6Shim : CoreWebView2Profile5Shim
    {
        private ComObjectHolder<ICoreWebView2Profile6> _Iface;
        private ICoreWebView2Profile6 Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2Profile6Shim) + "=>" + nameof(Iface) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2Profile6Shim) + "=>" + nameof(Iface) + " is null");
                }
                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2Profile6>(value);
        }
        public CoreWebView2Profile6Shim(ICoreWebView2Profile6 iface) : base(iface)
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
        public int IsPasswordAutosaveEnabled { get => this.Iface.GetIsPasswordAutosaveEnabled(); set => this.Iface.SetIsPasswordAutosaveEnabled(value); }
        public int IsGeneralAutofillEnabled { get => this.Iface.GetIsGeneralAutofillEnabled(); set => this.Iface.SetIsGeneralAutofillEnabled( value); }
    }
}
