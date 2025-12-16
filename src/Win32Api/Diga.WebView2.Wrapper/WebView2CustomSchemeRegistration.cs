using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{


    [GeneratedComClass]
    public partial class WebView2CustomSchemeRegistration : ICoreWebView2CustomSchemeRegistration
    {
        private string SchemeName { get; }
        private int TreatAsSecure { get; set; }
        public List<string> AllowedOrgins { get; }
        private int HasAuthorityComponent { get; set; }
        public WebView2CustomSchemeRegistration(string schemaName)
        {
            this.SchemeName = schemaName;
            this.TreatAsSecure = (CBOOL)false;
            this.HasAuthorityComponent = (CBOOL)false;
            this.AllowedOrgins = new List<string>();
            this.HasAuthorityComponent = (CBOOL)false;
        }
        public void GetAllowedOrigins(out uint allowedOriginsCount, nint allowedOrigins)
        {
             allowedOriginsCount = (uint)this.AllowedOrgins.Count;
            if (allowedOriginsCount == 0)
            {
                return;
            }

            IntPtr val = Marshal.AllocCoTaskMem((int)allowedOriginsCount * Marshal.SizeOf<IntPtr>());
            for (int i = 0; i < allowedOriginsCount; i++)
            {
                Marshal.WriteIntPtr(val + i * Marshal.SizeOf<IntPtr>(),Marshal.StringToCoTaskMemAuto(this.AllowedOrgins[i]));
            }
            Marshal.WriteIntPtr(allowedOrigins, val);
            
        }

        public int GetHasAuthorityComponent()
        {
            return this.HasAuthorityComponent;
        }

        [return: MarshalAs(UnmanagedType.LPWStr)]
        public string GetSchemeName()
        {
            return this.SchemeName;
        }

        public int GetTreatAsSecure()
        {
            return this.TreatAsSecure;
        }

        public void SetAllowedOrigins(uint allowedOriginsCount, [MarshalAs(UnmanagedType.LPWStr)]ref  string allowedOrigins)
        {
            throw new NotImplementedException();
        }

        public void SetHasAuthorityComponent(int value)
        {
            this.HasAuthorityComponent = value;
        }

        public void SetTreatAsSecure(int value)
        {
            this.TreatAsSecure = value;
        }


    }
}
