using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{

    [GeneratedComClass]
    public partial class CompositionControllerCompletedHandler : ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler
    {
        public event EventHandler<CompositionControllerCompletedEventArgs> Completed;
        public void Invoke(int errorCode, ICoreWebView2CompositionController webView)
        {
            OnCompleted(new CompositionControllerCompletedEventArgs(errorCode, new WebView2CompositionController((ICoreWebView2CompositionController2)webView)));
        }

        protected virtual void OnCompleted(CompositionControllerCompletedEventArgs e)
        {
            Completed?.Invoke(this, e);
        }
    }
}
