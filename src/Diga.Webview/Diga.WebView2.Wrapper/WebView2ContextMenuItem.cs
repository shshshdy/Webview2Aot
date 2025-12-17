using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;
using Diga.WebView2.Wrapper.Types;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper
{
    public class WebView2ContextMenuItem:CoreWebView2ContextMenuItemShim
    {
        public event EventHandler<WebView2ContextMenuItem> CustomItemSelected;
        private EventRegistrationToken _CustomItemSelectedToken;
        public WebView2ContextMenuItem(ICoreWebView2ContextMenuItem item):base(item)
        {

        }

        private void WireEvents()
        {
            AddCustomItemSelectedEvent();
        }
        private void UnWireEvents()
        {
            EventRegistrationTool.UnWireToken(this._CustomItemSelectedToken,
                base.remove_CustomItemSelected);
        }

        private void AddCustomItemSelectedEvent()
        {
            try
            {
                WebView2CustomItemSelectEventHanlder hanlder = new WebView2CustomItemSelectEventHanlder();
                hanlder.Selected += OnCustomItemSelectIntern;
                base.add_CustomItemSelected(hanlder, out this._CustomItemSelectedToken);
            }
            catch (InvalidCastException ex)
            {
                if (ex.HResult == HRESULT.E_NOINTERFACE)
                    throw new InvalidOperationException($"{nameof(AddCustomItemSelectedEvent)} accessed outside UI-Thread");
                throw;
            }
            catch (COMException ex)
            {
                if (ex.HResult == HRESULT.E_INVALID_STATE)
                    throw new InvalidOperationException("WebView2 already disposed");

                throw;
            }
        }
        private void OnCustomItemSelectIntern(object sender, WebView2ContextMenuItem e)
        {
            OnCustomItemSelected(e);
        }
        protected virtual void OnCustomItemSelected(WebView2ContextMenuItem e)
        {
            CustomItemSelected?.Invoke(this, e);
        }

       
    }
}
