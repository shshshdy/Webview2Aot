using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;

namespace Diga.WebView2.Wrapper.shim
{
    /// <summary>
    /// Shim-Wrapper für ICoreWebView2WebResourceRequestedEventArgs2
    /// </summary>
    public class CoreWebView2WebResourceRequestedEventArgs2Shim : CoreWebView2WebResourceRequestedEventArgsShim
    {
        private ComObjectHolder<ICoreWebView2WebResourceRequestedEventArgs2> _Iface;
        private SafeHandle handle = new SafeFileHandle(nint.Zero, true);

        /// <summary>
        /// Gets the wrapped COM interface.
        /// </summary>
        private ICoreWebView2WebResourceRequestedEventArgs2 Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2WebResourceRequestedEventArgs2Shim) + " Iface is null");
                    throw new InvalidOperationException(nameof(CoreWebView2WebResourceRequestedEventArgs2Shim) + " Iface is null");
                }

                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2WebResourceRequestedEventArgs2>(value);
        }

        /// <summary>
        /// Initializes a new instance of the CoreWebView2WebResourceRequestedEventArgs2Shim class.
        /// </summary>
        /// <param name="iface">The COM interface to wrap</param>
        public CoreWebView2WebResourceRequestedEventArgs2Shim(ICoreWebView2WebResourceRequestedEventArgs2 iface) : base((ICoreWebView2WebResourceRequestedEventArgs)iface)
        {
            Iface = iface;
        }

        #region Properties

        /// <summary>
        /// Gets the RequestedSourceKind property.
        /// </summary>
        public COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS RequestedSourceKind
        {
            get => Iface.GetRequestedSourceKind();
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
