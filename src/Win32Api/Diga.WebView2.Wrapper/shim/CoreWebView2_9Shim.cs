using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2_9Shim : CoreWebView2_8Shim
    {
        private ComObjectHolder<ICoreWebView2_9> _WebView;
        private ICoreWebView2_9 WebView
        {
            get
            {
                if (this._WebView == null)
                {
                    Debug.Print(nameof(CoreWebView2_8Shim) + "." + nameof(this.WebView) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2_8Shim) + "." + nameof(this.WebView) + " is null");

                }
                return this._WebView.Interface;
            }
            set => this._WebView = new ComObjectHolder<ICoreWebView2_9>(value);
        }
        public CoreWebView2_9Shim(ICoreWebView2_9 webView) : base(webView)
        {
            this.WebView = webView ?? throw new ArgumentNullException(nameof(webView));
        }

        public void add_IsDefaultDownloadDialogOpenChanged([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token)
        {
            this.WebView.add_IsDefaultDownloadDialogOpenChanged(handler, out token);
        }

        public void remove_IsDefaultDownloadDialogOpenChanged([In] EventRegistrationToken token)
        {
            this.WebView.remove_IsDefaultDownloadDialogOpenChanged(token);
        }

        public int IsDefaultDownloadDialogOpen => this.WebView.GetIsDefaultDownloadDialogOpen();

        public void OpenDefaultDownloadDialog()
        {
            this.WebView.OpenDefaultDownloadDialog();
        }

        public void CloseDefaultDownloadDialog()
        {
            this.WebView.CloseDefaultDownloadDialog();
        }

        public COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT DefaultDownloadDialogCornerAlignment { get => this.WebView.GetDefaultDownloadDialogCornerAlignment(); set => this.WebView.SetDefaultDownloadDialogCornerAlignment(value); }
        public POINT DefaultDownloadDialogMargin { get => this.WebView.GetDefaultDownloadDialogMargin(); set => this.WebView.SetDefaultDownloadDialogMargin(value); }
    }
}
