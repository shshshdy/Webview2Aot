using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.EventArguments;
using Diga.WebView2.Wrapper.Types;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{


    [GeneratedComClass]
    public partial class EnvironmentCompletedHandler : ICoreWebView2CreateCoreWebView2EnvironmentCompletedHandler
    {

        //public event EventHandler<CompositionControllerCompletedEventArgs> CompositionControllerCompleted;
       
        public void Invoke(int errorCode, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2Environment createdEnvironment)
        {
            IntPtr hWnd = this.ParentHandle;
            var handler = new ControllerCompletedHandler();
            handler.ControllerCompleted += OnControllerCompletedIntern;
            handler.ControllerCompletedError += OnControllerCompletedErrorIntern;
            handler.BeforeControllerCreate += OnBeforeControllerCreateIntern;
            OnBeforeEnvironmentCompleted(new EnvironmentCompletedHandlerArgs((ICoreWebView2Environment12)createdEnvironment));
            createdEnvironment.CreateCoreWebView2Controller(hWnd, handler);
            var handler2 = new CompositionControllerCompletedHandler();
            handler2.Completed += OnCompositionControllerCompletedIntern;
            //((ICoreWebView2Environment4)createdEnvironment).CreateCoreWebView2CompositionController(hWnd, handler2);
            OnAfterEnvironmentCompleted(new EnvironmentCompletedHandlerArgs((ICoreWebView2Environment12)createdEnvironment));
            errorCode = HRESULT.S_OK;
        }

        private void OnCompositionControllerCompletedIntern(object sender, CompositionControllerCompletedEventArgs e)
        {
            OnCompositionControllerCompleted(e);
        }
        public EnvironmentCompletedHandler(IntPtr parentHandle)
        {
            this.ParentHandle = parentHandle;
        }
        private void OnBeforeControllerCreateIntern(object sender, BeforeControllerCreateEventArgs e)
        {
            OnPrepareControllerCreate(e);
        }

        private void OnControllerCompletedErrorIntern(object sender, ControllerCompletedErrorArgs e)
        {
            HRESULT res = new HRESULT(e.Result);
            Exception ex = HRESULT.GetExceptionForHR(e.Result);
            System.Runtime.InteropServices.COMException cex =
                new System.Runtime.InteropServices.COMException("ex", e.Result);
            System.Diagnostics.Debug.Print(res.ToString());
        }

        private void OnControllerCompletedIntern(object sender, ControllerCompletedArgs e)
        {
            this.Controller = e.Controller;
            this.WebView = e.WebView;
            OnControllerCompleted(e);
        }

        protected virtual void OnBeforeEnvironmentCompleted(EnvironmentCompletedHandlerArgs e)
        {
            BeforeEnvironmentCompleted?.Invoke(this, e);
        }

        protected virtual void OnAfterEnvironmentCompleted(EnvironmentCompletedHandlerArgs e)
        {
            AfterEnvironmentCompleted?.Invoke(this, e);
        }

        protected virtual void OnControllerCompleted(ControllerCompletedArgs e)
        {
            ControllerCompleted?.Invoke(this, e);
        }

        protected virtual void OnPrepareControllerCreate(BeforeControllerCreateEventArgs e)
        {
            PrepareControllerCreate?.Invoke(this, e);
        }

        protected virtual void OnCompositionControllerCompleted(CompositionControllerCompletedEventArgs e)
        {
            CompositionControllerCompleted?.Invoke(this, e);
        }

        public ICoreWebView2 WebView { get; private set; }
        public ICoreWebView2Controller Controller { get; set; }
        public IntPtr ParentHandle { get; set; }

        public event EventHandler<EnvironmentCompletedHandlerArgs> BeforeEnvironmentCompleted;
        public event EventHandler<EnvironmentCompletedHandlerArgs> AfterEnvironmentCompleted;

        public event EventHandler<ControllerCompletedArgs> ControllerCompleted;
        public event EventHandler<BeforeControllerCreateEventArgs> PrepareControllerCreate;
        public event EventHandler<CompositionControllerCompletedEventArgs> CompositionControllerCompleted;
    }
}
