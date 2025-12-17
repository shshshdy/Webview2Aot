using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{


    [GeneratedComClass]
    public partial class DOMContentLoadedEventHandler : ICoreWebView2DOMContentLoadedEventHandler
    {
        public event EventHandler<DOMContentLoadedEventArgs> DOMContentLoaded;
        public void Invoke(ICoreWebView2 sender, ICoreWebView2DOMContentLoadedEventArgs args)
        {
            try
            {
                OnDomContentLoaded(new DOMContentLoadedEventArgs(args));
            }
            catch (Exception ex)
            {

                Debug.Print(nameof(DOMContentLoadedEventHandler) + " Exception:" + ex.ToString());
            }

        }

        protected virtual void OnDomContentLoaded(DOMContentLoadedEventArgs e)
        {
            DOMContentLoaded?.Invoke(this, e);
        }
    }
}
