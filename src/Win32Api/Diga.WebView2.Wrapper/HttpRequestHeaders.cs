using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;
namespace Diga.WebView2.Wrapper
{

    public class HttpRequestHeaders : CoreWebView2HttpRequestHeadersShim
    {
        public HttpRequestHeaders(ICoreWebView2HttpRequestHeaders iface):base(iface) 
        { 
            
        }

        public new HttpHeadersCollectionIterator GetIterator()
        {
            var iterator = base.GetIterator();
            return new HttpHeadersCollectionIterator(iterator);
        }



    }
}
