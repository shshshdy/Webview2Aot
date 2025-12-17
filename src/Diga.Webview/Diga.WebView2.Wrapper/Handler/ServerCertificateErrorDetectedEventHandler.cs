using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{
    [GeneratedComClass]
    public partial class ServerCertificateErrorDetectedEventHandler : ICoreWebView2ServerCertificateErrorDetectedEventHandler
    {
        public event EventHandler<ServerCertificateErrorDetectedEventArgs> ServerCertificateErrorDetected;
        private void OnServerCertificateErrorDetected(ServerCertificateErrorDetectedEventArgs e)
        {
            this.ServerCertificateErrorDetected?.Invoke(this, e);
        }
        public void Invoke(ICoreWebView2 sender, ICoreWebView2ServerCertificateErrorDetectedEventArgs args)
        {
            try
            {
                OnServerCertificateErrorDetected(new ServerCertificateErrorDetectedEventArgs(args));
            }
            catch (Exception ex)
            {
                Debug.Print(nameof(ServerCertificateErrorDetectedEventHandler) + " Exception:" + ex.ToString());
            }

        }
    }
}
