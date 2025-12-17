using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;

namespace Diga.WebView2.Wrapper.EventArguments
{
    public class DOMContentLoadedEventArgs : CoreWebView2DOMContentLoadedEventArgsShim
    {


        public DOMContentLoadedEventArgs(ICoreWebView2DOMContentLoadedEventArgs args) : base(args)
        {

        }


    }
}
