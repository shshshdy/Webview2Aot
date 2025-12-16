using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2ContextMenuItemShim : IDisposable
    {
        private ComObjectHolder<ICoreWebView2ContextMenuItem> _Iface;
        private bool _IsDesposed;

        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public CoreWebView2ContextMenuItemShim(ICoreWebView2ContextMenuItem iface)
        {
            Iface = iface ?? throw new ArgumentNullException(nameof(iface));
        }

        private ICoreWebView2ContextMenuItem Iface
        {
            get
            {
                if (_Iface == null)
                {
                    Debug.Print(nameof(CoreWebView2ContextMenuItemShim) + "=>" + nameof(Iface) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2ContextMenuItemShim) + "=>" + nameof(Iface) + " is null");
                }

                return _Iface.Interface;
            }
            set => _Iface = new ComObjectHolder<ICoreWebView2ContextMenuItem>(value);
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

        public string name => this.Iface.Getname();

        public string Label => this.Iface.GetLabel();

        public int CommandId => this.Iface.GetCommandId();

        public string ShortcutKeyDescription => this.Iface.GetShortcutKeyDescription();

        public IStream Icon => this.Iface.GetIcon();

        public COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND Kind => this.Iface.GetKind();

        public int IsEnabled { get => this.Iface.GetIsEnabled(); set => this.Iface.SetIsEnabled (value); }
        public int IsChecked { get => this.Iface.GetIsChecked(); set => this.Iface.SetIsChecked (value); }

        public ICoreWebView2ContextMenuItemCollection Children => this.Iface.GetChildren();

        public void add_CustomItemSelected([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2CustomItemSelectedEventHandler eventHandler, out EventRegistrationToken token)
        {
            this.Iface.add_CustomItemSelected(eventHandler, out token);
        }

        public void remove_CustomItemSelected([In] EventRegistrationToken token)
        {
            this.Iface.remove_CustomItemSelected(token);
        }

        public ICoreWebView2ContextMenuItem ToInterface()
        {
            return this.Iface;
        }
    }
}
