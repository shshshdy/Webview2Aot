using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;

namespace Diga.WebView2.Wrapper.shim
{
    /// <summary>
    /// Shim-Wrapper für ICoreWebView2AcceleratorKeyPressedEventArgs2
    /// </summary>
    public class CoreWebView2AcceleratorKeyPressedEventArgs2Shim : CoreWebView2AcceleratorKeyPressedEventArgsShim
    {
        private ComObjectHolder<ICoreWebView2AcceleratorKeyPressedEventArgs2> _Iface;
        private SafeHandle handle = new SafeFileHandle(nint.Zero, true);

        /// <summary>
        /// Gets the wrapped COM interface.
        /// </summary>
        private ICoreWebView2AcceleratorKeyPressedEventArgs2 Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2AcceleratorKeyPressedEventArgs2Shim) + " Iface is null");
                    throw new InvalidOperationException(nameof(CoreWebView2AcceleratorKeyPressedEventArgs2Shim) + " Iface is null");
                }

                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2AcceleratorKeyPressedEventArgs2>(value);
        }

        /// <summary>
        /// Initializes a new instance of the CoreWebView2AcceleratorKeyPressedEventArgs2Shim class.
        /// </summary>
        /// <param name="iface">The COM interface to wrap</param>
        public CoreWebView2AcceleratorKeyPressedEventArgs2Shim(ICoreWebView2AcceleratorKeyPressedEventArgs2 iface) : base((ICoreWebView2AcceleratorKeyPressedEventArgs)iface)
        {
            Iface = iface;
        }

        #region Properties

        /// <summary>
        /// Gets the IsBrowserAcceleratorKeyEnabled property.
        /// </summary>
        public bool IsBrowserAcceleratorKeyEnabled
        {
            get => Iface.GetIsBrowserAcceleratorKeyEnabled();
            set => Iface.SetIsBrowserAcceleratorKeyEnabled(value);
        }

        #endregion


        /// <summary>
        /// Protected override dispose method.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                handle?.Dispose();
                _Iface = null;
            }
            base.Dispose(disposing);
        }
    }
}
