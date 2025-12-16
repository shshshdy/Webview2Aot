using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
namespace Diga.WebView2.Interop
{
    [Guid("2C94DD56-E252-40A1-BA7E-B19417B26A60")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface ICoreWebView2Staging
    {
        void AddHostObjectHelper([MarshalAs(UnmanagedType.Interface)] ICoreWebView2StagingHostObjectHelper helper);
    }
}