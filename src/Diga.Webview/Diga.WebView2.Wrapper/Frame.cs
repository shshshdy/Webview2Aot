using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;
namespace Diga.WebView2.Wrapper
{
    public class Frame:CoreWebView2Frame4Shim
    {
        public Frame(ICoreWebView2Frame4 frame):base(frame)
        {
            
        }
    }
}
