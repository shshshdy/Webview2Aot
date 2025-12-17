using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{

    [GeneratedComClass]
    public partial class WindowCloseRequestedHandler : ICoreWebView2WindowCloseRequestedEventHandler
    {
        public event EventHandler<WebView2EventArgs> WindowCloseRequested;

        public void Invoke(ICoreWebView2 sender, object args)
        {
            try
            {
                OnWindowCloseRequested(new WebView2EventArgs(sender, args));
            }
            catch (Exception ex)
            {

                Debug.Print(nameof(WindowCloseRequestedHandler) + " Exception:" + ex.ToString());
            }

        }

        protected virtual void OnWindowCloseRequested(WebView2EventArgs e)
        {
            WindowCloseRequested?.Invoke(this, e);
        }
    }
}
