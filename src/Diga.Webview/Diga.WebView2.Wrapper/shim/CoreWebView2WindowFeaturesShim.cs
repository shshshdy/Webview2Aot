using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;

namespace Diga.WebView2.Wrapper.shim
{
    /// <summary>
    /// Shim-Wrapper für ICoreWebView2WindowFeatures
    /// </summary>
    public class CoreWebView2WindowFeaturesShim : IDisposable
    {
        private ComObjectHolder<ICoreWebView2WindowFeatures> _Iface;
        private bool disposedValue;
        private SafeHandle handle = new SafeFileHandle(nint.Zero, true);

        /// <summary>
        /// Gets the wrapped COM interface.
        /// </summary>
        private ICoreWebView2WindowFeatures Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2WindowFeaturesShim) + " Iface is null");
                    throw new InvalidOperationException(nameof(CoreWebView2WindowFeaturesShim) + " Iface is null");
                }

                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2WindowFeatures>(value);
        }

        /// <summary>
        /// Initializes a new instance of the CoreWebView2WindowFeaturesShim class.
        /// </summary>
        /// <param name="iface">The COM interface to wrap</param>
        public CoreWebView2WindowFeaturesShim(ICoreWebView2WindowFeatures iface)
        {
            Iface = iface;
        }

        #region Properties

        /// <summary>
        /// Gets the HasPosition property.
        /// </summary>
        public bool HasPosition
        {
            get => Iface.GetHasPosition();
        }

        /// <summary>
        /// Gets the HasSize property.
        /// </summary>
        public bool HasSize
        {
            get => Iface.GetHasSize();
        }

        /// <summary>
        /// Gets the Left property.
        /// </summary>
        public uint Left
        {
            get => Iface.GetLeft();
        }

        /// <summary>
        /// Gets the Top property.
        /// </summary>
        public uint Top
        {
            get => Iface.GetTop();
        }

        /// <summary>
        /// Gets the Height property.
        /// </summary>
        public uint Height
        {
            get => Iface.GetHeight();
        }

        /// <summary>
        /// Gets the Width property.
        /// </summary>
        public uint Width
        {
            get => Iface.GetWidth();
        }

        /// <summary>
        /// Gets the ShouldDisplayMenuBar property.
        /// </summary>
        public bool ShouldDisplayMenuBar
        {
            get => Iface.GetShouldDisplayMenuBar();
        }

        /// <summary>
        /// Gets the ShouldDisplayStatus property.
        /// </summary>
        public bool ShouldDisplayStatus
        {
            get => Iface.GetShouldDisplayStatus();
        }

        /// <summary>
        /// Gets the ShouldDisplayToolbar property.
        /// </summary>
        public bool ShouldDisplayToolbar
        {
            get => Iface.GetShouldDisplayToolbar();
        }

        /// <summary>
        /// Gets the ShouldDisplayScrollBars property.
        /// </summary>
        public bool ShouldDisplayScrollBars
        {
            get => Iface.GetShouldDisplayScrollBars();
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
        ~CoreWebView2WindowFeaturesShim()
        {
            Dispose(disposing: false);
        }
    }
}
