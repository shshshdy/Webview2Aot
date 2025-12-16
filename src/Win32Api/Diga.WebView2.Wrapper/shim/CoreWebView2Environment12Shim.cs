using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Environment12Shim : CoreWebView2Environment11Shim //, ICoreWebView2Environment12
    {
        private ComObjectHolder<ICoreWebView2Environment12> _Environment;
        private ICoreWebView2Environment12 Environment
        {
            get
            {
                if (_Environment == null)
                {
                    Debug.Print(nameof(CoreWebView2Environment12Shim) + "." + nameof(Environment) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Environment12Shim) + "." + nameof(Environment) + " is null");

                }
                return _Environment.Interface;
            }
            set => _Environment = new ComObjectHolder<ICoreWebView2Environment12>(value);
        }
        public CoreWebView2Environment12Shim(ICoreWebView2Environment12 environment) :
            base(environment)
        {
            Environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        [return: MarshalAs(UnmanagedType.Interface)]
        public ICoreWebView2SharedBuffer CreateSharedBuffer([In] ulong Size)
        {
            return Environment.CreateSharedBuffer(Size);
        }
    }
}
