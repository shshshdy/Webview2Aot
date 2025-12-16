using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Environment6Shim : CoreWebView2Environment5Shim//, ICoreWebView2Environment6
    {
        private ComObjectHolder<ICoreWebView2Environment6> _Environment;
        private ICoreWebView2Environment6 Environment
        {
            get
            {
                if (_Environment == null)
                {
                    Debug.Print(nameof(CoreWebView2Environment6Shim) + "." + nameof(Environment) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Environment6Shim) + "." + nameof(Environment) + " is null");

                }
                return _Environment.Interface;
            }
            set => _Environment = new ComObjectHolder<ICoreWebView2Environment6>(value);
        }
        public CoreWebView2Environment6Shim(ICoreWebView2Environment6 environment) : base(environment)
        {
            Environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        [return: MarshalAs(UnmanagedType.Interface)]
        public ICoreWebView2PrintSettings CreatePrintSettings()
        {
            return Environment.CreatePrintSettings();
        }
        private bool _IsDisposed;
        protected override void Dispose(bool disposing)
        {
            if (_IsDisposed) return;
            if (disposing)
            {
                _Environment = null;
                _IsDisposed = true;
            }
            base.Dispose(disposing);
        }
    }
}
