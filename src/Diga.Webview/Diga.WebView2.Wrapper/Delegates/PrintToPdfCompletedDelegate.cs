using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using Diga.WebView2.Wrapper.Types;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{
    [GeneratedComClass]
    public partial class PrintToPdfCompletedDelegate : ICoreWebView2PrintToPdfCompletedHandler
    {
        public event EventHandler<PrintToPdfCompleteEventArgs> PrintToPdfCompleted;

        public void Invoke(int errorCode, int isSuccessful)
        {
            OnPrintToPdfCompleted(new PrintToPdfCompleteEventArgs(new CBOOL(isSuccessful), errorCode));
        }

        protected virtual void OnPrintToPdfCompleted(PrintToPdfCompleteEventArgs e)
        {
            PrintToPdfCompleted?.Invoke(this, e);
        }
    }
}
