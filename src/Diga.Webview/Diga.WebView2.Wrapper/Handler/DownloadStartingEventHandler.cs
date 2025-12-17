using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{
    [GeneratedComClass]
    public partial class DownloadStartingEventHandler : ICoreWebView2DownloadStartingEventHandler
    {
        public event EventHandler<DownloadStartingEventArgs> DownloadStarting;
        public void Invoke(ICoreWebView2 sender, ICoreWebView2DownloadStartingEventArgs args)
        {
            try
            {
                OnDownloadStarting(new DownloadStartingEventArgs(args));
            }
            catch (Exception ex)
            {
                Debug.Print(nameof(DownloadStartingEventHandler) + " Exception:" + ex.ToString());

            }


        }

        protected virtual void OnDownloadStarting(DownloadStartingEventArgs e)
        {
            DownloadStarting?.Invoke(this, e);
        }
    }
}
