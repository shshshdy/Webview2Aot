using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Delegates;
using System.Diagnostics;

using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{
    [GeneratedComClass]
    public partial class GetFaviconCompletedHandler : ICoreWebView2GetFaviconCompletedHandler
    {
        private readonly TaskCompletionSource<GetFaviconCompleteResult> _Source;

        public GetFaviconCompletedHandler(TaskCompletionSource<GetFaviconCompleteResult> source)
        {
            this._Source = source;
        }
        public void Invoke(int errorCode, IStream faviconStream)
        {
            try
            {
                GetFaviconCompleteResult result = new GetFaviconCompleteResult(errorCode, faviconStream);
                this._Source.SetResult(result);
            }
            catch (Exception ex)
            {
                Debug.Print(nameof(GetFaviconCompletedHandler) + " Exception:" + ex.ToString());
            }


        }

       
    }
}
