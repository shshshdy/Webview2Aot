using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2NavigationStartingEventArgs2Shim : CoreWebView2NavigationStartingEventArgsShim//, ICoreWebView2NavigationStartingEventArgs2
    {
        private ComObjectHolder<ICoreWebView2NavigationStartingEventArgs2> _args;

        public CoreWebView2NavigationStartingEventArgs2Shim(ICoreWebView2NavigationStartingEventArgs2 args) : base(args)
        {
            Args = args;
        }

        private ICoreWebView2NavigationStartingEventArgs2 Args
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
            set => _args = new ComObjectHolder<ICoreWebView2NavigationStartingEventArgs2>(value);
        }

        [return: MarshalAs(UnmanagedType.LPWStr)]
        public string GetAdditionalAllowedFrameAncestors()
        {
            return Args.GetAdditionalAllowedFrameAncestors();
        }

        public void SetAdditionalAllowedFrameAncestors([MarshalAs(UnmanagedType.LPWStr)] string value)
        {
            Args.SetAdditionalAllowedFrameAncestors(value);
        }
    }
}
