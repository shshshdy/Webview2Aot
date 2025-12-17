using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Environment9Shim : CoreWebView2Environment8Shim
    {
        private ComObjectHolder<ICoreWebView2Environment9> _Environment;
        private ICoreWebView2Environment9 Environment
        {
            get
            {
                if (_Environment == null)
                {
                    Debug.Print(nameof(CoreWebView2Environment9Shim) + "." + nameof(Environment) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Environment9Shim) + "." + nameof(Environment) + " is null");

                }
                return _Environment.Interface;
            }
            set { _Environment = new ComObjectHolder<ICoreWebView2Environment9>(value); }
        }

        public CoreWebView2Environment9Shim(ICoreWebView2Environment9 environment) : base(environment)
        {
            Environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }



        [return: MarshalAs(UnmanagedType.Interface)]
        public ICoreWebView2ContextMenuItem CreateContextMenuItem([In, MarshalAs(UnmanagedType.LPWStr)] string Label, [MarshalAs(UnmanagedType.Interface), In] IStream iconStream, [In] COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND Kind)
        {
            return Environment.CreateContextMenuItem(Label, iconStream, Kind);
        }
    }
}
