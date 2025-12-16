using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2HttpHeadersCollectionIteratorShim :  IDisposable
    {
        private ComObjectHolder<ICoreWebView2HttpHeadersCollectionIterator> _HeadersIterator;
        private bool _IsDesposed;

        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private ICoreWebView2HttpHeadersCollectionIterator HeadersIterator
        {
            get
            {
                if (_HeadersIterator == null)
                {
                    Debug.Print(nameof(CoreWebView2HttpHeadersCollectionIteratorShim) + "=>" + nameof(HeadersIterator) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2HttpHeadersCollectionIteratorShim) + "=>" + nameof(HeadersIterator) + " is null");
                }
                return _HeadersIterator.Interface;
            }
            set
            {
                _HeadersIterator = new ComObjectHolder<ICoreWebView2HttpHeadersCollectionIterator>(value);
            }
        }
        public CoreWebView2HttpHeadersCollectionIteratorShim(ICoreWebView2HttpHeadersCollectionIterator headersIterator)
        {
            HeadersIterator = headersIterator ?? throw new ArgumentNullException(nameof(headersIterator));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_IsDesposed)
            {
                if (disposing)
                {
                    handle.Dispose();
                    _HeadersIterator = null;
                }


                _IsDesposed = true;
            }
        }


        ~CoreWebView2HttpHeadersCollectionIteratorShim()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: false);
        }
        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void GetCurrentHeader([MarshalAs(UnmanagedType.LPWStr)] out string name, [MarshalAs(UnmanagedType.LPWStr)] out string value)
        {
            this.HeadersIterator.GetCurrentHeader(out name, out value);
        }

        public int HasCurrentHeader => this.HeadersIterator.GetHasCurrentHeader();

        public int MoveNext()
        {
            return this.HeadersIterator.MoveNext();
        }
    }
}
