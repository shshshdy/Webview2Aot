using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Environment11Shim : CoreWebView2Environment10Shim //, ICoreWebView2Environment11
    {
        private ComObjectHolder<ICoreWebView2Environment11> _Environment;

        private ICoreWebView2Environment11 Environment
        {
            get
            {
                if (_Environment == null)
                {
                    Debug.Print(nameof(CoreWebView2Environment11Shim) + "." + nameof(Environment) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Environment11Shim) + "." + nameof(Environment) + " is null");

                }
                return _Environment.Interface;
            }
            set => _Environment = new ComObjectHolder<ICoreWebView2Environment11>(value);
        }

        public CoreWebView2Environment11Shim(ICoreWebView2Environment11 environment) : base(environment)
        {
            Environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public string FailureReportFolderPath => Environment.GetFailureReportFolderPath();
    }
}
