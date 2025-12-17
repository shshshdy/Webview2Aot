using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
namespace Diga.WebView2.Interop
{
    [Guid("DF362C62-3B8E-484A-8DE0-FE2CB31EDBC5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface ICoreWebView2StagingHostObjectHelper
    {
        int IsMethodMember([MarshalAs(UnmanagedType.Interface)] ref object rawObject, [MarshalAs(UnmanagedType.LPWStr)] string memberName);
    }
}