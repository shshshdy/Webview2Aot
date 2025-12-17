using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{


    [GeneratedComClass]
    public partial class FrameNameChangedEventHandler : ICoreWebView2FrameNameChangedEventHandler
    {
        public event EventHandler<FrameNameChangedEventArgs> FrameNameChanged;
        public void Invoke(ICoreWebView2Frame sender, object args)
        {
            try
            {
                string name = sender.Getname();
                Frame frame = new Frame((ICoreWebView2Frame4)sender);
                FrameNameChangedEventArgs eventArgs = new FrameNameChangedEventArgs(frame, args);
                OnFrameNameChanged(eventArgs);
            }
            catch (Exception ex)
            {
                Debug.Print($"Exception {nameof(FrameNameChangedEventHandler)}.Invoke:{ex.Message}");
            }

        }

        protected virtual void OnFrameNameChanged(FrameNameChangedEventArgs e)
        {
            FrameNameChanged?.Invoke(this, e);
        }
    }
}
