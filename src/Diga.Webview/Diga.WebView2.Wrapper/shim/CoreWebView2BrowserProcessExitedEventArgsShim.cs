using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2BrowserProcessExitedEventArgsShim //: ICoreWebView2BrowserProcessExitedEventArgs
    {
        private ComObjectHolder<ICoreWebView2BrowserProcessExitedEventArgs> _Args;
        private ICoreWebView2BrowserProcessExitedEventArgs Args
        {
            get
            {
                if (_Args == null)
                {
                    Debug.Print(nameof(CoreWebView2BrowserProcessExitedEventArgsShim) + "=>" + nameof(Args) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2BrowserProcessExitedEventArgsShim) + "=>" + nameof(Args) + " is null");
                }
                return _Args.Interface;
            }
            set { _Args = new ComObjectHolder<ICoreWebView2BrowserProcessExitedEventArgs>(value); }
        }
        public CoreWebView2BrowserProcessExitedEventArgsShim(ICoreWebView2BrowserProcessExitedEventArgs args)
        {
            this.Args = args ?? throw new ArgumentNullException(nameof(args));
        }

        public COREWEBVIEW2_BROWSER_PROCESS_EXIT_KIND BrowserProcessExitKind => this.Args.GetBrowserProcessExitKind();

        public uint BrowserProcessId => this.Args.GetBrowserProcessId();
    }
}
