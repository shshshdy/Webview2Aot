using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;

namespace Diga.WebView2.Wrapper
{

    public class WebResourceRequest : CoreWebView2WebResourceRequestShim
    {
        public WebResourceRequest(ICoreWebView2WebResourceRequest iface) : base(iface)
        {

        }

        public string Uri => uri;
        public new string Method
        {
            get => base.Method;
            set => base.Method = value;
        }
        private ManagedIStream _ManagedStream;
        public new Stream Content
        {
            get
            {
                if (base.Content == null) return null;
                return new ComStream(base.Content);
            }
            set
            {
                if(this._ManagedStream ==  null)
                {
                    this._ManagedStream = new ManagedIStream(ref value);
                }
                base.Content = _ManagedStream;
            }
        }

        public new HttpRequestHeaders Headers
        {
            get
            {
                if (base.Headers == null) return null;
                return new HttpRequestHeaders(base.Headers);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_ManagedStream?.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
