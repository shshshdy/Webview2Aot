using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{

   


    [GeneratedComClass]
    public partial class WebResourceResponseReceivedEventHandler : ICoreWebView2WebResourceResponseReceivedEventHandler
    {
        public event EventHandler<WebResourceResponseReceivedEventArgs> WebResourceResponseReceived;
        public void Invoke(ICoreWebView2 sender, ICoreWebView2WebResourceResponseReceivedEventArgs args)
        {
            try
            {
                OnWebResourceResponseReceived(new WebResourceResponseReceivedEventArgs(args));
            }
            catch (Exception ex)
            {
                Debug.Print(nameof(WebResourceResponseReceivedEventHandler) + " Exception:" + ex.ToString());

            }


        }

        protected virtual void OnWebResourceResponseReceived(WebResourceResponseReceivedEventArgs e)
        {
            WebResourceResponseReceived?.Invoke(this, e);
        }
    }
}
