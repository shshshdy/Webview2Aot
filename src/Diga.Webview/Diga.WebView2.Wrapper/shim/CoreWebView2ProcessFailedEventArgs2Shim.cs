using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2ProcessFailedEventArgs2Shim : CoreWebView2ProcessFailedEventArgsShim
    {
        private ComObjectHolder<ICoreWebView2ProcessFailedEventArgs2> _Args;

        private ICoreWebView2ProcessFailedEventArgs2 Args
        {
            get
            {
                if (_Args == null)
                {
                    Debug.Print(nameof(CoreWebView2ProcessFailedEventArgs2Shim) + " Args is null");
                    throw new InvalidOperationException(nameof(CoreWebView2ProcessFailedEventArgs2Shim) + " Args is null");
                }

                return _Args.Interface;
            }
            set => _Args = new ComObjectHolder<ICoreWebView2ProcessFailedEventArgs2>(value);
        }
        public CoreWebView2ProcessFailedEventArgs2Shim(ICoreWebView2ProcessFailedEventArgs2 args) : base(args)
        {
            Args = args;
        }

        public COREWEBVIEW2_PROCESS_FAILED_REASON reason => Args.Getreason();

        public int ExitCode => Args.GetExitCode();

        public string ProcessDescription => Args.GetProcessDescription();

        public ICoreWebView2FrameInfoCollection FrameInfosForFailedProcess => Args.GetFrameInfosForFailedProcess();

        private bool disposedValue;
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!disposedValue)
                {
                    _Args = null;
                }

                disposedValue = true;
            }
            base.Dispose(disposing);
        }
    }
}
