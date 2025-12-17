using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Delegates;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{

    [GeneratedComClass]
    public partial class ExecuteScriptCompletedDelegate : ICoreWebView2ExecuteScriptCompletedHandler
    {
        private readonly TaskCompletionSource<ScriptResultType> _Source;

        public ExecuteScriptCompletedDelegate(TaskCompletionSource<ScriptResultType> source)
        {
            this._Source = source;
        }
        void ICoreWebView2ExecuteScriptCompletedHandler.Invoke(int errorCode, string resultObjectAsJson)
        {
            try
            {
                ScriptResultType result = new ScriptResultType
                {
                    ErrorCode = errorCode,
                    ResultAsJson = resultObjectAsJson
                };
                this._Source.SetResult(result);
            }
            catch (Exception ex)
            {
                Debug.Print(nameof(ExecuteScriptCompletedDelegate) + " Exception:" + ex.ToString());

            }



        }
    }
}
