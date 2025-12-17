using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2ControllerOptions2Shim : CoreWebView2ControllerOptionsShim //, ICoreWebView2ControllerOptions2
    {
        private ComObjectHolder<ICoreWebView2ControllerOptions2> _Options;
        private bool _IsDesposed;
        private ICoreWebView2ControllerOptions2 Options
        {
            get
            {
                if (_Options == null)
                {
                    Debug.Print(nameof(CoreWebView2ControllerOptionsShim) + "WebView2ControllerOptions2Interface is null");

                    throw new InvalidOperationException("WebView2ControllerOptions2Interface is null!");
                }

                return _Options.Interface;
            }
            set => _Options = new ComObjectHolder<ICoreWebView2ControllerOptions2>(value);
        }
        public CoreWebView2ControllerOptions2Shim(ICoreWebView2ControllerOptions2 options) : base(options)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public string ScriptLocale { get => Options.GetScriptLocale(); set => Options.SetScriptLocale(value); }
        protected override void Dispose(bool disposing)
        {
            if (!_IsDesposed)
            {
                if (disposing)
                {
                    _Options = null;
                }
                _IsDesposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
