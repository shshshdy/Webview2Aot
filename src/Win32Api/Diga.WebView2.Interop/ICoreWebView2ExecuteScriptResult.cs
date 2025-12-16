// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2ExecuteScriptCompletedHandler
// Assembly: Diga.WebView2.Interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E8B0323-528E-4C9C-8FF8-A486637C87E1
// Assembly location: O:\webview2\V1096133\Diga.WebView2.Interop.dll

using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
    [Guid("0CE15963-3698-4DF7-9399-71ED6CDD8C9F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface ICoreWebView2ExecuteScriptResult
    {
        
        int GetSucceeded();

        [return: MarshalAs(UnmanagedType.LPWStr)]
        string GetResultAsJson(); 

        
        void TryGetResultAsString([MarshalAs(UnmanagedType.LPWStr)] out string stringResult, out int value);

        [return: MarshalAs(UnmanagedType.Interface)]
        ICoreWebView2ScriptException GetException();
    }

}
