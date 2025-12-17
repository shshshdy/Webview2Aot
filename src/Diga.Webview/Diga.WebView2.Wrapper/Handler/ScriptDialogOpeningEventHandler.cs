using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{
    [GeneratedComClass]
    public partial class ScriptDialogOpeningEventHandler : ICoreWebView2ScriptDialogOpeningEventHandler
    {
        public event EventHandler<ScriptDialogOpeningEventArgs> ScriptDialogOpening;


        private void OnScriptDialogOpening(ScriptDialogOpeningEventArgs e)
        {
            this.ScriptDialogOpening?.Invoke(this, e);
        }

        public void Invoke(ICoreWebView2 sender, ICoreWebView2ScriptDialogOpeningEventArgs args)
        {
            try
            {
                OnScriptDialogOpening(new ScriptDialogOpeningEventArgs(args));
            }
            catch (Exception ex)
            {

                Debug.Print(nameof(ScriptDialogOpeningEventHandler) + " Exception:" + ex.ToString());
            }

        }
    }
}
