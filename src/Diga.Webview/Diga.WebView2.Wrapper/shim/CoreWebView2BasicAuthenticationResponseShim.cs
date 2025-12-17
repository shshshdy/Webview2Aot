using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;

namespace Diga.WebView2.Wrapper.shim
{
    /// <summary>
    /// Shim-Wrapper für ICoreWebView2BasicAuthenticationResponse
    /// </summary>
    public class CoreWebView2BasicAuthenticationResponseShim : IDisposable
    {
        private ComObjectHolder<ICoreWebView2BasicAuthenticationResponse> _Iface;
        private bool disposedValue;
        private SafeHandle handle = new SafeFileHandle(nint.Zero, true);

        /// <summary>
        /// Gets the wrapped COM interface.
        /// </summary>
        private ICoreWebView2BasicAuthenticationResponse Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2BasicAuthenticationResponseShim) + " Iface is null");
                    throw new InvalidOperationException(nameof(CoreWebView2BasicAuthenticationResponseShim) + " Iface is null");
                }

                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2BasicAuthenticationResponse>(value);
        }

        /// <summary>
        /// Initializes a new instance of the CoreWebView2BasicAuthenticationResponseShim class.
        /// </summary>
        /// <param name="iface">The COM interface to wrap</param>
        public CoreWebView2BasicAuthenticationResponseShim(ICoreWebView2BasicAuthenticationResponse iface)
        {
            Iface = iface;
        }

        #region Properties

        /// <summary>
        /// Gets the UserName property.
        /// </summary>
        public string UserName
        {
            get => Iface.GetUserName();
            set => Iface.SetUserName(value);
        }

        /// <summary>
        /// Gets the Password property.
        /// </summary>
        public string Password
        {
            get => Iface.GetPassword();
            set => Iface.SetPassword(value);
        }

        #endregion


        /// <summary>
        /// Protected virtual dispose method.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    handle?.Dispose();
                    _Iface = null;
                }
                disposedValue = true;
            }
        }

        /// <summary>
        /// Disposes the shim class and releases the COM object.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizer for fallback cleanup.
        /// </summary>
        ~CoreWebView2BasicAuthenticationResponseShim()
        {
            Dispose(disposing: false);
        }
    }
}
