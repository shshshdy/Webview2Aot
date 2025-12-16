using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
using System.Security;
using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;


namespace Diga.WebView2.Wrapper
{
   

    internal static class StreamSeek
    {
        public const int STREAM_SEEK_SET = 0x0;

        public const int STREAM_SEEK_CUR = 0x1;

        public const int STREAM_SEEK_END = 0x2;
    }
    internal static class Stgm
    {
        public const int STGM_READ = 0x00000000;

        public const int STGM_WRITE = 0x00000001;

        public const int STGM_READWRITE = 0x00000002;

        public const int STGM_SHARE_EXCLUSIVE = 0x00000010;

        public const int STGM_CREATE = 0x00001000;

        public const int STGM_TRANSACTED = 0x00010000;

        public const int STGM_CONVERT = 0x00020000;

        public const int STGM_DELETEONRELEASE = 0x04000000;
    }
    internal static class Stgty
    {
        public const int STGTY_STORAGE = 1;

        public const int STGTY_STREAM = 2;

        public const int STGTY_LOCKBYTES = 3;

        public const int STGTY_PROPERTY = 4;
    }

    // The class ManagedIStream is not COM-visible. Its purpose is to be able to invoke COM interfaces
    // from managed code rather than the contrary.
    [GeneratedComClass]
    internal partial class ManagedIStream : IStream
    {

        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private SafeHandle handle = (SafeHandle)new SafeFileHandle(IntPtr.Zero, true);
        /// <summary>
        /// Constructor
        /// </summary>
        internal ManagedIStream(ref Stream ioStream)
        {
            this._ioStream = ioStream ?? throw new ArgumentNullException("ioStream");
        }

        /// <summary>
        /// Read at most bufferSize bytes into buffer and return the effective
        /// number of bytes read in bytesReadPtr (unless null).
        /// </summary>
        /// <remarks>
        /// mscorlib disassembly shows the following MarshalAs parameters
        /// void Read([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)] byte[] pv, int cb, IntPtr pcbRead);
        /// This means marshaling code will have found the size of the array buffer in the parameter bufferSize.
        /// </remarks>
        ///<SecurityNote>
        ///     Critical: calls Marshal.WriteInt32 which LinkDemands, takes pointers as input
        ///</SecurityNote>
        [SecurityCritical]
        int ISequentialStream.Read(nint buffer, ulong bufferSize, nint bytesReadPtr)
        {
            byte[] bufferIntern = new byte[bufferSize];
            Int32 bytesRead = this._ioStream.Read(bufferIntern, 0,(int) bufferSize);
            if (bytesReadPtr != IntPtr.Zero)
            {
                Marshal.Copy(bufferIntern,0,buffer, bytesRead);
                Marshal.WriteInt32(bytesReadPtr, bytesRead);
                return HRESULT.S_OK;
            }
            return HRESULT.COMADMIN_E_APP_FILE_READFAIL;
        }

        /// <summary>
        /// Move the stream pointer to the specified position.
        /// </summary>
        /// <remarks>
        /// System.IO.stream supports searching past the end of the stream, like
        /// OLE streams.
        /// newPositionPtr is not an out parameter because the method is required
        /// to accept NULL pointers.
        /// </remarks>
        ///<SecurityNote>
        ///     Critical: calls Marshal.WriteInt64 which LinkDemands, takes pointers as input
        ///</SecurityNote>
        [SecurityCritical]
        int IStream.Seek(long offset, nint origin, nint newPositionPtr)
        {
            SeekOrigin seekOrigin;

            // The operation will generally be I/O bound, so there is no point in
            // eliminating the following switch by playing on the fact that
            // System.IO uses the same integer values as IStream for SeekOrigin.
            switch (origin)
            {
                case StreamSeek.STREAM_SEEK_SET:
                    seekOrigin = SeekOrigin.Begin;
                    break;
                case StreamSeek.STREAM_SEEK_CUR:
                    seekOrigin = SeekOrigin.Current;
                    break;
                case StreamSeek.STREAM_SEEK_END:
                    seekOrigin = SeekOrigin.End;
                    break;
                default:
                    return HRESULT.STG_E_INVALIDFUNCTION;
            }
            long position = this._ioStream.Seek(offset, seekOrigin);

            // Dereference newPositionPtr and assign to the pointed location.
            if ((newPositionPtr == IntPtr.Zero))
            {
                return HRESULT.SCARD_E_BAD_SEEK;
            }
            Marshal.WriteInt64(newPositionPtr, position);
            return HRESULT.S_OK;
        }

