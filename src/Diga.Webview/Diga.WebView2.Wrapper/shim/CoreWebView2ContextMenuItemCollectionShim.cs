using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{


    public class CoreWebView2ContextMenuItemCollectionShim : IDisposable
    {
        private ComObjectHolder<ICoreWebView2ContextMenuItemCollection> _Iface;
        private bool _IsDesposed;

        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private SafeHandle handle = new SafeFileHandle(nint.Zero, true);
        public CoreWebView2ContextMenuItemCollectionShim(ICoreWebView2ContextMenuItemCollection iface)
        {
            Iface = iface ?? throw new ArgumentNullException(nameof(iface));
        }

        private ICoreWebView2ContextMenuItemCollection Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2ContextMenuItemCollectionShim) + "=>" + nameof(Iface) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2ContextMenuItemCollectionShim) + "=>" + nameof(Iface) + " is null");
                }

                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2ContextMenuItemCollection>(value);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_IsDesposed)
            {
                if (disposing)
                {
                    handle.Dispose();
                    _Iface = null;
                }

                _IsDesposed = true;
            }
        }

        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public uint Count => Iface.GetCount();

        [return: MarshalAs(UnmanagedType.Interface)]
        public ICoreWebView2ContextMenuItem GetValueAtIndex(uint index)
        {
            return Iface.GetValueAtIndex(index);
        }

        public void RemoveValueAtIndex([In] uint index)
        {
            Iface.RemoveValueAtIndex(index);
        }

        public void InsertValueAtIndex([In] uint index, [In] ICoreWebView2ContextMenuItem value)
        {
            Iface.InsertValueAtIndex(index, value);
        }
    }
}
