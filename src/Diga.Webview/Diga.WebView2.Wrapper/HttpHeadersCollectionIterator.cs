using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.shim;
using Diga.WebView2.Wrapper.Types;
using System.Collections;
namespace Diga.WebView2.Wrapper
{

    public class HttpHeadersCollectionIterator : CoreWebView2HttpHeadersCollectionIteratorShim, IEnumerator, IEnumerable, IDisposable
    {

        public HttpHeadersCollectionIterator(ICoreWebView2HttpHeadersCollectionIterator iface) : base(iface)
        {

        }


        private IEnumerator ToEnumerator()
        {
            return this;
        }


        public new bool MoveNext()
        {
            return ToEnumerator().MoveNext();
        }

        public HeaderItem Current => (HeaderItem)ToEnumerator().Current;

        public bool HasCurrent => new CBOOL(HasCurrentHeader);


        bool IEnumerator.MoveNext()
        {
            int hasNext = base.MoveNext();
            return new CBOOL(hasNext);
        }

        void IEnumerator.Reset()
        {
            throw new NotImplementedException();
        }

        object IEnumerator.Current
        {
            get
            {
                GetCurrentHeader(out string name, out string value);
                return new HeaderItem(name, value);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }





    }
}
