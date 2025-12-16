using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2SettingsShim : IDisposable
    {
        private ComObjectHolder<ICoreWebView2Settings> _Settings;
        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private readonly SafeHandle handle = new SafeFileHandle(nint.Zero, true);
        private ICoreWebView2Settings Settings
        {
            get
            {
                if (_Settings == null)
                {
                    Debug.Print(nameof(CoreWebView2SettingsShim) + "." + nameof(Settings) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2SettingsShim) + "." + nameof(Settings) + " is null");

                }
                return _Settings.Interface;
            }
            set => _Settings = new ComObjectHolder<ICoreWebView2Settings>(value);
        }



        public CoreWebView2SettingsShim(ICoreWebView2Settings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));
            Settings = settings;
        }

        public int IsScriptEnabled { get => Settings.GetIsScriptEnabled(); set => Settings.SetIsScriptEnabled(value); }
        public int IsWebMessageEnabled { get => Settings.GetIsWebMessageEnabled(); set => Settings.SetIsWebMessageEnabled(value); }
        public int AreDefaultScriptDialogsEnabled { get => Settings.GetAreDefaultScriptDialogsEnabled(); set => Settings.SetAreDefaultScriptDialogsEnabled(value); }
        public int IsStatusBarEnabled { get => Settings.GetIsStatusBarEnabled(); set => Settings.SetIsStatusBarEnabled(value); }
        public int AreDevToolsEnabled { get => Settings.GetAreDevToolsEnabled(); set => Settings.SetAreDevToolsEnabled(value); }
        public int AreDefaultContextMenusEnabled { get => Settings.GetAreDefaultContextMenusEnabled(); set => Settings.SetAreDefaultContextMenusEnabled(value); }
        public int AreHostObjectsAllowed { get => Settings.GetAreHostObjectsAllowed(); set => Settings.SetAreHostObjectsAllowed(value); }
        public int IsZoomControlEnabled { get => Settings.GetIsZoomControlEnabled(); set => Settings.SetIsZoomControlEnabled(value); }
        public int IsBuiltInErrorPageEnabled { get => Settings.GetIsBuiltInErrorPageEnabled(); set => Settings.SetIsBuiltInErrorPageEnabled(value); }

        private bool _IsDisposed;
        protected virtual void Dispose(bool disposing)
        {
            if (_IsDisposed) return;
            if (disposing)
            {
                handle.Dispose();
                _Settings = null;
                _IsDisposed = true;
            }
        }


        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
