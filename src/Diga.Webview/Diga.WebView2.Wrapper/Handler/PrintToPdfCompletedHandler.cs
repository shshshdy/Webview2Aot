using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using Diga.WebView2.Wrapper.Types;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{
    [GeneratedComClass]
    public partial class PrintToPdfCompletedHandler : ICoreWebView2PrintToPdfCompletedHandler
    {
        public event EventHandler<PrintToPdfCompleteEventArgs> Complete;
        public void Invoke([MarshalAs(UnmanagedType.Error)] int errorCode, int isSuccessful)
        {
            PrintToPdfCompleteEventArgs args = new PrintToPdfCompleteEventArgs((CBOOL)isSuccessful, errorCode);
            OnComplete(args);
        }
        protected void OnComplete(PrintToPdfCompleteEventArgs e)
        {
            Complete?.Invoke(this, e);
        }
    }
}
