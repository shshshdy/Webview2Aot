using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;

namespace Diga.WebView2.Wrapper
{

    public class WebView2ScriptException : CoreWebView2ScriptExceptionShim
    {
        public WebView2ScriptException(ICoreWebView2ScriptException exception) : base(exception)
        {

        }

    }
}
