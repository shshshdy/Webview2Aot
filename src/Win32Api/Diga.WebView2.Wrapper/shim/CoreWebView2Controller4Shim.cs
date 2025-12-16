using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{

    public class CoreWebView2Controller4Shim : CoreWebView2Controller3Shim
    {
        private ComObjectHolder<ICoreWebView2Controller4> _Controller;
        private ICoreWebView2Controller4 Controller
        {
            get
            {
                if (_Controller == null)
                {
                    Debug.Print(nameof(CoreWebView2Controller4Shim) + "=>" + nameof(Controller) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2Controller4Shim) + "=>" + nameof(Controller) + " is null");
                }
                return _Controller.Interface;
            }
            set => _Controller = new ComObjectHolder<ICoreWebView2Controller4>(value);
        }
        public CoreWebView2Controller4Shim(ICoreWebView2Controller4 controller) : base(controller)
        {
            Controller = controller ?? throw new ArgumentNullException(nameof(controller));
        }

        public int AllowExternalDrop { get => Controller.GetAllowExternalDrop(); set => Controller.SetAllowExternalDrop(value); }
    }
}
