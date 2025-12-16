using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;

namespace Diga.WebView2.Wrapper.EventArguments
{
    public class WebResourceResponseReceivedEventArgs: CoreWebView2WebResourceResponseReceivedEventArgsShim
    {
        public WebResourceResponseReceivedEventArgs(ICoreWebView2WebResourceResponseReceivedEventArgs args):base(args)
        {
            
        }

        public new WebResourceRequest Request => new WebResourceRequest(base.Request);
       
     }
}
