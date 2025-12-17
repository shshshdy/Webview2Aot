using Diga.WebView2.Interop;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{



    [GeneratedComClass]
    public partial class PrintToPdfCompletedDelegateTask : ICoreWebView2PrintToPdfCompletedHandler
    {
        private readonly TaskCompletionSource<(int, int)> _Source;

        public PrintToPdfCompletedDelegateTask(TaskCompletionSource<(int, int)> source)
        {
            this._Source = source;
        }
        void ICoreWebView2PrintToPdfCompletedHandler.Invoke(int errorCode, int isSuccessful)
        {
            try
            {
                this._Source.SetResult((errorCode, isSuccessful));
            }
            catch (Exception ex)
            {
                Debug.Print(nameof(PrintToPdfCompletedDelegateTask) + " Exception:" + ex.ToString());

            }


        }
    }
}
