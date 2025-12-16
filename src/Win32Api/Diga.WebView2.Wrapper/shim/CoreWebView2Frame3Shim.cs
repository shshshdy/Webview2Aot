using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Frame3Shim : CoreWebView2Frame2Shim
    {
        private ComObjectHolder<ICoreWebView2Frame3> _Args;
        private ICoreWebView2Frame3 Args
        {
            get
            {
                if (_Args == null)
                {
                    Debug.Print(nameof(CoreWebView2Frame3Shim) + " Args is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Frame3Shim) + " Args is null");
                }

                return _Args.Interface;
            }
            set
            {
                _Args = new ComObjectHolder<ICoreWebView2Frame3>(value);
            }
        }

        public CoreWebView2Frame3Shim(ICoreWebView2Frame3 args) : base(args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));
            Args = args;
        }
        public ICoreWebView2Frame3 GetInterface() => Args;

        public void add_PermissionRequested([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2FramePermissionRequestedEventHandler handler, out EventRegistrationToken token)
        {
            Args.add_PermissionRequested(handler, out token);
        }

        public void remove_PermissionRequested([In] EventRegistrationToken token)
        {
            Args.remove_PermissionRequested(token);
        }
        private bool disposedValue;
        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                    _Args = null;
                }

                disposedValue = true;
            }
            base.Dispose(disposing);
        }
    }
}
