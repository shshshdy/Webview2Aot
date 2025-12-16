using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{
    [GeneratedComClass]
    public partial class BasicAuthenticationRequestedEventHandler : ICoreWebView2BasicAuthenticationRequestedEventHandler
    {
        public event EventHandler<BasicAuthenticationRequestedEventArgs> BasicAuthenticationRequested;

        public void Invoke(ICoreWebView2 sender, ICoreWebView2BasicAuthenticationRequestedEventArgs args)
        {
            try
            {
                OnBasicAuthenticationRequested(new BasicAuthenticationRequestedEventArgs(args));
            }
            catch (Exception ex)
            {
                Debug.Print(nameof(BasicAuthenticationRequestedEventHandler) + " Exception:" + ex.ToString());
            }
        }

        protected virtual void OnBasicAuthenticationRequested(BasicAuthenticationRequestedEventArgs e)
        {
            BasicAuthenticationRequested?.Invoke(this, e);
        }
    }
}
