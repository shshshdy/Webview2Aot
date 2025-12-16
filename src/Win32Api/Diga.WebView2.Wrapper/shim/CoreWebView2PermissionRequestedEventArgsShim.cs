using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2PermissionRequestedEventArgsShim : EventArgs,IDisposable
    {
        private ComObjectHolder<ICoreWebView2PermissionRequestedEventArgs> _Args;
        private bool disposedValue;

        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private SafeHandle handle = new SafeFileHandle(nint.Zero, true);
        private ICoreWebView2PermissionRequestedEventArgs Args
        {
            get
            {
                if (_Args == null)
                {
                    Debug.Print(nameof(CoreWebView2PermissionRequestedEventArgsShim) + " Args is null");
                    throw new InvalidOperationException(nameof(CoreWebView2PermissionRequestedEventArgsShim) + " Args is null");
                }

                return _Args.Interface;
            }
            set
            {
                _Args = new ComObjectHolder<ICoreWebView2PermissionRequestedEventArgs>(value);
            }
        }
        public CoreWebView2PermissionRequestedEventArgsShim(ICoreWebView2PermissionRequestedEventArgs args)
        {
            Args = args;
        }

        public string uri => Args.Geturi();

        public COREWEBVIEW2_PERMISSION_KIND PermissionKind => Args.GetPermissionKind();

        public int IsUserInitiated => Args.GetIsUserInitiated();

        public COREWEBVIEW2_PERMISSION_STATE State { get => Args.GetState(); set => Args.SetState(value); }

        [return: MarshalAs(UnmanagedType.Interface)]
        public ICoreWebView2Deferral GetDeferral()
        {
            return Args.GetDeferral();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                    handle.Dispose();
                    _Args = null;
                }

                disposedValue = true;
            }
        }



        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
