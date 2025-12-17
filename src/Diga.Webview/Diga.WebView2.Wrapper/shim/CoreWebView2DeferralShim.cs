using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2DeferralShim : IDisposable//,ICoreWebView2Deferral
    {
        //private ICoreWebView2Deferral _Deferral;
        private readonly ComObjectHolder<ICoreWebView2Deferral> _Native;
        private bool disposedValue;
        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private SafeHandle handle = new SafeFileHandle(nint.Zero, true);

        private ICoreWebView2Deferral Deferral => this._Native.Interface;

        //set => this._Deferral = value;
        public CoreWebView2DeferralShim(ICoreWebView2Deferral deferral)
        {
            this._Native = new ComObjectHolder<ICoreWebView2Deferral>(deferral);
            //this._Native = deferral?? throw new ArgumentNullException(nameof(deferral));

        }

        public void Complete()
        {
            try
            {
                this.Deferral.Complete();
            }
            catch (InvalidCastException ex)
            {
                if (ex.HResult == HRESULT.E_NOINTERFACE)
                    throw new InvalidOperationException($"{nameof(Complete)} accessed outside UI-Thread");
                throw;
            }
            catch (COMException ex)
            {
                if (ex.HResult == HRESULT.E_INVALID_STATE)
                    throw new InvalidOperationException("WebView2 already disposed");

                throw;
            }

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {

                    this.Complete();
                    this.handle.Dispose();
                    //this._Deferral = null;
                }


                this.disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
