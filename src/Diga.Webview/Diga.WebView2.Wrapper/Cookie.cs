using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;

namespace Diga.WebView2.Wrapper
{

    public class Cookie: CoreWebView2CookieShim
    {
        public Cookie(ICoreWebView2Cookie args):base(args)
        {
            
        }


    }
}
