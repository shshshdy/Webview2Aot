using System;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Interop
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct HCURSOR
    {
        public nint handle;

        public static implicit operator nint(HCURSOR h) => h.handle;
        public static implicit operator HCURSOR(nint h) => new HCURSOR { handle = h };
    }
}
