using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{

    [GeneratedComClass]
    public partial class AcceleratorKeyPressedEventHandler : ICoreWebView2AcceleratorKeyPressedEventHandler
    {
        public event EventHandler<AcceleratorKeyPressedEventArgs> AcceleratorKeyPressed;

        protected virtual void OnAcceleratorKeyPressed(AcceleratorKeyPressedEventArgs e)
        {
            AcceleratorKeyPressed?.Invoke(this, e);
        }
        public void Invoke(ICoreWebView2Controller sender, ICoreWebView2AcceleratorKeyPressedEventArgs args)
        {
            try
            {
                OnAcceleratorKeyPressed(new AcceleratorKeyPressedEventArgs(args));
            }
            catch (Exception ex)
            {

                Debug.Print("AcceleratorKeyPressedEventHandler Exception:" + ex.ToString());
            }


        }


    }
}
