using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{
    [GeneratedComClass]
    public partial class NewBrowserVersionAvailableEventHandler : ICoreWebView2NewBrowserVersionAvailableEventHandler
    {
        public event EventHandler<WebView2EventArgs> NewBrowserVersionAvailable;
        public void Invoke(ICoreWebView2Environment webviewEnvironment, object args)
        {
            WebView2EventArgs evArgs = new WebView2EventArgs(webviewEnvironment, args);
            OnNewBrowserVersionAvailable(evArgs);
        }

        protected virtual void OnNewBrowserVersionAvailable(WebView2EventArgs args)
        {
            NewBrowserVersionAvailable?.Invoke(this, args);
        }
    }
}
