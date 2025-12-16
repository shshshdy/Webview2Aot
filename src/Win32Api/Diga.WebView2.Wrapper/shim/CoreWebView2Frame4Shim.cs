using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{

    public class CoreWebView2Frame4Shim : CoreWebView2Frame3Shim //, ICoreWebView2Frame4
    {
        private ComObjectHolder<ICoreWebView2Frame4> _Args;
        private ICoreWebView2Frame4 Args
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
                _Args = new ComObjectHolder<ICoreWebView2Frame4>(value);
            }
        }

        public CoreWebView2Frame4Shim(ICoreWebView2Frame4 args) : base(args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));
            Args = args;
        }

        public void PostSharedBufferToScript([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2SharedBuffer sharedBuffer, [In] COREWEBVIEW2_SHARED_BUFFER_ACCESS access, [In, MarshalAs(UnmanagedType.LPWStr)] string additionalDataAsJson)
        {
            Args.PostSharedBufferToScript(sharedBuffer, access, additionalDataAsJson);
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
