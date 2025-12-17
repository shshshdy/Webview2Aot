using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{

    [GeneratedComClass]
    public partial class StateChangedEventHandler : ICoreWebView2StateChangedEventHandler
    {
        public event EventHandler<WebView2EventArgs> StateChanged;
        public void Invoke([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2DownloadOperation sender, [In, MarshalAs(UnmanagedType.IUnknown)] object args)
        {
            OnStateChanged(sender, args);
        }

        private void OnStateChanged(ICoreWebView2DownloadOperation sender, object obj)
        {
            StateChanged?.Invoke(sender, new WebView2EventArgs(sender, obj));
        }
    }
}
