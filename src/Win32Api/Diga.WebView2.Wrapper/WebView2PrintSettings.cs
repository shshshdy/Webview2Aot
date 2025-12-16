using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;

namespace Diga.WebView2.Wrapper
{





    public class WebView2PrintSettings : CoreWebView2PrintSettingsShim
    {

        public WebView2PrintSettings(ICoreWebView2PrintSettings printSettings) : base(printSettings)
        {

        }
    }
}
