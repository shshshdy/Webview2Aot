using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.EventArguments
{

    public class WebMessageReceivedEventArgs: CoreWebView2WebMessageReceivedEventArgs2Shim
    {
        public WebMessageReceivedEventArgs(ICoreWebView2WebMessageReceivedEventArgs2 args):base(args)
        {
            
        }

        public string WebMessageAsString
        {
            get
            {
                string value = null;
                try
                {
                    value = base.TryGetWebMessageAsString();
                }
                catch (Exception e)
                {

                    Debug.Print(e.ToString());
                }
                if (string.IsNullOrEmpty(value)) return "";
                return value;
            }

        }
    }
}
