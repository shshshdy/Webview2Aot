using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{

    [GeneratedComClass]
    public partial class CursorChangedEventHandler : ICoreWebView2CursorChangedEventHandler
    {
        public event EventHandler<CursorChangedEventArgs> CursorChanged;
        public void Invoke(ICoreWebView2CompositionController sender, object args)
        {
            try
            {
                OnCursorChanged(new CursorChangedEventArgs((ICoreWebView2CompositionController2)sender, args));
            }
            catch (Exception ex)
            {
                Debug.Print(nameof(CursorChangedEventHandler) + " Exception:" + ex.ToString());

            }


        }

        protected virtual void OnCursorChanged(CursorChangedEventArgs e)
        {
            CursorChanged?.Invoke(this, e);
        }
    }
}
