using Diga.WebView2.Interop;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{
    [GeneratedComClass]
    public partial class CapturePreviewCompletedDelegate : ICoreWebView2CapturePreviewCompletedHandler
    {
        private readonly TaskCompletionSource<int> _Source;

        public CapturePreviewCompletedDelegate(TaskCompletionSource<int> source)
        {
            this._Source = source;
        }

        public void Invoke([MarshalAs(UnmanagedType.Error)] int errorCode)
        {
            try
            {
                this._Source.SetResult(errorCode);
            }
            catch (Exception ex)
            {
                Debug.Print(nameof(CapturePreviewCompletedDelegate) + " Exception:" + ex.ToString());

            }
        }
       
    }
}
