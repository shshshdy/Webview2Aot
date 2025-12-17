namespace Diga.WebView2.Wrapper.EventArguments
{
    public class PrintToPdfCompleteEventArgs : EventArgs
    {
        public bool IsSuccessfunl { get; }
        public int ErrorCode { get; }

        public PrintToPdfCompleteEventArgs(bool isSuccessfunl, int errorCode)
        {
            this.IsSuccessfunl = isSuccessfunl;
            this.ErrorCode = errorCode;
        }
    }
}
