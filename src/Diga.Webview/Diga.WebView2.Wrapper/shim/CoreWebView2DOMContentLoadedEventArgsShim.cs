using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2DOMContentLoadedEventArgsShim //: ICoreWebView2DOMContentLoadedEventArgs
    {
        private ComObjectHolder<ICoreWebView2DOMContentLoadedEventArgs> _Args;
        private ICoreWebView2DOMContentLoadedEventArgs Args
        {
            get
            {
                if (_Args == null)
                {
                    Debug.Print(nameof(CoreWebView2DOMContentLoadedEventArgsShim) + "=>" + nameof(Args) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2DOMContentLoadedEventArgsShim) + "=>" + nameof(Args) + " is null");
                }
                return _Args.Interface;
            }
            set { _Args = new ComObjectHolder<ICoreWebView2DOMContentLoadedEventArgs>(value); }
        }

        public CoreWebView2DOMContentLoadedEventArgsShim(ICoreWebView2DOMContentLoadedEventArgs args)
        {
            this.Args = args ?? throw new ArgumentNullException(nameof(args));
        }

        public ulong NavigationId => this.Args.GetNavigationId();
    }
}
