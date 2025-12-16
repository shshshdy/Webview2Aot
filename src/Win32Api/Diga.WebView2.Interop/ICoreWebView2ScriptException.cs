// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2ExecuteScriptCompletedHandler
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E8B0323-528E-4C9C-8FF8-A486637C87E1
// Assembly location: O:\webview2\V1096133\Diga.WebView2.Interop.dll

using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("054DAE00-84A3-49FF-BC17-4012A90BC9FD")]
    [GeneratedComInterface]
    public partial interface ICoreWebView2ScriptException
    {
        uint GetLineNumber();

        uint GetColumnNumber();

        [return: MarshalAs(UnmanagedType.LPWStr)]
        string Getname();

        [return: MarshalAs(UnmanagedType.LPWStr)]
        string GetMessage();

        [return: MarshalAs(UnmanagedType.LPWStr)]
        string GetToJson(); 
    }

}
