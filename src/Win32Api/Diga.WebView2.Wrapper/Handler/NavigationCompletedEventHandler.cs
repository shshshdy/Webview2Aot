using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{
    [GeneratedComClass]
    public partial class NavigationCompletedEventHandler : ICoreWebView2NavigationCompletedEventHandler
    {
        public event EventHandler<NavigationCompletedEventArgs> NavigaionCompleted;
        public void Invoke(ICoreWebView2 sender, ICoreWebView2NavigationCompletedEventArgs args)
        {
            try
            {


                CBOOL isSuccess = args.GetIsSuccess();
                NavigationCompletedEventArgs eventArgs = new NavigationCompletedEventArgs((ErrorStatus)args.GetWebErrorStatus(), isSuccess, args.GetNavigationId());
                OnNavigaionCompleted(eventArgs);
            }
            catch (Exception ex)
            {

                Debug.Print(nameof(NavigationCompletedEventHandler) + " Exception:" + ex.ToString());
            }
        }

        protected virtual void OnNavigaionCompleted(NavigationCompletedEventArgs e)
        {
            NavigaionCompleted?.Invoke(this, e);
        }
    }
}
