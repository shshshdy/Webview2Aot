using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{


    [GeneratedComClass]
    public partial class ControllerCompletedHandler : ICoreWebView2CreateCoreWebView2ControllerCompletedHandler
    {
        public event EventHandler<ControllerCompletedArgs> ControllerCompleted;
        public event EventHandler<ControllerCompletedErrorArgs> ControllerCompletedError;
        public event EventHandler<BeforeControllerCreateEventArgs> BeforeControllerCreate;

        public void Invoke([MarshalAs(UnmanagedType.Error)] int errorCode, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2Controller createdController)
        {
            ICoreWebView2 webView = null;
            ICoreWebView2Controller controller = null;
            if (createdController != null)
            {
                controller = createdController;
                webView = controller.GetCoreWebView2();
                if (webView == null)
                {
                    OnHostCompletedError(new ControllerCompletedErrorArgs(errorCode, "Could not create WebView2!"));
                    return;
                }
            }
            else
            {
                OnHostCompletedError(new ControllerCompletedErrorArgs(errorCode, "Could not create Controller!"));
                return;
            }

            webView.AddWebResourceRequestedFilter("*",
                    COREWEBVIEW2_WEB_RESOURCE_CONTEXT.COREWEBVIEW2_WEB_RESOURCE_CONTEXT_ALL);
            ICoreWebView2Settings settings = webView.GetSettings();
            OnBeforeControllerCreate(new BeforeControllerCreateEventArgs(webView, controller, settings));
            //settings.SetIsScriptEnabled(new CBOOL(true));
            //settings.SetAreDefaultContextMenusEnabled((CBOOL)true);
            //settings.SetIsWebMessageEnabled((CBOOL)true);

            RECT rect;
            Native.GetClientRect(createdController.GetParentWindow(), out rect);
            controller.SetBounds( rect);
            OnControllerCompleted(new ControllerCompletedArgs(controller, webView));
        }

        protected virtual void OnControllerCompleted(ControllerCompletedArgs e)
        {
            ControllerCompleted?.Invoke(this, e);
        }

        protected virtual void OnHostCompletedError(ControllerCompletedErrorArgs e)
        {
            ControllerCompletedError?.Invoke(this, e);
        }

        protected virtual void OnBeforeControllerCreate(BeforeControllerCreateEventArgs e)
        {
            BeforeControllerCreate?.Invoke(this, e);
        }
    }
}
