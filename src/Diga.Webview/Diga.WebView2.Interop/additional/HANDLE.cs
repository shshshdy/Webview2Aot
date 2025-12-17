using System;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Interop
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct HANDLE
    {
        public nint handle;

        public static implicit operator nint(HANDLE h) => h.handle;
        public static implicit operator HANDLE(nint h) => new HANDLE { handle = h };
    }
}
