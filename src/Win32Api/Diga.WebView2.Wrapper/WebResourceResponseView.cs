using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

using System.Runtime.InteropServices;


namespace Diga.WebView2.Wrapper
{
    public class WebResourceResponseView: CoreWebView2WebResourceResponseViewShim
    {
        public WebResourceResponseView(ICoreWebView2WebResourceResponseView args):base(args)
        {
            
        }

        public new HttpResponseHeaders Headers=> new HttpResponseHeaders(base.Headers);


        public Stream GetContent()
        {


            Task<Stream> resultTask = GetContentAsync();
            resultTask.Wait(20000);
            return resultTask.Result;

        }

        public async Task<Stream> GetContentAsync()
        {
            try
            {

                var source = new TaskCompletionSource<(int, IStream)>();
                var webViewResponse = new WebResourceResponseViewGetContentCompletedHandler(source);
                base.GetContent(webViewResponse);
                (int errorCode, IStream stream) result = await source.Task;
                HRESULT hr = result.errorCode;
                if (hr.Failed)
                    throw Marshal.GetExceptionForHR(hr);
                byte[] arr = null;
                using (ComStream sw = new ComStream(result.stream))
                {
                    arr = await sw.GetAllBytesAsync();
                }

                return new MemoryStream(arr);


            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }

            return null;
        }


    }
}
