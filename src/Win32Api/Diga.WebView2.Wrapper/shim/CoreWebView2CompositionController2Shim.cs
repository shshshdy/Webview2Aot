using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2CompositionController2Shim : CoreWebView2CompositionControllerShim
    {
        private ComObjectHolder<ICoreWebView2CompositionController2> _Controller;
        private ICoreWebView2CompositionController2 Controller
        {
            get
            {
                if (_Controller == null)
                {
                    Debug.Print(nameof(CoreWebView2CompositionController2Shim) + "=>" + nameof(Controller) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2CompositionController2Shim) + "=>" + nameof(Controller) + " is null");
                }
                return _Controller.Interface;
            }
            set
            {
                _Controller = new ComObjectHolder<ICoreWebView2CompositionController2>(value);
            }
        }
        public CoreWebView2CompositionController2Shim(ICoreWebView2CompositionController2 controller) : base(controller)
        {
            Controller = controller ?? throw new ArgumentNullException(nameof(controller));
        }
        public object UIAProvider => Controller.AutomationProvider();
        private bool _IsDisposed;
        protected override void Dispose(bool disposing)
        {
            if (_IsDisposed) return;

            if (disposing)
            {
                _Controller = null;
                _IsDisposed = true;
            }
            base.Dispose(disposing);
        }



    }
}
