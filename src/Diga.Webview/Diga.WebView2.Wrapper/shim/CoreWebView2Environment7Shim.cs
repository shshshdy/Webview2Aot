using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Environment7Shim : CoreWebView2Environment6Shim //, ICoreWebView2Environment7
    {
        private ComObjectHolder<ICoreWebView2Environment7> _Environment;
        private ICoreWebView2Environment7 Environment
        {
            get
            {
                if (_Environment == null)
                {
                    Debug.Print(nameof(CoreWebView2Environment7Shim) + "." + nameof(Environment) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Environment7Shim) + "." + nameof(Environment) + " is null");

                }
                return _Environment.Interface;
            }
            set { _Environment = new ComObjectHolder<ICoreWebView2Environment7>(value); }
        }

        public CoreWebView2Environment7Shim(ICoreWebView2Environment7 environment) : base(environment)
        {
            Environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public string UserDataFolder => Environment.GetUserDataFolder();
        private bool _IsDisposed;
        protected override void Dispose(bool disposing)
        {
            if (_IsDisposed) return;
            if (disposing)
            {
                _Environment = null;
                _IsDisposed = true;
            }
        }
    }
}