        /// <summary>
        /// Sets stream's size.
        /// </summary>
        int IStream.SetSize(ulong libNewSize)
        {
            //this._ioStream.SetLength((long)libNewSize);
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Obtain stream stats.
        /// </summary>
        /// <remarks>
        /// STATSG has to be qualified because it is defined both in System.Runtime.InteropServices and
        /// System.Runtime.InteropServices.ComTypes.
        /// The STATSTG structure is shared by streams, storages and byte arrays. Members irrelevant to streams
        /// or not available from System.IO.Stream are not returned, which leaves only cbSize and grfMode as 
        /// meaningful and available pieces of information.
        /// grfStatFlag is used to indicate whether the stream name should be returned and is ignored because
        /// this information is unavailable.
        /// </remarks>
        int IStream.Stat(nint pstatstg, uint grfStatFlag)
        {

            STATSTG streamStats = new STATSTG();
            streamStats.type = Stgty.STGTY_STREAM;
            streamStats.cbSize = (ulong)this._ioStream.Length;

            // Return access information in grfMode.
            streamStats.grfMode = 0; // default value for each flag will be false
            if (this._ioStream.CanRead && this._ioStream.CanWrite)
            {
                streamStats.grfMode |= Stgm.STGM_READWRITE;
            }
            else if (this._ioStream.CanRead)
            {
                streamStats.grfMode |= Stgm.STGM_READ;
            }
            else if (this._ioStream.CanWrite)
            {
                streamStats.grfMode |= Stgm.STGM_WRITE;
            }
            else
            {
                // A stream that is neither readable nor writable is a closed stream.
                // Note the use of an exception that is known to the interop marshaller
                // (unlike ObjectDisposedException).
                //throw new IOException("A stream that is neither readable nor writable is a closed stream.");
                return HRESULT.COMADMIN_E_APP_FILE_READFAIL;
            }

            Marshal.StructureToPtr(streamStats, pstatstg, false);
            return HRESULT.S_OK;
        }

        /// <summary>
        /// Write at most bufferSize bytes from buffer.
        /// </summary>
        ///<SecurityNote>
        ///     Critical: calls Marshal.WriteInt32 which LinkDemands, takes pointers as input
        ///</SecurityNote>
        [SecurityCritical]
        int ISequentialStream.Write(nint buffer, ulong bufferSize, nint bytesWrittenPtr)
        {
            byte[] bytes = new byte[bytesWrittenPtr];
            Marshal.Copy(buffer,bytes,0, (int)bufferSize);

            this._ioStream.Write(bytes, 0, (int)bufferSize);
            if (bytesWrittenPtr != IntPtr.Zero)
            {
                // If fewer than bufferSize bytes had been written, an exception would
                // have been thrown, so it can be assumed we wrote bufferSize bytes.
                Marshal.WriteInt32(bytesWrittenPtr, (int)bufferSize);
                return HRESULT.S_OK;
            }
            return HRESULT.COMADMIN_E_APP_FILE_WRITEFAIL;
        }

        #region Unimplemented methods
        /// <summary>
        /// Create a clone.
        /// </summary>
        /// <remarks>
        /// Not implemented.
        /// </remarks>
        int IStream.Clone(out IStream streamCopy)
        {
            streamCopy = null;
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Read at most bufferSize bytes from the receiver and write them to targetStream.
        /// </summary>
        /// <remarks>
        /// Not implemented.
        /// </remarks>
        int IStream.CopyTo(ref IStream pstm, long cb, nint pcbRead, nint pcbWritten)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Commit changes.
        /// </summary>
        /// <remarks>
        /// Only relevant to transacted streams.
        /// </remarks>
        int IStream.Commit(uint flags)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Lock at most byteCount bytes starting at offset.
        /// </summary>
        /// <remarks>
        /// Not supported by System.IO.Stream.
        /// </remarks>
        int IStream.LockRegion(long offset, long byteCount, uint lockType)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Undo writes performed since last Commit.
        /// </summary>
        /// <remarks>
        /// Relevant only to transacted streams.
        /// </remarks>
        int IStream.Revert()
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Unlock the specified region.
        /// </summary>
        /// <remarks>
        /// Not supported by System.IO.Stream.
        /// </remarks>
        int IStream.UnlockRegion(long offset, long byteCount, uint lockType)
        {
            return HRESULT.E_NOTIMPL;
        }

        //int IStream.SetSize(ulong libNewSize)
        //{
        //    throw new NotImplementedException();
        //}

        //int IStream.CopyTo(ref IStream pstm, long cb, nint pcbRead, nint pcbWritten)
        //{
        //    throw new NotImplementedException();
        //}

        //int IStream.Commit(uint grfCommitFlags)
        //{
        //    throw new NotImplementedException();
        //}

        //int IStream.Revert()
        //{
        //    throw new NotImplementedException();
        //}

        //int IStream.LockRegion(long libOffset, long cb, uint dwLockType)
        //{
        //    throw new NotImplementedException();
        //}

        //int IStream.UnlockRegion(long libOffset, long cb, uint dwLockType)
        //{
        //    throw new NotImplementedException();
        //}

        //int IStream.Clone(out IStream ppstm)
        //{
        //    throw new NotImplementedException();
        //}

        //int IStream.Seek(long dlibMove, nint dwOrigin, nint plibNewPosition)
        //{
        //    throw new NotImplementedException();
        //}

        //int IStream.Stat(nint pstatstg, uint grfStatFlag)
        //{
        //    throw new NotImplementedException();
        //}

        //int ISequentialStream.Read(nint pv, ulong cb, nint pcbRead)
        //{
        //    throw new NotImplementedException();
        //}

        //int ISequentialStream.Write(nint pv, ulong cb, nint pcbWritten)
        //{
        //    throw new NotImplementedException();
        //}




        #endregion Unimplemented methods

        #region Fields
        private Stream _ioStream;

        #endregion Fields
    }


    public class ComStream : Stream
    {
        private IStream _IStream;
        private IntPtr _Int64;

        public ComStream(IStream source)
        {
            this._IStream = source;
            this._Int64 = Marshal.AllocCoTaskMem(8);
        }
        public override void Flush()
        {
            this._IStream.Commit(0);
        }
       
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (offset != 0)
                throw new NotImplementedException();
            var hg = Marshal.AllocHGlobal(sizeof(byte)*buffer.Length);

            this._IStream.Read(hg, (ulong)count, this._Int64);
            Marshal.Copy(hg, buffer, offset, count);
            Marshal.FreeHGlobal(hg);
            return Marshal.ReadInt32(this._Int64);
        }

        public async Task<byte[]> GetAllBytesAsync()
        {
            long len = this.Length;

            byte[] bytes = new byte[len];
            int read = await this.ReadAsync(bytes, 0, (int)len);
            return bytes;
        }
        public byte[] GetAllBytes()
        {
            long len = this.Length;
            byte[] bytes = new byte[len];
#pragma warning disable CA2022 // Ungenaues Lesen mit „Stream.Read“ vermeiden
            this.Read(bytes, 0, (int)len);
#pragma warning restore CA2022 // Ungenaues Lesen mit „Stream.Read“ vermeiden
            return bytes;
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            this._IStream.Seek(offset, (int)origin, this._Int64);
            return Marshal.ReadInt64(this._Int64);
        }

        public override void SetLength(long value)
        {
            this._IStream.SetSize((ulong)value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (offset != 0)
                throw new NotImplementedException();
            var hg = Marshal.AllocHGlobal(sizeof(byte)*buffer.Length);
            Marshal.Copy(buffer, offset, hg, count);
            this._IStream.Write(hg, (ulong)count, IntPtr.Zero);
            Marshal.FreeHGlobal(hg);
        }

        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => true;

        public override long Length
        {
            get
            {
                STATSTG pstatstg = new STATSTG();
                
                var s = Marshal.AllocHGlobal(Marshal.SizeOf<STATSTG>());
                Marshal.StructureToPtr(pstatstg, s, false);
                this._IStream.Stat(s, 1);
                return (long)pstatstg.cbSize;
            }
        }

        public override long Position
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                Marshal.FreeCoTaskMem(this._Int64);
            }
        }

        ~ComStream()
        {
            Marshal.FreeCoTaskMem(this._Int64);
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
