using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2ClientCertificateRequestedEventArgsShim //: ICoreWebView2ClientCertificateRequestedEventArgs
    {
        private ComObjectHolder<ICoreWebView2ClientCertificateRequestedEventArgs> _Args;
        private ICoreWebView2ClientCertificateRequestedEventArgs Args
        {
            get
            {
                if (_Args == null)
                {
                    Debug.Print(nameof(CoreWebView2ClientCertificateRequestedEventArgsShim) + "=>" + nameof(Args) + " is null");

                    throw new InvalidOperationException(nameof(CoreWebView2ClientCertificateRequestedEventArgsShim) + "=>" + nameof(Args) + " is null");
                }
                return _Args.Interface;
            }
            set { _Args = new ComObjectHolder<ICoreWebView2ClientCertificateRequestedEventArgs>(value); }
        }

        public CoreWebView2ClientCertificateRequestedEventArgsShim(ICoreWebView2ClientCertificateRequestedEventArgs args)
        {
            this.Args = args ?? throw new ArgumentNullException(nameof(args));
        }

        public string Host => this.Args.GetHost();

        public int Port => this.Args.GetPort();

        public int IsProxy => this.Args.GetIsProxy();

        public ICoreWebView2StringCollection AllowedCertificateAuthorities => this.Args.GetAllowedCertificateAuthorities();

        public ICoreWebView2ClientCertificateCollection MutuallyTrustedCertificates => this.Args.GetMutuallyTrustedCertificates();

        public ICoreWebView2ClientCertificate SelectedCertificate { get => this.Args.GetSelectedCertificate(); set => this.Args.SetSelectedCertificate (value); }
        public int Cancel { get => this.Args.GetCancel(); set => this.Args.SetCancel(value); }
        public int Handled { get => this.Args.GetHandled(); set => this.Args.SetHandled (value); }

        [return: MarshalAs(UnmanagedType.Interface)]
        public ICoreWebView2Deferral GetDeferral()
        {
            return this.Args.GetDeferral();
        }
    }
}
