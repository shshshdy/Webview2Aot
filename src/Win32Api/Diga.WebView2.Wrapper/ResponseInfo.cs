using System.Diagnostics;
using System.Text;

namespace Diga.WebView2.Wrapper
{


    public class ResponseInfo : IDisposable
    {
        private bool disposedValue;

        private ResponseInfo()
        {
            this.Header = new Dictionary<string, string>();
        }

        private ResponseInfo(Stream stream) : this()
        {
            this.Stream = stream;
            this.Header.Add("date", DateTime.Now.ToString("ddd, dd MMM yyy HH':'mm':'ss 'GMT'"));
            this.Header.Add("accept-ranges", "bytes");
            this.Header.Add("Access-Control-Allow-Origin", "*");
            this.Header.Add("content-length", Stream.Length.ToString());
            this.Header.Add("X-Content-Type-Options", "nosniff");

        }

        public ResponseInfo(byte[] bytes) : this(new MemoryStream(bytes)) { }

        public ResponseInfo(string content) : this(Encoding.UTF8.GetBytes(content)) { }
        public Stream Stream { get; private set; }
        public int StatusCode { get; set; }
        public string StatusText { get; set; }
        public string ContentType { get; set; }
        public Dictionary<string, string> Header { get; }

        public string HeaderToString()
        {
            try
            {
                if (!Header.ContainsKey("Cache-Control"))
                {
                    //Header.Add("Cache-Control", "max-age=31536000, immutable");
                    Header.Add("Cache-Control", "max-age=31536000");
                }
                else
                {
                    //Header["Cache-Control"] = "max-age=31536000, immutable";
                    Header["Cache-Control"] = "max-age=31536000";
                }

                //if(!Header.ContainsKey("Set-Cookie"))
                //{
                //    Header.Add("Set-Cookie", "sessionId=38afes7a8");
                //}
                //else
                //{
                //    Header["Set-Cookie"] = "sessionId=38afes7a8";
                //}

            }
            catch (Exception e)
            {
                Debug.Print(e.StackTrace);
            }
            StringBuilder headerStringBuilder = new StringBuilder($"HTTP/2 {StatusCode} {StatusText}\r\n");

            //string headerString = "";
            //headerString = $"HTTP/2 {StatusCode} {StatusText}\r\n";
            foreach (var headerValue in this.Header)
            {
                headerStringBuilder.Append(headerValue.Key);
                headerStringBuilder.Append(":");
                headerStringBuilder.Append(headerValue.Value);
                headerStringBuilder.Append("\r\n");
                //headerString += headerValue.Key + ":" + headerValue.Value;
                //headerString += "\r\n";
            }

            //if (!string.IsNullOrEmpty(headerString))
            //{
            //    headerString += "\r\n";
            //}

            headerStringBuilder.Append("\r\n");
            //string h = headerStringBuilder.ToString();
            return headerStringBuilder.ToString();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (this.Stream != null)
                    {
                        this.Stream.Dispose();
                        //this.Stream = null;
                    }
                }


                disposedValue = true;
            }
        }

        //~ResponseInfo()
        //{
        //    // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
        //    Dispose(disposing: false);
        //}

        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
    //public class StreamWrapper : IStream,IDisposable
    //{
    //    private IStream _Interface;
    //    private bool disposedValue;
    //    /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
    //    ///             pattern for any type that is not sealed.
    //    ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
    //    private SafeHandle handle = (SafeHandle) new SafeFileHandle(IntPtr.Zero, true);
    //    public StreamWrapper(IStream iface)
    //    {
    //        this._Interface = iface;
    //    }

    //    public void Read(byte[] pv, int cb, IntPtr pcbRead)
    //    {
    //        this._Interface.Read(pv, cb, pcbRead);
    //    }

    //    public void Write(byte[] pv, int cb, IntPtr pcbWritten)
    //    {
    //        this._Interface.Write(pv, cb, pcbWritten);
    //    }

    //    public void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition)
    //    {
    //        this._Interface.Seek(dlibMove, dwOrigin, plibNewPosition);
    //    }

    //    public void SetSize(long libNewSize)
    //    {
    //        this._Interface.SetSize(libNewSize);
    //    }

    //    public void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten)
    //    {
    //        this._Interface.CopyTo(pstm, cb, pcbRead, pcbWritten);
    //    }

    //    public void Commit(int grfCommitFlags)
    //    {
    //        this._Interface.Commit(grfCommitFlags);
    //    }

    //    public void Revert()
    //    {
    //        this._Interface.Revert();
    //    }

    //    public void LockRegion(long libOffset, long cb, int dwLockType)
    //    {
    //        this._Interface.LockRegion(libOffset, cb, dwLockType);
    //    }

    //    public void UnlockRegion(long libOffset, long cb, int dwLockType)
    //    {
    //        this._Interface.UnlockRegion(libOffset, cb, dwLockType);
    //    }

    //    public void Stat(out STATSTG pstatstg, int grfStatFlag)
    //    {
    //        this._Interface.Stat(out pstatstg, grfStatFlag);
    //    }

    //    public void Clone(out IStream ppstm)
    //    {
    //        this._Interface.Clone(out ppstm);
    //    }

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!disposedValue)
    //        {
    //            if (disposing)
    //            {
    //                // TODO: Verwalteten Zustand (verwaltete Objekte) bereinigen

    //            }

    //            this._Interface = null;
    //            // TODO: Nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer überschreiben
    //            // TODO: Große Felder auf NULL setzen
    //            disposedValue = true;
    //        }
    //    }

    //    // // TODO: Finalizer nur überschreiben, wenn "Dispose(bool disposing)" Code für die Freigabe nicht verwalteter Ressourcen enthält
    //    ~StreamWrapper()
    //    {
    //        // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
    //        Dispose(disposing: false);
    //    }

    //    public void Dispose()
    //    {
    //        // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
    //        Dispose(disposing: true);
    //        GC.SuppressFinalize(this);
    //    }
    //}
}
