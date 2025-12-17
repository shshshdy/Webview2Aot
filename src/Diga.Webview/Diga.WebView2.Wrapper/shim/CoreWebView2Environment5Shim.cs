using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Environment5Shim : CoreWebView2Environment4Shim
    {
        private ComObjectHolder<ICoreWebView2Environment5> _Environment;
        private ICoreWebView2Environment5 Environment
        {
            get
            {
                if (_Environment == null)
                {
                    Debug.Print(nameof(CoreWebView2Environment5Shim) + "." + nameof(Environment) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Environment5Shim) + "." + nameof(Environment) + " is null");

                }
                return _Environment.Interface;
            }
            set => _Environment = new ComObjectHolder<ICoreWebView2Environment5>(value);
        }

        public CoreWebView2Environment5Shim(ICoreWebView2Environment5 environment) : base(environment)
        {
            Environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public void add_BrowserProcessExited([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2BrowserProcessExitedEventHandler eventHandler, out EventRegistrationToken token)
        {
            Environment.add_BrowserProcessExited(eventHandler, out token);
        }

        public void remove_BrowserProcessExited([In] EventRegistrationToken token)
        {
            Environment.remove_BrowserProcessExited(token);
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
