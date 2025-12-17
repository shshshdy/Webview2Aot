using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Interop;

[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("a3ec0f5f-ddbc-54ed-8546-af75a785b9a6")]
[GeneratedComInterface]
public partial interface ICoreWebView2Find
{
    int GetActiveMatchIndex();

    int GetMatchCount();

    void add_ActiveMatchIndexChanged([MarshalAs(UnmanagedType.Interface)] ICoreWebView2FindActiveMatchIndexChangedEventHandler eventHandler, out EventRegistrationToken token);

    void remove_ActiveMatchIndexChanged(EventRegistrationToken token);

    void add_MatchCountChanged([MarshalAs(UnmanagedType.Interface)] ICoreWebView2FindMatchCountChangedEventHandler eventHandler, out EventRegistrationToken token);

    void remove_MatchCountChanged(EventRegistrationToken token);

    void Start([MarshalAs(UnmanagedType.Interface)] ICoreWebView2FindOptions options, [MarshalAs(UnmanagedType.Interface)] ICoreWebView2FindStartCompletedHandler handler);

    void FindNext();

    void FindPrevious();

    void Stop();

}
