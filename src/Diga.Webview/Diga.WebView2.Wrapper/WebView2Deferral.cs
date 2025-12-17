using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;

namespace Diga.WebView2.Wrapper
{
    public class WebView2Deferral : CoreWebView2DeferralShim
    {
        internal WebView2Deferral(ICoreWebView2Deferral deferral) : base(deferral)
        {

        }

    }
}
