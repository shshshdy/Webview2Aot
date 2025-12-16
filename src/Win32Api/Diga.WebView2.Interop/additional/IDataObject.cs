using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0000010E-0000-0000-C000-000000000046")]
    [GeneratedComInterface]
    public partial interface IDataObject
    {
        [PreserveSig]
        int GetData(nint pFormatEtc, nint pMedium);

        [PreserveSig]
        int GetDataHere(nint pFormatEtc, nint pMedium);

        [PreserveSig]
        int QueryGetData(nint pFormatEtc);

        [PreserveSig]
        int GetCanonicalFormatEtc(nint pFormatEtcIn, out nint pFormatEtcOut);

        [PreserveSig]
        int SetData(nint pFormatEtc, nint pMedium, int fRelease);

        [PreserveSig]
        int EnumFormatEtc(uint dwDirection, out nint ppenumFormatEtc);

        [PreserveSig]
        int DAdvise(nint pFormatEtc, uint advf, nint pAdvSink, out uint pdwConnection);

        [PreserveSig]
        int DUnadvise(uint dwConnection);

        [PreserveSig]
        int EnumDAdvise(out nint ppenumAdvise);
    }
}
