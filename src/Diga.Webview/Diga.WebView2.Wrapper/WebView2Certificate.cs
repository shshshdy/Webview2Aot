using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;

namespace Diga.WebView2.Wrapper
{
    public class WebView2Certificate : CoreWebView2CertificateShim
    {
        public WebView2Certificate(ICoreWebView2Certificate certificate) : base(certificate)
        {
        }

    }
   
}
