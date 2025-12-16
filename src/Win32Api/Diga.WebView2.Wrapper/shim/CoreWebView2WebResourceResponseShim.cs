using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;

using System.Runtime.InteropServices;
namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2WebResourceResponseShim : IDisposable
    {
        private ComObjectHolder<ICoreWebView2WebResourceResponse> _Iface;
        private bool _IsDesposed;

        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public CoreWebView2WebResourceResponseShim(ICoreWebView2WebResourceResponse iface)
        {
            Iface = iface ?? throw new ArgumentNullException(nameof(iface));
        }

        private ICoreWebView2WebResourceResponse Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2WebResourceResponseShim) + "=>" + nameof(Iface) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2WebResourceResponseShim) + "=>" + nameof(Iface) + " is null");
                }

                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2WebResourceResponse>(value);
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

        public IStream Content { get => this.Iface.GetContent(); set => this.Iface.SetContent(value); }

        public ICoreWebView2HttpResponseHeaders Headers => this.Iface.GetHeaders();

        public int StatusCode { get => this.Iface.GetStatusCode(); set => this.Iface.SetStatusCode(value); }
        public string ReasonPhrase { get => this.Iface.GetReasonPhrase(); set => this.Iface.SetReasonPhrase(value); }

        public ICoreWebView2WebResourceResponse ToInterface() => this.Iface;
    }
}
