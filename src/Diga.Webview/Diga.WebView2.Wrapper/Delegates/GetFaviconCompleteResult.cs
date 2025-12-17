using Diga.WebView2.Interop;

namespace Diga.WebView2.Wrapper.Delegates
{
    public class GetFaviconCompleteResult
    {
        public IStream Stream { get; }
        public int ErrorCode { get; }

        public GetFaviconCompleteResult(int errorCode, IStream stream)
        {
            this.Stream = stream;
            this.ErrorCode = errorCode;
        }
    }
}
