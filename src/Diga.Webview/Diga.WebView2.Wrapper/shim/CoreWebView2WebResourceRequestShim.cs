using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{



    public class CoreWebView2WebResourceRequestShim : IDisposable
    {
        private ComObjectHolder<ICoreWebView2WebResourceRequest> _Resource;
        private bool _IsDisposed;
        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);


        private ICoreWebView2WebResourceRequest Resource
        {
            get
            {
                if (this._Resource == null)
                {
                    Debug.Print(nameof(CoreWebView2WebResourceRequestShim) + "." + nameof(this.Resource) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2WebResourceRequestShim) + "." + nameof(this.Resource) + " is null");

                }
                return this._Resource.Interface;
            }
            set => this._Resource = new ComObjectHolder<ICoreWebView2WebResourceRequest>(value);
        }

        public CoreWebView2WebResourceRequestShim(ICoreWebView2WebResourceRequest resource)
        {
            this.Resource = resource ?? throw new ArgumentNullException(nameof(resource));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._IsDisposed)
            {
                if (disposing)
                {
                    this.handle.Dispose();
                    this._Resource = null;
                }

                this._IsDisposed = true;
            }
        }



        public void Dispose()
        {

            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public string uri { get => this.Resource.Geturi(); set => this.Resource.Seturi (value); }
        public string Method { get => this.Resource.GetMethod(); set => this.Resource.SetMethod (value); }
        public IStream Content { get => this.Resource.GetContent(); set => this.Resource.SetContent(value); }

        public ICoreWebView2HttpRequestHeaders Headers => this.Resource.GetHeaders();

        public ICoreWebView2WebResourceRequest ToInterface()
        {
            return _Resource.Interface;
        }
    }
}
