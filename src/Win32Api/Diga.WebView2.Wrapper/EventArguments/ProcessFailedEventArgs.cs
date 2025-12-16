using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;

namespace Diga.WebView2.Wrapper.EventArguments
{
    public class ProcessFailedEventArgs : CoreWebView2ProcessFailedEventArgs2Shim
    {

        public ProcessFailedEventArgs(ICoreWebView2ProcessFailedEventArgs2 args) : base(args)
        {

        }

      



    }
}
