using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{

    [GeneratedComClass]
    public partial class ProcessFailedEventHandler : ICoreWebView2ProcessFailedEventHandler
    {
        public event EventHandler<ProcessFailedEventArgs> ProcessFailed;


        protected virtual void OnProcessFailed(ProcessFailedEventArgs e)
        {
            ProcessFailed?.Invoke(this, e);
        }

        public void Invoke(ICoreWebView2 sender, ICoreWebView2ProcessFailedEventArgs args)
        {
            try
            {
                OnProcessFailed(new ProcessFailedEventArgs((ICoreWebView2ProcessFailedEventArgs2)args));
            }
            catch (Exception ex)
            {
                Debug.Print(nameof(ProcessFailedEventHandler) + " Exception:" + ex.ToString());

            }

        }
    }
}
