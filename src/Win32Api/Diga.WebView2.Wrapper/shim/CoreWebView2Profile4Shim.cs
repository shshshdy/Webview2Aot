using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Profile4Shim : CoreWebView2Profile3Shim
    {
        private ComObjectHolder<ICoreWebView2Profile4> _Iface;
        private ICoreWebView2Profile4 Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2Profile4Shim) + "=>" + nameof(Iface) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2Profile4Shim) + "=>" + nameof(Iface) + " is null");
                }
                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2Profile4>(value);
        }
        public CoreWebView2Profile4Shim(ICoreWebView2Profile4 iface) : base(iface)
        {
            Iface = iface ?? throw new ArgumentNullException(nameof(iface));
        }

        private bool _IsDisposed;
        protected override void Dispose(bool disposing)
        {
            if (_IsDisposed) return;
            if (disposing)
            {
                _Iface = null;
                _IsDisposed = true;
            }
            base.Dispose(disposing);
        }
        public void SetPermissionState([In] COREWEBVIEW2_PERMISSION_KIND PermissionKind, [In, MarshalAs(UnmanagedType.LPWStr)] string origin, [In] COREWEBVIEW2_PERMISSION_STATE State, [In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2SetPermissionStateCompletedHandler completedHandler)
        {
            this.Iface.SetPermissionState(PermissionKind, origin, State, completedHandler);
        }

        public void GetNonDefaultPermissionSettings([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2GetNonDefaultPermissionSettingsCompletedHandler completedHandler)
        {
            this.Iface.GetNonDefaultPermissionSettings(completedHandler);
        }
    }
}
