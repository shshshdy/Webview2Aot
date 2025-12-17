using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2BasicAuthenticationRequestedEventArgsShim : IDisposable
    {
        private ComObjectHolder<ICoreWebView2BasicAuthenticationRequestedEventArgs> _Args;
        private bool disposedValue;

        private ICoreWebView2BasicAuthenticationRequestedEventArgs Args
        {
            get
            {
                if (_Args == null)
                {
                    Debug.Print(nameof(CoreWebView2BasicAuthenticationRequestedEventArgsShim) + "=>" + nameof(Args) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2BasicAuthenticationRequestedEventArgsShim) + "=>" + nameof(Args) + " is null");
                }
                return _Args.Interface;
            }
            set { _Args = new ComObjectHolder<ICoreWebView2BasicAuthenticationRequestedEventArgs>(value); }
        }

        public CoreWebView2BasicAuthenticationRequestedEventArgsShim(ICoreWebView2BasicAuthenticationRequestedEventArgs args)
        {
            Args = args ?? throw new ArgumentNullException(nameof(args));
        }
        public string uri => Args.Geturi();

        public string Challenge => Args.GetChallenge();

        public ICoreWebView2BasicAuthenticationResponse Response => Args.GetResponse();

        public int Cancel { get => Args.GetCancel(); set => Args.SetCancel(value); }

        [return: MarshalAs(UnmanagedType.Interface)]
        public ICoreWebView2Deferral GetDeferral()
        {
            return Args.GetDeferral();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _Args = null;
                }


                disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
