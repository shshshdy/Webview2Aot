using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace Diga.WebView2.Wrapper.shim
{



    public class CoreWebView2HttpRequestHeadersShim : IDisposable//, ICoreWebView2HttpRequestHeaders
    {
        private ComObjectHolder<ICoreWebView2HttpRequestHeaders> _Iface;
        private bool _IsDesposed;

        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private SafeHandle handle = new SafeFileHandle(nint.Zero, true);
        public CoreWebView2HttpRequestHeadersShim(ICoreWebView2HttpRequestHeaders iface)
        {
            Iface = iface ?? throw new ArgumentNullException(nameof(iface));
        }

        private ICoreWebView2HttpRequestHeaders Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2HttpRequestHeadersShim) + "=>" + nameof(Iface) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2HttpRequestHeadersShim) + "=>" + nameof(Iface) + " is null");
                }

                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2HttpRequestHeaders>(value);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_IsDesposed)
            {
                if (disposing)
                {
                    handle.Dispose();
                    _Iface = null;
                }

                _IsDesposed = true;
            }
        }

        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        [return: MarshalAs(UnmanagedType.LPWStr)]
        public string GetHeader([In, MarshalAs(UnmanagedType.LPWStr)] string name)
        {
            return Iface.GetHeader(name);
        }

        [return: MarshalAs(UnmanagedType.Interface)]
        public ICoreWebView2HttpHeadersCollectionIterator GetHeaders([In, MarshalAs(UnmanagedType.LPWStr)] string name)
        {
            return Iface.GetHeaders(name);
        }

        public int Contains([In, MarshalAs(UnmanagedType.LPWStr)] string name)
        {
            return Iface.Contains(name);
        }

        public void SetHeader([In, MarshalAs(UnmanagedType.LPWStr)] string name, [In, MarshalAs(UnmanagedType.LPWStr)] string value)
        {
            Iface.SetHeader(name, value);
        }

        public void RemoveHeader([In, MarshalAs(UnmanagedType.LPWStr)] string name)
        {
            Iface.RemoveHeader(name);
        }

        [return: MarshalAs(UnmanagedType.Interface)]
        public ICoreWebView2HttpHeadersCollectionIterator GetIterator()
        {
            return Iface.GetIterator();
        }
    }
}
