using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{



    public class CoreWebView2NewWindowRequestedEventArgs2Shim : CoreWebView2NewWindowRequestedEventArgsShim
    {
        private ComObjectHolder<ICoreWebView2NewWindowRequestedEventArgs2> _Args;
        private ICoreWebView2NewWindowRequestedEventArgs2 Args
        {
            get
            {
                if (_Args == null)
                {
                    Debug.Print(nameof(CoreWebView2NewWindowRequestedEventArgsShim) + "=>" + nameof(Args) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2NewWindowRequestedEventArgsShim) + "=>" + nameof(Args) + " is null");
                }
                return _Args.Interface;
            }
            set => _Args = new ComObjectHolder<ICoreWebView2NewWindowRequestedEventArgs2>(value);
        }
        public CoreWebView2NewWindowRequestedEventArgs2Shim(ICoreWebView2NewWindowRequestedEventArgs2 args) : base(args)
        {
            Args = args ?? throw new ArgumentNullException(nameof(args));
        }
        public string name => Args.Getname();

        private bool _IsDisposed;
        protected override void Dispose(bool disposing)
        {
            if (_IsDisposed) return;
            if (disposing)
            {
                _Args = null;
            }

            _IsDisposed = true;
            base.Dispose(disposing);
        }
    }
}
