using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;

namespace Diga.WebView2.Wrapper.shim
{



    public class CoreWebView2DownloadStartingEventArgsShim //: ICoreWebView2DownloadStartingEventArgs
    {
        private ComObjectHolder<ICoreWebView2DownloadStartingEventArgs> _Args;

        private ICoreWebView2DownloadStartingEventArgs Args
        {
            get => _Args.Interface;
            set => _Args = new ComObjectHolder<ICoreWebView2DownloadStartingEventArgs>(value);
        }
        public CoreWebView2DownloadStartingEventArgsShim(ICoreWebView2DownloadStartingEventArgs args)
        {
            Args = args;
        }
        public ICoreWebView2DownloadOperation DownloadOperation => Args.GetDownloadOperation();

        public int Cancel
        {
            get => Args.GetCancel();
            set => Args.SetCancel(value);
        }

        public string ResultFilePath
        {
            get => Args.GetResultFilePath();
            set => Args.SetResultFilePath(value);
        }

        public int Handled
        {
            get => Args.GetHandled();
            set => Args.SetHandled(value);
        }

        public ICoreWebView2Deferral GetDeferral()
        {
            return Args.GetDeferral();
        }
    }
}
