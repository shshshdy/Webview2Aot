using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Environment3Shim : CoreWebView2Environment2Shim //, ICoreWebView2Environment3
    {
        private ComObjectHolder<ICoreWebView2Environment3> _Environment;

        private ICoreWebView2Environment3 Environment
        {
            get
            {
                if (_Environment == null)
                {
                    Debug.Print(nameof(CoreWebView2Environment3Shim) + "." + nameof(Environment) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Environment3Shim) + "." + nameof(Environment) + " is null");

                }
                return _Environment.Interface;
            }
            set { _Environment = new ComObjectHolder<ICoreWebView2Environment3>(value); }
        }


        public CoreWebView2Environment3Shim(ICoreWebView2Environment3 environment) : base(environment)
        {
            if (environment == null)
                throw new ArgumentNullException(nameof(environment));

            Environment = environment;
        }

        public void CreateCoreWebView2CompositionController(nint ParentWindow, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler)
        {
            Environment.CreateCoreWebView2CompositionController(ParentWindow, handler);
        }

        [return: MarshalAs(UnmanagedType.Interface)]
        public ICoreWebView2PointerInfo CreateCoreWebView2PointerInfo()
        {
            return Environment.CreateCoreWebView2PointerInfo();
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
