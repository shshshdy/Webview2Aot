using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2ProcessFailedEventArgsShim : EventArgs, IDisposable
    {
        private ComObjectHolder<ICoreWebView2ProcessFailedEventArgs> _Args;
        private bool disposedValue;
        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private SafeHandle handle = new SafeFileHandle(nint.Zero, true);

        private ICoreWebView2ProcessFailedEventArgs Args
        {
            get
            {
                if (_Args == null)
                {
                    Debug.Print(nameof(CoreWebView2ProcessFailedEventArgsShim) + " Args is null");
                    throw new InvalidOperationException(nameof(CoreWebView2ProcessFailedEventArgsShim) + " Args is null");
                }

                return _Args.Interface;
            }
            set => _Args = new ComObjectHolder<ICoreWebView2ProcessFailedEventArgs>(value);
        }

        public CoreWebView2ProcessFailedEventArgsShim(ICoreWebView2ProcessFailedEventArgs args)
        {
            Args = args;

        }
        public COREWEBVIEW2_PROCESS_FAILED_KIND ProcessFailedKind => Args.GetProcessFailedKind();

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
