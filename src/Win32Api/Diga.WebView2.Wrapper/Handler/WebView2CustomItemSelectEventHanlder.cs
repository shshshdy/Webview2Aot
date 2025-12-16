using Diga.WebView2.Interop;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security;

namespace Diga.WebView2.Wrapper
{
    [GeneratedComClass]
    public partial class WebView2CustomItemSelectEventHanlder : ICoreWebView2CustomItemSelectedEventHandler
    {
        public event EventHandler<WebView2ContextMenuItem> Selected;
        [SecurityCritical]
#pragma warning disable SYSLIB0032
        [HandleProcessCorruptedStateExceptions]
#pragma warning restore SYSLIB0032
        public void Invoke(ICoreWebView2ContextMenuItem sender, object args)
        {
            try
            {

                OnSelected(new WebView2ContextMenuItem(sender));
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
            }
        }

        private void OnSelected(WebView2ContextMenuItem e)
        {
            Selected?.Invoke(this, e);
        }
    }
}
