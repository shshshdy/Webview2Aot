using Diga.WebView2.Wrapper.Types;

namespace Diga.WebView2.Wrapper.EventArguments
{
    public class WebViewButtonDownEventArgs : EventArgs
    {
        public Point Location { get; }

        public WebViewButtonDownEventArgs(Point location)
        {
            this.Location = location;
        }
    }
}
