using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2NavigationStartingEventArgs3Shim : CoreWebView2NavigationStartingEventArgs2Shim//, ICoreWebView2NavigationStartingEventArgs3
    {
        private ComObjectHolder<ICoreWebView2NavigationStartingEventArgs3> _args;

        public CoreWebView2NavigationStartingEventArgs3Shim(ICoreWebView2NavigationStartingEventArgs3 args) : base(args)
        {
            Args = args;
        }

        private ICoreWebView2NavigationStartingEventArgs3 Args
        {
            get
            {
                if (_args == null)
                {
                    Debug.Print(nameof(CoreWebView2NavigationStartingEventArgsShim) + "=>" + nameof(Args) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2NavigationStartingEventArgsShim) + "=>" + nameof(Args) + " is null");
                }

                return _args.Interface;
            }
            set => _args = new ComObjectHolder<ICoreWebView2NavigationStartingEventArgs3>(value);
        }

        public COREWEBVIEW2_NAVIGATION_KIND GetNavigationKind()
        {
            return Args.GetNavigationKind();
        }
    }
}
