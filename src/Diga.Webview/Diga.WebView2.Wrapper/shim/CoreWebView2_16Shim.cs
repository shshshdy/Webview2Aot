using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2_16Shim : CoreWebView2_15Shim //, ICoreWebView2_16
    {
        private ComObjectHolder<ICoreWebView2_16> _WebView;

        private ICoreWebView2_16 WebView
        {
            get
            {
                if (this._WebView == null)
                {
                    Debug.Print(nameof(CoreWebView2_16Shim) + "." + nameof(this.WebView) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2_16Shim) + "." + nameof(this.WebView) + " is null");

                }
                return this._WebView.Interface;
            }
            set => this._WebView = new ComObjectHolder<ICoreWebView2_16>(value);
        }

        public CoreWebView2_16Shim(ICoreWebView2_16 webView) : base(webView)
        {
            this.WebView = webView ?? throw new ArgumentNullException(nameof(webView));
        }

        public void Print([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2PrintSettings printSettings, [In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2PrintCompletedHandler handler)
        {
            this.WebView.Print(printSettings, handler);
        }

        public void ShowPrintUI([In] COREWEBVIEW2_PRINT_DIALOG_KIND printDialogKind)
        {
            this.WebView.ShowPrintUI(printDialogKind);
        }

        public void PrintToPdfStream([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2PrintSettings printSettings, [In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2PrintToPdfStreamCompletedHandler handler)
        {
            this.WebView.PrintToPdfStream(printSettings, handler);
        }
    }
}
