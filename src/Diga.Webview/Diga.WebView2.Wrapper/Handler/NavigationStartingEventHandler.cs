using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{


    [GeneratedComClass]
    public partial class NavigationStartingEventHandler : ICoreWebView2NavigationStartingEventHandler
    {
        public event EventHandler<NavigationStartingEventArgs> NavigationStarting;

        public void Invoke(ICoreWebView2 sender, ICoreWebView2NavigationStartingEventArgs args)
        {
            try
            {
                
                OnNavigationStarting(new NavigationStartingEventArgs((ICoreWebView2NavigationStartingEventArgs3)args));
            }
            catch (Exception ex)
            {
                Debug.Print(nameof(NavigationStartingEventHandler) + " Exception:" + ex.ToString());

            }

        }

        protected virtual void OnNavigationStarting(NavigationStartingEventArgs e)
        {
            NavigationStarting?.Invoke(this, e);
        }
    }
}
