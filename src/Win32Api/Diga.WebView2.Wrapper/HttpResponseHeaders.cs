using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;
using Diga.WebView2.Wrapper.Types;
namespace Diga.WebView2.Wrapper
{
    public class HttpResponseHeaders: CoreWebView2HttpResponseHeadersShim
    {
        public HttpResponseHeaders(ICoreWebView2HttpResponseHeaders args):base(args)
        {
            
        }

        public new HttpHeadersCollectionIterator GetHeaders(string name)
        {
            var iterarot = base.GetHeaders(name);
            return new HttpHeadersCollectionIterator(iterarot);
        }

        public new bool Contains(string name)
        {
            return (CBOOL)base.Contains(name);
        }

    }
}
