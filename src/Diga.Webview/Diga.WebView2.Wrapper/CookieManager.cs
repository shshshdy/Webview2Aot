using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;
using Diga.WebView2.Wrapper.Types;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper
{
    public class CookieManager: CoreWebView2CookieManagerShim
    {
        public CookieManager(ICoreWebView2CookieManager args):base(args)
        {
            
        }
        public new Cookie CreateCookie(string name, string value, string domain, string path)=>new Cookie(base.CreateCookie(name, value, domain, path));

        public Cookie CopyCookie(Cookie cookieParent) => new Cookie(base.CopyCookie(cookieParent.ToInterface()));

        public async Task<CookieList> GetCookies(string uri)
        {
            TaskCompletionSource<(int, ICoreWebView2CookieList)> source =
                new TaskCompletionSource<(int, ICoreWebView2CookieList)>();
            GetCookiesCompletedHandler handler = new GetCookiesCompletedHandler(source);
            base.GetCookies(uri, handler);
            (int errorCode, ICoreWebView2CookieList resultObject) result = await source.Task;
            HRESULT resultCode = result.errorCode;
            if (resultCode != HRESULT.S_OK)
                throw Marshal.GetExceptionForHR(resultCode);
            return new CookieList(result.resultObject);

        }

        public void AddOrUpdateCookie(Cookie cookie) => base.AddOrUpdateCookie(cookie.ToInterface());
        public void DeleteCookie(Cookie cookie) => base.DeleteCookie(cookie.ToInterface());
        public new void DeleteCookies(string name, string uri) => base.DeleteCookies(name, uri);
        public new void DeleteCookiesWithDomainAndPath(string name, string domain, string path) =>
           base.DeleteCookiesWithDomainAndPath(name, domain, path);

        public new void DeleteAllCookies() => base.DeleteAllCookies();


    }
}
