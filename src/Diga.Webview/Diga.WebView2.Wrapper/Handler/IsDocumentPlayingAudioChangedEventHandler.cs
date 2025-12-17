using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{
    [GeneratedComClass]
    public partial class IsDocumentPlayingAudioChangedEventHandler : ICoreWebView2IsDocumentPlayingAudioChangedEventHandler
    {
        public event EventHandler<WebView2EventArgs> IsDocumentPlayingAudioChanged;
        public void Invoke(ICoreWebView2 sender, object args)
        {
            try
            {
                OnIsDocumentPlayingAudioChanged(new WebView2EventArgs(sender, args));
            }
            catch (Exception ex)
            {

                Debug.Print(nameof(IsDocumentPlayingAudioChangedEventHandler) + " Exception:" + ex.ToString());
            }
        }

        private void OnIsDocumentPlayingAudioChanged(WebView2EventArgs e)
        {
            IsDocumentPlayingAudioChanged?.Invoke(this, e);
        }
    }
}
