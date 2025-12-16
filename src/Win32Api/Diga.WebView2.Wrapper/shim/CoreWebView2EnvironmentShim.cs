using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2EnvironmentShim : IDisposable
    {
        private ComObjectHolder<ICoreWebView2Environment> _Environment;
        private bool _IsDisposed;
        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private readonly SafeHandle handle = new SafeFileHandle(nint.Zero, true);
        private ICoreWebView2Environment Environment
        {
            get
            {
                if (_Environment == null)
                {
                    Debug.Print(nameof(CoreWebView2EnvironmentShim) + "." + nameof(Environment) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2EnvironmentShim) + "." + nameof(Environment) + " is null");

                }
                return _Environment.Interface;
            }
            set => _Environment = new ComObjectHolder<ICoreWebView2Environment>(value);
        }
        public CoreWebView2EnvironmentShim(ICoreWebView2Environment environment)
        {
            Environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }
        public void CreateCoreWebView2Controller(nint ParentWindow, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler)
        {
            Environment.CreateCoreWebView2Controller(ParentWindow, handler);
        }

        [return: MarshalAs(UnmanagedType.Interface)]
        public ICoreWebView2WebResourceResponse CreateWebResourceResponse([In, MarshalAs(UnmanagedType.Interface)] IStream Content, [In] int StatusCode, [In, MarshalAs(UnmanagedType.LPWStr)] string ReasonPhrase, [In, MarshalAs(UnmanagedType.LPWStr)] string Headers)
        {
            return Environment.CreateWebResourceResponse(Content, StatusCode, ReasonPhrase, Headers);
        }

        public string BrowserVersionString => Environment.GetBrowserVersionString();

        public void add_NewBrowserVersionAvailable([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler, out EventRegistrationToken token)
        {
            Environment.add_NewBrowserVersionAvailable(eventHandler, out token);
        }

        public void remove_NewBrowserVersionAvailable([In] EventRegistrationToken token)
        {
            Environment.remove_NewBrowserVersionAvailable(token);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_IsDisposed)
            {
                if (disposing)
                {
                    handle.Dispose();
                    _Environment = null;
                }

                _IsDisposed = true;
            }
        }



        public void Dispose()
        {

            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
