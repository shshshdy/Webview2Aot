using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{

    [GeneratedComClass]
    public partial class WebResourceRequestedEventHandler : ICoreWebView2WebResourceRequestedEventHandler
    {
        public event EventHandler<WebResourceRequestedEventArgs> WebResourceRequested;

        protected virtual void OnWebResourceRequested(WebResourceRequestedEventArgs e)
        {
            WebResourceRequested?.Invoke(this, e);
        }

        public void Invoke(ICoreWebView2 sender, ICoreWebView2WebResourceRequestedEventArgs args)
        {
            try
            {
                OnWebResourceRequested(new WebResourceRequestedEventArgs(args));
            }
            catch (Exception ex)
            {
                Debug.Print(nameof(WebResourceRequestedEventHandler) + " Exception:" + ex.ToString());

            }



        }
    }
}
