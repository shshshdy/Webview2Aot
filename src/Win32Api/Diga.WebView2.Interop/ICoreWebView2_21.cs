// Decompiled with JetBrains decompiler
// Type: Diga.WebView2.Interop.ICoreWebView2_19
// Assembly: Diga.WebView2.interop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86C06DAC-1E1B-4B02-A98B-B9D6F676B39A
// Assembly location: O:\webview2\microsoft.web.webview2.1.0.1901.177\Diga.WebView2.interop.dll

using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop
{
    [Guid("C4980DEA-587B-43B9-8143-3EF3BF552D95")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface ICoreWebView2_21 : ICoreWebView2_20
    {
        void ExecuteScriptWithResult([MarshalAs(UnmanagedType.LPWStr)] string javaScript, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2ExecuteScriptWithResultCompletedHandler handler);
    }
}
