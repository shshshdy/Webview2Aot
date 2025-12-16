using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{
    [GeneratedComClass]
    public partial class ClientCertificateRequestedEventHandler : ICoreWebView2ClientCertificateRequestedEventHandler
    {
        public event EventHandler<ClientCertificateRequestedEventArgs> CertificateRequested;
        public void Invoke(ICoreWebView2 sender, ICoreWebView2ClientCertificateRequestedEventArgs args)
        {
            try
            {
                OnCertificateRequested(new ClientCertificateRequestedEventArgs(args));
            }
            catch (Exception ex)
            {
                Debug.Print(nameof(ClientCertificateRequestedEventHandler) + " Exception:" + ex.ToString());

            }



        }

        protected virtual void OnCertificateRequested(ClientCertificateRequestedEventArgs e)
        {
            CertificateRequested?.Invoke(this, e);
        }
    }
}
