using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;

namespace Diga.WebView2.Wrapper.shim
{
    /// <summary>
    /// Shim-Wrapper für ICoreWebView2StringCollection
    /// </summary>
    public class CoreWebView2StringCollectionShim : IDisposable
    {
        private ComObjectHolder<ICoreWebView2StringCollection> _Iface;
        private bool disposedValue;
        private SafeHandle handle = new SafeFileHandle(nint.Zero, true);

        /// <summary>
        /// Gets the wrapped COM interface.
        /// </summary>
        private ICoreWebView2StringCollection Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2StringCollectionShim) + " Iface is null");
                    throw new InvalidOperationException(nameof(CoreWebView2StringCollectionShim) + " Iface is null");
                }

                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2StringCollection>(value);
        }

        /// <summary>
        /// Initializes a new instance of the CoreWebView2StringCollectionShim class.
        /// </summary>
        /// <param name="iface">The COM interface to wrap</param>
        public CoreWebView2StringCollectionShim(ICoreWebView2StringCollection iface)
        {
            Iface = iface;
        }

        #region Properties

        /// <summary>
        /// Gets the Count property.
        /// </summary>
        public uint Count
        {
            get => Iface.GetCount();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Wraps the GetValueAtIndex method.
        /// </summary>
        /// <param name="index"></param>
        public string GetValueAtIndex(uint index)
        {
            return Iface.GetValueAtIndex(index);
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
        ~CoreWebView2StringCollectionShim()
        {
            Dispose(disposing: false);
        }
    }
}
