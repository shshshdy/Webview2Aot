// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.tagPOINT
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E8B0323-528E-4C9C-8FF8-A486637C87E1
// Assembly location: O:\webview2\V1096133\Diga.WebView2.Interop.dll

using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0c733a30-2a1c-11ce-ade5-00aa0044773d")]
    [GeneratedComInterface]
    public partial interface ISequentialStream
    {
        [PreserveSig]
        int Read(nint pv, ulong cb, nint pcbRead);

        [PreserveSig]
        int Write(nint pv, ulong cb, nint pcbWritten);


    }
}
