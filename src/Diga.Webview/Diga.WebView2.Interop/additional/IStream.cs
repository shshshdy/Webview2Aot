// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.tagPOINT
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E8B0323-528E-4C9C-8FF8-A486637C87E1
// Assembly location: O:\webview2\V1096133\Diga.WebView2.Interop.dll

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DISPPARAMS
    {
        public IntPtr rgvarg;
        public IntPtr rgdispidNamedArgs;
        public int cArgs;
        public int cNamedArgs;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct EXCEPINFO
    {
        public short wCode;
        public short wReserved;
        [MarshalAs(UnmanagedType.BStr)] public string bstrSource;
        [MarshalAs(UnmanagedType.BStr)] public string bstrDescription;
        [MarshalAs(UnmanagedType.BStr)] public string bstrHelpFile;
        public int dwHelpContext;
        public IntPtr pvReserved;
        public IntPtr pfnDeferredFillIn;
        public int scode;
    }

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("00020400-0000-0000-C000-000000000046")]
    [GeneratedComInterface]
    public partial interface IDispatch
    {
        void GetTypeInfoCount(out int count);
        void GetTypeInfo(int iTInfo, int lcid, out IntPtr info);
        void GetIDsOfNames(ref Guid riid, IntPtr rgszNames, int cNames, int lcid, nint rgDispId);
        void Invoke(int dispIdMember, ref Guid riid, int lcid, ushort wFlags, [MarshalAs(UnmanagedType.Interface)] ref DISPPARAMS pDispParams, [MarshalAs(UnmanagedType.Interface)] out object pVarResult, [MarshalAs(UnmanagedType.Interface)] ref EXCEPINFO pExcepInfo, out int puArgErr);
    }

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0000000c-0000-0000-C000-000000000046")]
    [GeneratedComInterface]
    public partial interface IStream : ISequentialStream
    {

        //
        // Zusammenfassung:
        //     Changes the size of the stream object.
        //
        // Parameter:
        //   libNewSize:
        //     The new size of the stream as a number of bytes.
        [PreserveSig]
        int SetSize(ulong libNewSize);

        //
        // Zusammenfassung:
        //     Copies a specified number of bytes from the current seek pointer in the stream
        //     to the current seek pointer in another stream.
        //
        // Parameter:
        //   pstm:
        //     A reference to the destination stream.
        //
        //   cb:
        //     The number of bytes to copy from the source stream.
        //
        //   pcbRead:
        //     On successful return, contains the actual number of bytes read from the source.
        //
        //
        //   pcbWritten:
        //     On successful return, contains the actual number of bytes written to the destination.
        [PreserveSig]
        int CopyTo([MarshalAs(UnmanagedType.Interface)] ref IStream pstm, long cb, nint pcbRead, nint pcbWritten);

        //
        // Zusammenfassung:
        //     Ensures that any changes made to a stream object that is open in transacted mode
        //     are reflected in the parent storage.
        //
        // Parameter:
        //   grfCommitFlags:
        //     A value that controls how the changes for the stream object are committed.
        [PreserveSig]
        int Commit(uint grfCommitFlags);

        //
        // Zusammenfassung:
        //     Discards all changes that have been made to a transacted stream since the last
        //     System.Runtime.InteropServices.ComTypes.IStream.Commit(System.Int32) call.
        [PreserveSig]
        int Revert();

        //
        // Zusammenfassung:
        //     Restricts access to a specified range of bytes in the stream.
        //
        // Parameter:
        //   libOffset:
        //     The byte offset for the beginning of the range.
        //
        //   cb:
        //     The length of the range, in bytes, to restrict.
        //
        //   dwLockType:
        //     The requested restrictions on accessing the range.
        [PreserveSig]
        int LockRegion(long libOffset, long cb, uint dwLockType);

        //
        // Zusammenfassung:
        //     Removes the access restriction on a range of bytes previously restricted with
        //     the System.Runtime.InteropServices.ComTypes.IStream.LockRegion(System.Int64,System.Int64,System.Int32)
        //     method.
        //
        // Parameter:
        //   libOffset:
        //     The byte offset for the beginning of the range.
        //
        //   cb:
        //     The length, in bytes, of the range to restrict.
        //
        //   dwLockType:
        //     The access restrictions previously placed on the range.
        [PreserveSig]
        int UnlockRegion(long libOffset, long cb, uint dwLockType);

        //
        // Zusammenfassung:
        //     Creates a new stream object with its own seek pointer that references the same
        //     bytes as the original stream.
        //
        // Parameter:
        //   ppstm:
        //     When this method returns, contains the new stream object. This parameter is passed
        //     uninitialized.
        [PreserveSig]
        int Clone([MarshalAs(UnmanagedType.Interface)] out IStream ppstm);


        //
        // Zusammenfassung:
        //     Changes the seek pointer to a new location relative to the beginning of the stream,
        //     to the end of the stream, or to the current seek pointer.
        //
        // Parameter:
        //   dlibMove:
        //     The displacement to add to dwOrigin.
        //
        //   dwOrigin:
        //     The origin of the seek. The origin can be the beginning of the file, the current
        //     seek pointer, or the end of the file.
        //
        //   plibNewPosition:
        //     On successful return, contains the offset of the seek pointer from the beginning
        //     of the stream.
        [PreserveSig]
        int Seek(long dlibMove, nint dwOrigin, nint plibNewPosition);




        //
        // Zusammenfassung:
        //     Retrieves the System.Runtime.InteropServices.STATSTG structure for this stream.
        //
        //
        // Parameter:
        //   pstatstg:
        //     When this method returns, contains a STATSTG structure that describes this stream
        //     object. This parameter is passed uninitialized.
        //
        //   grfStatFlag:
        //     Members in the STATSTG structure that this method does not return, thus saving
        //     some memory allocation operations.
        [PreserveSig]
        int Stat(nint pstatstg, uint grfStatFlag);

      


    }
}
