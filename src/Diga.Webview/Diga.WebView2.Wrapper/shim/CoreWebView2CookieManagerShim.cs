using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2CookieManagerShim : IDisposable, ICoreWebView2CookieManager
    {
        private ComObjectHolder<ICoreWebView2CookieManager> _Iface;
        private bool _IsDesposed;

        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public CoreWebView2CookieManagerShim(ICoreWebView2CookieManager iface)
        {
            Iface = iface ?? throw new ArgumentNullException(nameof(iface));
        }

        private ICoreWebView2CookieManager Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2CookieManagerShim) + "=>" + nameof(Iface) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2CookieManagerShim) + "=>" + nameof(Iface) + " is null");
                }

                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2CookieManager>(value);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_IsDesposed)
            {
                if (disposing)
                {
                    handle.Dispose();
                    _Iface = null;
                }

                _IsDesposed = true;
            }
        }

        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        [return: MarshalAs(UnmanagedType.Interface)]
        public ICoreWebView2Cookie CreateCookie([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string Domain, [MarshalAs(UnmanagedType.LPWStr)] string Path)
        {
            return this.Iface.CreateCookie(name, value, Domain, Path);
        }

        [return: MarshalAs(UnmanagedType.Interface)]
        public ICoreWebView2Cookie CopyCookie([MarshalAs(UnmanagedType.Interface)] ICoreWebView2Cookie cookieParam)
        {
            return this.Iface.CopyCookie(cookieParam);
        }

        public void GetCookies([MarshalAs(UnmanagedType.LPWStr)] string uri, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2GetCookiesCompletedHandler handler)
        {
            this.Iface.GetCookies(uri, handler);
        }

        public void AddOrUpdateCookie([MarshalAs(UnmanagedType.Interface)] ICoreWebView2Cookie cookie)
        {
            this.Iface.AddOrUpdateCookie(cookie);
        }

        public void DeleteCookie([MarshalAs(UnmanagedType.Interface)] ICoreWebView2Cookie cookie)
        {
            this.Iface.DeleteCookie(cookie);
        }

        public void DeleteCookies([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string uri)
        {
            this.Iface.DeleteCookies(name, uri);
        }

        public void DeleteCookiesWithDomainAndPath([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string Domain, [MarshalAs(UnmanagedType.LPWStr)] string Path)
        {
            this.Iface.DeleteCookiesWithDomainAndPath(name, Domain, Path);
        }

        public void DeleteAllCookies()
        {
            this.Iface.DeleteAllCookies();
        }
    }
}
