using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{


    [GeneratedComClass]
    public partial class ContentLoadingEventHandler : ICoreWebView2ContentLoadingEventHandler
    {
        public event EventHandler<ContentLoadingEventArgs> ContentLoading;
        public void Invoke(ICoreWebView2 webview, ICoreWebView2ContentLoadingEventArgs args)
        {
            try
            {
                OnContentLoading(new ContentLoadingEventArgs(new CBOOL(args.GetIsErrorPage()), args.GetNavigationId()));
            }
            catch (Exception ex)
            {
                Debug.Print(nameof(ContentLoadingEventHandler) + " Exception:" + ex.ToString());

            }

        }

        protected virtual void OnContentLoading(ContentLoadingEventArgs e)
        {
            ContentLoading?.Invoke(this, e);
        }
    }
}
