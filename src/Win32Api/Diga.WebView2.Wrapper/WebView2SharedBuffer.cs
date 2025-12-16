using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;

namespace Diga.WebView2.Wrapper
{
    public class WebView2SharedBuffer : CoreWebView2SharedBufferShim
    {
        public WebView2SharedBuffer(ICoreWebView2SharedBuffer args) : base(args) { }

        public new Stream OpenStream()
        {
            return new ComStream(base.OpenStream());
        }

    }
}
