using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2NewWindowRequestedEventArgsShim : IDisposable
    {
        private ComObjectHolder<ICoreWebView2NewWindowRequestedEventArgs> _Args;
        private bool _IsDisposed;
        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private readonly SafeHandle handle = new SafeFileHandle(nint.Zero, true);
        private ICoreWebView2NewWindowRequestedEventArgs Args
        {
            get
            {
                if (_Args == null)
                {
                    Debug.Print(nameof(CoreWebView2NewWindowRequestedEventArgsShim) + "=>" + nameof(Args) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2NewWindowRequestedEventArgsShim) + "=>" + nameof(Args) + " is null");
                }
                return _Args.Interface;
            }
            set { _Args = new ComObjectHolder<ICoreWebView2NewWindowRequestedEventArgs>(value); }
        }
        public CoreWebView2NewWindowRequestedEventArgsShim(ICoreWebView2NewWindowRequestedEventArgs args)
        {
            Args = args ?? throw new ArgumentNullException(nameof(args));
        }
        public string uri => Args.Geturi();

        public ICoreWebView2 NewWindow { get => Args.GetNewWindow(); set => Args.SetNewWindow(value); }
        public int Handled { get => Args.GetHandled(); set => Args.SetHandled(value); }

        public int IsUserInitiated => Args.GetIsUserInitiated();

        [return: MarshalAs(UnmanagedType.Interface)]
        public ICoreWebView2Deferral GetDeferral()
        {
            return Args.GetDeferral();
        }

        public ICoreWebView2WindowFeatures WindowFeatures => Args.GetWindowFeatures();

        protected virtual void Dispose(bool disposing)
        {
            if (!_IsDisposed)
            {
                if (disposing)
                {
                    handle.Dispose();
                    _Args = null;
                }

                _IsDisposed = true;
            }
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
