using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Environment10Shim : CoreWebView2Environment9Shim //, ICoreWebView2Environment10
    {
        private ComObjectHolder<ICoreWebView2Environment10> _Environment;
        private ICoreWebView2Environment10 Environment
        {
            get
            {
                if (_Environment == null)
                {
                    Debug.Print(nameof(CoreWebView2Environment10Shim) + "." + nameof(Environment) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Environment10Shim) + "." + nameof(Environment) + " is null");

                }
                return _Environment.Interface;
            }
            set { _Environment = new ComObjectHolder<ICoreWebView2Environment10>(value); }
        }

        public CoreWebView2Environment10Shim(ICoreWebView2Environment10 environment) : base(environment)
        {
            Environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        [return: MarshalAs(UnmanagedType.Interface)]
        public ICoreWebView2ControllerOptions CreateCoreWebView2ControllerOptions()
        {
            return Environment.CreateCoreWebView2ControllerOptions();
        }

        public void CreateCoreWebView2ControllerWithOptions(nint ParentWindow, [In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2ControllerOptions options, [In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler)
        {
            Environment.CreateCoreWebView2ControllerWithOptions(ParentWindow, options, handler);
        }

        public void CreateCoreWebView2CompositionControllerWithOptions(nint ParentWindow, [In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2ControllerOptions options, [In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler)
        {
            Environment.CreateCoreWebView2CompositionControllerWithOptions(ParentWindow, options, handler);
        }
    }
}
