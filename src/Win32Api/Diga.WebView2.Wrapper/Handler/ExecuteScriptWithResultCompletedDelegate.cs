using Diga.WebView2.Interop;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{
    [GeneratedComClass]
    public partial class ExecuteScriptWithResultCompletedDelegate : ICoreWebView2ExecuteScriptWithResultCompletedHandler
    {
        private TaskCompletionSource<WebView2ExecuteScriptResult> _source;
        public ExecuteScriptWithResultCompletedDelegate(TaskCompletionSource<WebView2ExecuteScriptResult> source)
        {
            this._source = source;
        }
        public void Invoke([ MarshalAs(UnmanagedType.Error)] int errorCode, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2ExecuteScriptResult result)
        {
            try
            {
                var r = new WebView2ExecuteScriptResult(result);
                _source.SetResult(r);

            }
            catch (Exception ex)
            {

                Debug.Print("ExecuteScriptWithResultCompletedDelegate error:" + ex.ToString());
            }
        }


    }
}
