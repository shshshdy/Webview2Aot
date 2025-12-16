using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;

namespace Diga.WebView2.Wrapper.EventArguments
{
    public class ClientCertificateRequestedEventArgs : CoreWebView2ClientCertificateRequestedEventArgsShim
    {
        public ClientCertificateRequestedEventArgs(ICoreWebView2ClientCertificateRequestedEventArgs args) : base(args)
        {

        }
    }
}
