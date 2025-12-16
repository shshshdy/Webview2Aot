using Diga.WebView2.Interop;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{

    [GeneratedComClass]
    public partial class GetCookiesCompletedHandler : ICoreWebView2GetCookiesCompletedHandler
    {
        private readonly TaskCompletionSource<(int, ICoreWebView2CookieList)> _Source;
        public GetCookiesCompletedHandler(TaskCompletionSource<(int, ICoreWebView2CookieList)> source)
        {
            _Source = source;
        }
        public void Invoke([MarshalAs(UnmanagedType.Error)] int result, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2CookieList cookieList)
        {
            _Source.SetResult((result, cookieList));
        }
    }
}
