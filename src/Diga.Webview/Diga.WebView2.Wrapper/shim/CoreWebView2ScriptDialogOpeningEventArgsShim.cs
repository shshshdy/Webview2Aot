using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2ScriptDialogOpeningEventArgsShim : IDisposable
    {
        private ComObjectHolder<ICoreWebView2ScriptDialogOpeningEventArgs> _Args;
        private bool _IsDisposed;
        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private SafeHandle handle = new SafeFileHandle(nint.Zero, true);
        private ICoreWebView2ScriptDialogOpeningEventArgs Args
        {
            get
            {
                if (_Args == null)
                {
                    Debug.Print(nameof(CoreWebView2ScriptDialogOpeningEventArgsShim) + "=>" + nameof(Args) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2ScriptDialogOpeningEventArgsShim) + "=>" + nameof(Args) + " is null");
                }
                return _Args.Interface;
            }
            set { _Args = new ComObjectHolder<ICoreWebView2ScriptDialogOpeningEventArgs>(value); }
        }

        public CoreWebView2ScriptDialogOpeningEventArgsShim(ICoreWebView2ScriptDialogOpeningEventArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));
            Args = args;
        }
        public string uri => Args.Geturi();

        public COREWEBVIEW2_SCRIPT_DIALOG_KIND Kind => Args.GetKind();

        public string Message => Args.GetMessage();

        public void Accept()
        {
            Args.Accept();
        }

        public string DefaultText => Args.GetDefaultText();

        public string ResultText { get => Args.GetResultText(); set => Args.SetResultText(value); }

        [return: MarshalAs(UnmanagedType.Interface)]
        public ICoreWebView2Deferral GetDeferral()
        {
            return Args.GetDeferral();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_IsDisposed)
            {
                if (disposing)
                {
                    handle.Dispose();
                    _Args = null;
                }

                _IsDisposed = true;
            }
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
