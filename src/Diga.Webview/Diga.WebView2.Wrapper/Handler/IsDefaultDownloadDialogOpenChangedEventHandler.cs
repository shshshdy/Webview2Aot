using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{

    [GeneratedComClass]
    public partial class IsDefaultDownloadDialogOpenChangedEventHandler : ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler
    {
        public event EventHandler<WebView2EventArgs> IsDefaultDownloadDialogOpenChanged;
        public void Invoke(ICoreWebView2 sender, object args)
        {
            try
            {
                OnIsDefaultDownloadDialogOpenChanged(new WebView2EventArgs(sender, args));
            }
            catch (Exception ex)
            {

                Debug.Print(nameof(IsDefaultDownloadDialogOpenChangedEventHandler) + " Exception:" + ex.ToString());
            }
        }

        private void OnIsDefaultDownloadDialogOpenChanged(WebView2EventArgs e)
        {
            IsDefaultDownloadDialogOpenChanged?.Invoke(this, e);
        }
    }
}
