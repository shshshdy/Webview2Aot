using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2ProfileShim : IDisposable
    {
        private ComObjectHolder<ICoreWebView2Profile> _Args;
        private bool disposedValue;

        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private readonly SafeHandle handle = new SafeFileHandle(nint.Zero, true);

        private ICoreWebView2Profile Args
        {
            get
            {
                if (_Args == null)
                {
                    Debug.Print(nameof(CoreWebView2ProfileShim) + " Args is null");
                    throw new InvalidOperationException(nameof(CoreWebView2ProfileShim) + " Args is null");
                }

                return _Args.Interface;
            }
            set => _Args = new ComObjectHolder<ICoreWebView2Profile>(value);
        }

        public CoreWebView2ProfileShim(ICoreWebView2Profile profile)
        {
            Args = profile ?? throw new ArgumentNullException(nameof(profile));
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    handle.Dispose();
                }
                disposedValue = true;
            }
        }



        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public string ProfileName => Args.GetProfileName();

        public int IsInPrivateModeEnabled => Args.GetIsInPrivateModeEnabled();

        public string ProfilePath => Args.GetProfilePath();

        public string DefaultDownloadFolderPath { get => Args.GetDefaultDownloadFolderPath(); set => Args.SetDefaultDownloadFolderPath(value); }
        public COREWEBVIEW2_PREFERRED_COLOR_SCHEME PreferredColorScheme { get => Args.GetPreferredColorScheme(); set => Args.SetPreferredColorScheme(value); }
    }
}
