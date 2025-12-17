using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{


    [GeneratedComClass]
    public partial class SourceChangedEventHandler : ICoreWebView2SourceChangedEventHandler
    {
        public event EventHandler<SourceChangedEventArgs> SourceChanged;
        public void Invoke(ICoreWebView2 webview, ICoreWebView2SourceChangedEventArgs args)
        {
            try
            {
                bool isNew = args.GetIsNewDocument();
                
                string url = webview.GetSource();
                OnSourceChanged(new SourceChangedEventArgs(isNew,url));
            }
            catch (Exception ex)
            {
                Debug.Print(nameof(SourceChangedEventHandler) + " Exception:" + ex.ToString());

            }

        }

        protected virtual void OnSourceChanged(SourceChangedEventArgs e)
        {
            SourceChanged?.Invoke(this, e);
        }
    }
}
