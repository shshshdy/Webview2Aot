using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;

namespace Diga.WebView2.Wrapper.EventArguments
{
    public class DownloadStartingEventArgs : CoreWebView2DownloadStartingEventArgsShim
    {
        public DownloadStartingEventArgs(ICoreWebView2DownloadStartingEventArgs args) : base(args)
        {

        }

        public new WebView2DownloadOperation DownloadOperation => new WebView2DownloadOperation(base.DownloadOperation);

        public new WebView2Deferral GetDeferral()
        {
            return new WebView2Deferral(base.GetDeferral());
        }
    }
}
