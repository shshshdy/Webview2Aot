// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.tagPOINT
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E8B0323-528E-4C9C-8FF8-A486637C87E1
// Assembly location: O:\webview2\V1096133\Diga.WebView2.Interop.dll

using System.Runtime.InteropServices;

namespace Diga.WebView2.Interop
{
    [StructLayout(LayoutKind.Sequential,Pack =4)]
    public struct STATSTG
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pwcsName;
        public uint type;
        public ulong cbSize;
        public FILETIME mtime;
        public FILETIME ctime;
        public FILETIME atime;
        public uint grfMode;
        public uint grfLocksSupported; [ComAliasName("Diga.WebView2.Interop.GUID")]
        public GUID clsid;
        public uint grfStateBits;
        public uint reserved;
    }
}
