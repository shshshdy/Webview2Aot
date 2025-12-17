using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{
    [GeneratedComClass]
    public partial class AddScriptToExecuteOnDocumentCreatedCompletedHandler : ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler
    {
        public event EventHandler<AddScriptToExecuteOnDocumentCreatedCompletedEventArgs> ScriptExecuted;
        public void Invoke(int errorCode, string id)
        {
            try
            {
                OnScriptExecuted(new AddScriptToExecuteOnDocumentCreatedCompletedEventArgs(errorCode, id));
            }
            catch (Exception ex)
            {

                Debug.Print("AddScriptToExecuteOnDocumentCreatedCompletedHandler Exception=>" + ex.ToString());
            }

        }

        protected virtual void OnScriptExecuted(AddScriptToExecuteOnDocumentCreatedCompletedEventArgs e)
        {
            ScriptExecuted?.Invoke(this, e);
        }
    }
}
