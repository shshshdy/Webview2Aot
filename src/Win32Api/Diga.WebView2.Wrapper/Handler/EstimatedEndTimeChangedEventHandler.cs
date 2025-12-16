using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{

    [GeneratedComClass]
    public partial class EstimatedEndTimeChangedEventHandler : ICoreWebView2EstimatedEndTimeChangedEventHandler
    {
        public event EventHandler<WebView2EventArgs> EstimatedEndTimeChanged;
        public void Invoke([MarshalAs(UnmanagedType.Interface)] ICoreWebView2DownloadOperation sender, [MarshalAs(UnmanagedType.Interface)] object args)
        {
            OnEstimatedEndTimeChanged(sender, args);
        }
        private void OnEstimatedEndTimeChanged(ICoreWebView2DownloadOperation sender, object obj)
        {
            EstimatedEndTimeChanged?.Invoke(sender, new WebView2EventArgs(sender, obj));
        }
    }
}
