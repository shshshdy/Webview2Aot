using Diga.WebView2.Interop;

namespace Diga.WebView2.Wrapper.EventArguments
{
   
    public class CursorChangedEventArgs : EventArgs
    {
        public ICoreWebView2CompositionController CompositionController { get; }
        public object Args { get; }

        public CursorChangedEventArgs(ICoreWebView2CompositionController controller, object args)
        {
            this.CompositionController = controller;
            this.Args = args;
        }
    }
}
