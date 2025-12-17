using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Controller2Shim : CoreWebView2ControllerShim
    {
        private ComObjectHolder<ICoreWebView2Controller2> _Controller;
        public CoreWebView2Controller2Shim(ICoreWebView2Controller2 controller) : base(controller)
        {
            if (controller == null)
                throw new ArgumentNullException(nameof(controller));

            Controller = controller;
        }
        public COREWEBVIEW2_COLOR DefaultBackgroundColor { get => Controller.GetDefaultBackgroundColor(); set => Controller.SetDefaultBackgroundColor(value); }
        private ICoreWebView2Controller2 Controller
        {
            get
            {
                if (_Controller == null)
                {
                    Debug.Print(nameof(CoreWebView2Controller2Shim) + "=>" + nameof(Controller) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2Controller2Shim) + "=>" + nameof(Controller) + " is null");
                }
                return _Controller.Interface;
            }
            set => _Controller = new ComObjectHolder<ICoreWebView2Controller2>(value);
        }

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
