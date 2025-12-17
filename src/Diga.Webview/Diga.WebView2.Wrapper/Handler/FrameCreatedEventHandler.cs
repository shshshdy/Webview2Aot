using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{

    [GeneratedComClass]
    public partial class FrameCreatedEventHandler : ICoreWebView2FrameCreatedEventHandler
    {
        public event EventHandler<FrameCreatedEventArgs> FrameCreated;
        public void Invoke(ICoreWebView2 sender, ICoreWebView2FrameCreatedEventArgs args)
        {
            try
            {
                string name = args.GetFrame().Getname();
                Debug.Print(name);

                OnFrameCreated(new FrameCreatedEventArgs(args));
            }
            catch (Exception ex)
            {
                Debug.Print($"Exception {nameof(FrameCreatedEventHandler)}.Invoke:{ex.Message}");

            }

        }

        protected virtual void OnFrameCreated(FrameCreatedEventArgs e)
        {
            FrameCreated?.Invoke(this, e);
        }
    }
}
