using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;

namespace Diga.WebView2.Wrapper.shim
{
    /// <summary>
    /// Shim-Wrapper für ICoreWebView2AcceleratorKeyPressedEventArgs
    /// </summary>
    public class CoreWebView2AcceleratorKeyPressedEventArgsShim : EventArgs, IDisposable
    {
        private ComObjectHolder<ICoreWebView2AcceleratorKeyPressedEventArgs> _Iface;
        private bool disposedValue;
        private SafeHandle handle = new SafeFileHandle(nint.Zero, true);

        /// <summary>
        /// Gets the wrapped COM interface.
        /// </summary>
        private ICoreWebView2AcceleratorKeyPressedEventArgs Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2AcceleratorKeyPressedEventArgsShim) + " Iface is null");
                    throw new InvalidOperationException(nameof(CoreWebView2AcceleratorKeyPressedEventArgsShim) + " Iface is null");
                }

                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2AcceleratorKeyPressedEventArgs>(value);
        }

        /// <summary>
        /// Initializes a new instance of the CoreWebView2AcceleratorKeyPressedEventArgsShim class.
        /// </summary>
        /// <param name="iface">The COM interface to wrap</param>
        public CoreWebView2AcceleratorKeyPressedEventArgsShim(ICoreWebView2AcceleratorKeyPressedEventArgs iface)
        {
            Iface = iface;
        }

        #region Properties

        /// <summary>
        /// Gets the KeyEventKind property.
        /// </summary>
        public COREWEBVIEW2_KEY_EVENT_KIND KeyEventKind
        {
            get => Iface.GetKeyEventKind();
        }

        /// <summary>
        /// Gets the VirtualKey property.
        /// </summary>
        public uint VirtualKey
        {
            get => Iface.GetVirtualKey();
        }

        /// <summary>
        /// Gets the KeyEventLParam property.
        /// </summary>
        public int KeyEventLParam
        {
            get => Iface.GetKeyEventLParam();
        }

        /// <summary>
        /// Gets the PhysicalKeyStatus property.
        /// </summary>
        public COREWEBVIEW2_PHYSICAL_KEY_STATUS PhysicalKeyStatus
        {
            get => Iface.GetPhysicalKeyStatus();
        }

        /// <summary>
        /// Gets the Handled property.
        /// </summary>
        public bool Handled
        {
            get => Iface.GetHandled();
            set => Iface.SetHandled(value);
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
        ~CoreWebView2AcceleratorKeyPressedEventArgsShim()
        {
            Dispose(disposing: false);
        }
    }
}
