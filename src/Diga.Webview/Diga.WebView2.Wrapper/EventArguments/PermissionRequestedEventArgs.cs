using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;

namespace Diga.WebView2.Wrapper.EventArguments
{
    public class PermissionRequestedEventArgs : CoreWebView2PermissionRequestedEventArgsShim
    {


        public PermissionRequestedEventArgs(ICoreWebView2PermissionRequestedEventArgs args) : base(args)
        {

        }


        public string Uri => base.uri;


        public COREWEBVIEW2_PERMISSION_KIND PermissionType => base.PermissionKind;


        public new WebView2Deferral GetDeferral()
        {
            return new WebView2Deferral(base.GetDeferral());
        }




    }
}
