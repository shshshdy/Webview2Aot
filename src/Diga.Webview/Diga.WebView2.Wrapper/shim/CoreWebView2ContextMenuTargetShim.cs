using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{

   
    public class CoreWebView2ContextMenuTargetShim : IDisposable//, ICoreWebView2ContextMenuTarget
    {
        private ComObjectHolder<ICoreWebView2ContextMenuTarget> _Args;

        private bool disposedValue;
        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private SafeHandle handle = new SafeFileHandle(nint.Zero, true);
        private ICoreWebView2ContextMenuTarget Args
        {
            get
            {
                if (_Args == null)
                {
                    Debug.Print(nameof(CoreWebView2ContextMenuTargetShim) + "." + nameof(_Args) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2ContextMenuTargetShim) + "." + nameof(_Args) + " is null");

                }
                return this._Args.Interface;
            }
            set => this._Args = new ComObjectHolder<ICoreWebView2ContextMenuTarget>(value);
        }

        public CoreWebView2ContextMenuTargetShim(ICoreWebView2ContextMenuTarget args)
        {
            this.Args = args ?? throw new ArgumentNullException(nameof(args));
        }

        public COREWEBVIEW2_CONTEXT_MENU_TARGET_KIND Kind => this.Args.GetKind();

        public int IsEditable => this.Args.GetIsEditable();

        public int IsRequestedForMainFrame => this.Args.GetIsRequestedForMainFrame();

        public string PageUri => this.Args.GetPageUri();

        public string FrameUri => this.Args.GetFrameUri();

        public int HasLinkUri => this.Args.GetHasLinkUri();

        public string LinkUri => this.Args.GetLinkUri();

        public int HasLinkText => this.Args.GetHasLinkText();

        public string LinkText => this.Args.GetLinkText();

        public int HasSourceUri => this.Args.GetHasSourceUri();

        public string SourceUri => this.Args.GetSourceUri();

        public int HasSelection => this.Args.GetHasSelection();

        public string SelectionText => this.Args.GetSelectionText();

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.handle.Dispose();
                    this._Args = null;
                }


                this.disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
