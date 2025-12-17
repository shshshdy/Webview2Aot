using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Environment8Shim : CoreWebView2Environment7Shim //, ICoreWebView2Environment8
    {
        private ComObjectHolder<ICoreWebView2Environment8> _Environment;
        private ICoreWebView2Environment8 Environment
        {
            get
            {
                if (_Environment == null)
                {
                    Debug.Print(nameof(CoreWebView2Environment8Shim) + "." + nameof(Environment) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Environment8Shim) + "." + nameof(Environment) + " is null");

                }
                return _Environment.Interface;
            }
            set { _Environment = new ComObjectHolder<ICoreWebView2Environment8>(value); }
        }

        public CoreWebView2Environment8Shim(ICoreWebView2Environment8 environment) : base(environment)
        {
            Environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public void add_ProcessInfosChanged([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2ProcessInfosChangedEventHandler eventHandler, out EventRegistrationToken token)
        {
            Environment.add_ProcessInfosChanged(eventHandler, out token);
        }

        public void remove_ProcessInfosChanged([In] EventRegistrationToken token)
        {
            Environment.remove_ProcessInfosChanged(token);
        }

        [return: MarshalAs(UnmanagedType.Interface)]
        public ICoreWebView2ProcessInfoCollection GetProcessInfos()
        {
            return Environment.GetProcessInfos();
        }
    }
}
