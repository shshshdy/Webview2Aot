using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Controller3Shim : CoreWebView2Controller2Shim
    {
        private ComObjectHolder<ICoreWebView2Controller3> _Controller;
        public CoreWebView2Controller3Shim(ICoreWebView2Controller3 controller) : base(controller)
        {
            if (controller == null)
                throw new ArgumentNullException(nameof(controller));

            Controller = controller;
        }
        public double RasterizationScale { get => Controller.GetRasterizationScale(); set => Controller.SetRasterizationScale(value); }
        public int ShouldDetectMonitorScaleChanges { get => Controller.GetShouldDetectMonitorScaleChanges(); set => Controller.SetShouldDetectMonitorScaleChanges(value); }

        public void add_RasterizationScaleChanged(ICoreWebView2RasterizationScaleChangedEventHandler eventHandler, out EventRegistrationToken token)
        {
            Controller.add_RasterizationScaleChanged(eventHandler, out token);
        }

        public void remove_RasterizationScaleChanged([In] EventRegistrationToken token)
        {
            Controller.remove_RasterizationScaleChanged(token);
        }

        public COREWEBVIEW2_BOUNDS_MODE BoundsMode { get => Controller.GetBoundsMode(); set => Controller.SetBoundsMode(value); }
        private ICoreWebView2Controller3 Controller
        {
            get
            {
                if (_Controller == null)
                {
                    Debug.Print(nameof(CoreWebView2Controller3Shim) + "=>" + nameof(Controller) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2Controller3Shim) + "=>" + nameof(Controller) + " is null");
                }
                return _Controller.Interface;
            }
            set => _Controller = new ComObjectHolder<ICoreWebView2Controller3>(value);
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
