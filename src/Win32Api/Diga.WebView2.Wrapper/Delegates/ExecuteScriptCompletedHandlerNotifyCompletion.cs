using Diga.WebView2.Interop;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{

    [GeneratedComClass]
    public partial class ExecuteScriptCompletedHandlerNotifyCompletion : ICoreWebView2ExecuteScriptCompletedHandler, INotifyCompletion
    {
        private Action _Continuation;

        public int ErrorCode { get; private set; }
        public string ResultAsJson { get; private set; }
        public bool IsCompleted { get; private set; }

        public ExecuteScriptCompletedHandlerNotifyCompletion GetAwaiter()
        {
            return this;
        }

        public string GetResult()
        {
            return this.ResultAsJson;
        }
        public ExecuteScriptCompletedHandlerNotifyCompletion()
        {
            this.IsCompleted = false;
        }
        public void Invoke(int errorCode, [MarshalAs(UnmanagedType.LPWStr)] string resultObjectAsJson)
        {
            this.ResultAsJson = resultObjectAsJson;
            this.ErrorCode = errorCode;
            this.IsCompleted = true;
            if (this._Continuation == null)
                return;
            this._Continuation();
        }

        public void OnCompleted(Action continuation)
        {
            this._Continuation = continuation;
            if (!this.IsCompleted)
                return;
            continuation();
        }
    }
}
