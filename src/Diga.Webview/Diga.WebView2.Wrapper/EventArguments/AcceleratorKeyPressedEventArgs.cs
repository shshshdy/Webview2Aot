using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;

namespace Diga.WebView2.Wrapper.EventArguments
{
    public class AcceleratorKeyPressedEventArgs : CoreWebView2AcceleratorKeyPressedEventArgsShim
    {
      
        public AcceleratorKeyPressedEventArgs(ICoreWebView2AcceleratorKeyPressedEventArgs args):base(args)
        {
        }



    }
}
