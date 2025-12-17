using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{




    public class CoreWebView2CookieShim : IDisposable
    {
        private ComObjectHolder<ICoreWebView2Cookie> _Iface;
        private bool _IsDesposed;

        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private SafeHandle handle = new SafeFileHandle(nint.Zero, true);
        public CoreWebView2CookieShim(ICoreWebView2Cookie iface)
        {
            Iface = iface ?? throw new ArgumentNullException(nameof(iface));
        }

        private ICoreWebView2Cookie Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2CookieShim) + "=>" + nameof(Iface) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2CookieShim) + "=>" + nameof(Iface) + " is null");
                }

                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2Cookie>(value);
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

        public string name => this.Iface.Getname();

        public string value { get => this.Iface.Getvalue(); set => this.Iface.Setvalue(value); }

        public string Domain => this.Iface.GetDomain();

        public string Path => this.Iface.GetPath();

        public double Expires { get => this.Iface.GetExpires(); set => this.Iface.SetExpires(value); }
        public int IsHttpOnly { get => this.Iface.GetIsHttpOnly(); set => this.Iface.SetIsHttpOnly(value); }
        public COREWEBVIEW2_COOKIE_SAME_SITE_KIND SameSite { get => this.Iface.GetSameSite(); set => this.Iface.SetSameSite(value); }
        public int IsSecure { get => this.Iface.GetIsSecure(); set => this.Iface.SetIsSecure( value); }

        public int IsSession => this.Iface.GetIsSession();

        public ICoreWebView2Cookie ToInterface() => this.Iface;
    }
}
