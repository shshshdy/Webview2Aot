using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;

namespace Diga.WebView2.Wrapper
{
    public class WebResourceResponse: CoreWebView2WebResourceResponseShim
    {
        public WebResourceResponse(ICoreWebView2WebResourceResponse args):base(args)
        {
            
        }
        private ComStream _ComStream;
        public new Stream Content
        {
            get
            {
                if (base.Content == null) 
                    return null;
                if(_ComStream != null)
                    _ComStream.Dispose();
                _ComStream = null;
                _ComStream = new ComStream(base.Content);
                return _ComStream;
            }
        }

        public new HttpResponseHeaders Headers
        {
            get
            {
                if(base.Headers == null) return null;
                return new HttpResponseHeaders(base.Headers);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (_ComStream != null)
                {
                    _ComStream.Dispose();
                }
            }
        }
    }
}
