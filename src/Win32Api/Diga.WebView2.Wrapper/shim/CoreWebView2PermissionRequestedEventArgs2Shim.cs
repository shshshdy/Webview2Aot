using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2PermissionRequestedEventArgs2Shim : CoreWebView2PermissionRequestedEventArgsShim
    {
        private ComObjectHolder<ICoreWebView2PermissionRequestedEventArgs2> _Args;
        private ICoreWebView2PermissionRequestedEventArgs2 Args
        {
            get
            {
                if (_Args == null)
                {
                    Debug.Print(nameof(CoreWebView2PermissionRequestedEventArgs2Shim) + " Args is null");
                    throw new InvalidOperationException(nameof(CoreWebView2PermissionRequestedEventArgs2Shim) + " Args is null");
                }

                return _Args.Interface;
            }
            set
            {
                _Args = new ComObjectHolder<ICoreWebView2PermissionRequestedEventArgs2>(value);
            }
        }
        public CoreWebView2PermissionRequestedEventArgs2Shim(ICoreWebView2PermissionRequestedEventArgs2 args) : base(args)
        {
            Args = args;
        }
        public int Handled { get => Args.GetHandled(); set => Args.SetHandled(value); }
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
