using Diga.WebView2.Interop;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2DownloadOperationShim : IDisposable
    {
        private ICoreWebView2DownloadOperation _DownloadOperation;
        private bool disposedValue;
        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private SafeHandle handle = new SafeFileHandle(nint.Zero, true);
        public CoreWebView2DownloadOperationShim(ICoreWebView2DownloadOperation downloadOperation)
        {
            _DownloadOperation = downloadOperation;
        }

        public void add_BytesReceivedChanged([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2BytesReceivedChangedEventHandler eventHandler, out EventRegistrationToken token)
        {
            _DownloadOperation.add_BytesReceivedChanged(eventHandler, out token);
        }

        public void remove_BytesReceivedChanged([In] EventRegistrationToken token)
        {
            _DownloadOperation.remove_BytesReceivedChanged(token);
        }

        public void add_EstimatedEndTimeChanged([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2EstimatedEndTimeChangedEventHandler eventHandler, out EventRegistrationToken token)
        {
            _DownloadOperation.add_EstimatedEndTimeChanged(eventHandler, out token);
        }

        public void remove_EstimatedEndTimeChanged([In] EventRegistrationToken token)
        {
            _DownloadOperation.remove_EstimatedEndTimeChanged(token);
        }

        public void add_StateChanged([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2StateChangedEventHandler eventHandler, out EventRegistrationToken token)
        {
            _DownloadOperation.add_StateChanged(eventHandler, out token);
        }

        public void remove_StateChanged([In] EventRegistrationToken token)
        {
            _DownloadOperation.remove_StateChanged(token);
        }

        public string uri => _DownloadOperation.Geturi();

        public string ContentDisposition => _DownloadOperation.GetContentDisposition();

        public string MimeType => _DownloadOperation.GetMimeType();

        public long TotalBytesToReceive => _DownloadOperation.GetTotalBytesToReceive();

        public long BytesReceived => _DownloadOperation.GetBytesReceived();

        public string EstimatedEndTime => _DownloadOperation.GetEstimatedEndTime();

        public string ResultFilePath => _DownloadOperation.GetResultFilePath();

        public COREWEBVIEW2_DOWNLOAD_STATE State => _DownloadOperation.GetState();

        public COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON InterruptReason => _DownloadOperation.GetInterruptReason();

        public void Cancel()
        {
            _DownloadOperation.Cancel();
        }

        public void Pause()
        {
            _DownloadOperation.Pause();
        }

        public void Resume()
        {
            _DownloadOperation.Resume();
        }

        public int CanResume => _DownloadOperation.GetCanResume();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    handle.Dispose();
                    _DownloadOperation = null;
                }


                disposedValue = true;
            }
        }



        public void Dispose()
        {

            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
