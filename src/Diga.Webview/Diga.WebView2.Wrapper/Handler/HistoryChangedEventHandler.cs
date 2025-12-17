using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{
    [GeneratedComClass]
    public partial class HistoryChangedEventHandler : ICoreWebView2HistoryChangedEventHandler
    {
        public event EventHandler<WebView2EventArgs> HistoryChanged;
        public void Invoke(ICoreWebView2 webview, object args)
        {
            try
            {
                OnHistoryChanged(new WebView2EventArgs(webview, args));
            }
            catch (Exception ex)
            {
                Debug.Print(nameof(HistoryChangedEventHandler) + " Exception:" + ex.ToString());

            }

        }

        protected virtual void OnHistoryChanged(WebView2EventArgs e)
        {
            HistoryChanged?.Invoke(this, e);
        }
    }
}
