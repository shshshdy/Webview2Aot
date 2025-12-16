using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2Profile2Shim : CoreWebView2ProfileShim
    {
        private ComObjectHolder<ICoreWebView2Profile2> _Profile;
        private ICoreWebView2Profile2 Profile
        {
            get
            {
                if (_Profile == null)
                {
                    Debug.Print(nameof(CoreWebView2Settings3Shim) + "." + nameof(Profile) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2Settings3Shim) + "." + nameof(Profile) + " is null");

                }
                return _Profile.Interface;
            }
            set
            {
                _Profile = new ComObjectHolder<ICoreWebView2Profile2>(value);
            }
        }

        public ICoreWebView2Profile2 GetInterface()
        {
            return Profile;
        }
        public CoreWebView2Profile2Shim(ICoreWebView2Profile2 profile) : base(profile)
        {
            Profile = profile ?? throw new ArgumentNullException(nameof(profile));
        }

        public void ClearBrowsingData([In] COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, [In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2ClearBrowsingDataCompletedHandler handler)
        {
            Profile.ClearBrowsingData(dataKinds, handler);
        }

        public void ClearBrowsingDataInTimeRange([In] COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, [In] double startTime, [In] double endTime, [In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2ClearBrowsingDataCompletedHandler handler)
        {
            Profile.ClearBrowsingDataInTimeRange(dataKinds, startTime, endTime, handler);
        }

        public void ClearBrowsingDataAll([In, MarshalAs(UnmanagedType.Interface)] ICoreWebView2ClearBrowsingDataCompletedHandler handler)
        {
            Profile.ClearBrowsingDataAll(handler);
        }
    }
}
