using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Environment4Shim : CoreWebView2Environment3Shim //, ICoreWebView2Environment4
    {
        private ComObjectHolder<ICoreWebView2Environment4> _Environment;
        private ICoreWebView2Environment4 Environment
        {
            get
            {
                if (_Environment == null)
                {
                    Debug.Print(nameof(CoreWebView2Environment4Shim) + "." + nameof(Environment) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Environment4Shim) + "." + nameof(Environment) + " is null");

                }
                return _Environment.Interface;
            }
            set => _Environment = new ComObjectHolder<ICoreWebView2Environment4>(value);
        }

        public CoreWebView2Environment4Shim(ICoreWebView2Environment4 environment) : base(environment)
        {
            Environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        [return: MarshalAs(UnmanagedType.IUnknown)]
        public object GetProviderForHwnd(nint hwnd)
        {
            return Environment.GetProviderForHwnd(hwnd);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _Environment = null;
            }
            base.Dispose(disposing);
        }
    }
}
