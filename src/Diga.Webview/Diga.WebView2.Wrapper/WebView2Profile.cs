using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;

namespace Diga.WebView2.Wrapper
{
    public class WebView2Profile : CoreWebView2Profile6Shim
    {
        public WebView2Profile(ICoreWebView2Profile6 profile) : base(profile)
        {

        }
    }
}
