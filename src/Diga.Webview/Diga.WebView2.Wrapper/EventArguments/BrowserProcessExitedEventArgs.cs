using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;

namespace Diga.WebView2.Wrapper.EventArguments
{
    public class BrowserProcessExitedEventArgs : CoreWebView2BrowserProcessExitedEventArgsShim
    {
        

        public BrowserProcessExitedEventArgs(ICoreWebView2BrowserProcessExitedEventArgs iface) : base(iface)
        {

        }
    }
}
