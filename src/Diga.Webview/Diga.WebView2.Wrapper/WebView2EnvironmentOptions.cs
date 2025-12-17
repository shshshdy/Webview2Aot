using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Diga.WebView2.Wrapper
{

    [GeneratedComClass]
    public unsafe partial class WebView2EnvironmentOptions : 
        ICoreWebView2EnvironmentOptions , 
        ICoreWebView2EnvironmentOptions2 , 
        ICoreWebView2EnvironmentOptions3, 
        ICoreWebView2EnvironmentOptions4 , 
        ICoreWebView2EnvironmentOptions5
    {
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public string GetAdditionalBrowserArguments()
        {
            Debug.Print("GetAdditionalBrowserArguments");
            return this.AdditionalBrowserArguments;

        }

        public void SetAdditionalBrowserArguments([param: MarshalAs(UnmanagedType.LPWStr)] string value)
        {
            Debug.Print("SetAdditionalBrowserArguments");
            this.AdditionalBrowserArguments = value;
        }


        [return: MarshalAs(UnmanagedType.LPWStr)]
        public string GetLanguage()
        {
            Debug.Print("GetLanguage");
            return this.Language;
        }

        public void SetLanguage([param: MarshalAs(UnmanagedType.LPWStr)] string value)
        {
            Debug.Print("SetLanguage");
            this.Language = value;
        }


        [return: MarshalAs(UnmanagedType.LPWStr)]
        public string GetTargetCompatibleBrowserVersion()
        {
            Debug.Print("GetTargetCompatibleBrowserVersion");
            return this.TargetCompatibleBrowserVersion;
        }

        public void SetTargetCompatibleBrowserVersion([param: MarshalAs(UnmanagedType.LPWStr)] string value)
        {
            Debug.Print("SetTargetCompatibleBrowserVersion");
            this.TargetCompatibleBrowserVersion = value;
        }


        public int GetAllowSingleSignOnUsingOSPrimaryAccount()
        {
            Debug.Print("GetAllowSingleSignOnUsingOSPrimaryAccount");
            return this.AllowSingleSignOnUsingOSPrimaryAccount;
        }

        public void SetAllowSingleSignOnUsingOSPrimaryAccount(int value)
        {
            Debug.Print("SetAllowSingleSignOnUsingOSPrimaryAccount");
            this.AllowSingleSignOnUsingOSPrimaryAccount = value;
        }
        public int GetExclusiveUserDataFolderAccess()
        {
            Debug.Print("GetExclusiveUserDataFolderAccess");
            return this.ExclusiveUserDataFolderAccess;
        }

        public void SetExclusiveUserDataFolderAccess(int value)
        {
            Debug.Print("SetExclusiveUserDataFolderAccess");
            this.ExclusiveUserDataFolderAccess = value;
        }
        public int GetIsCustomCrashReportingEnabled()
        {
            Debug.Print("GetIsCustomCrashReportingEnabled");
            return this.IsCustomCrashReportingEnabled;
        }

        public void SetIsCustomCrashReportingEnabled(int value)
        {
            Debug.Print("SetIsCustomCrashReportingEnabled");
            this.IsCustomCrashReportingEnabled = value;
        }
        [PreserveSig]
        public int GetCustomSchemeRegistrations(out uint Count, nint schemeRegistrations)
        {
            Debug.Print("GetCustomSchemeRegistrations");
            if(this.CustomSchemeRegistrations.Count == 0)
            {
                Count = 0U;
            }
            else
            {
                Count = (uint)this.CustomSchemeRegistrations.Count;
                int size = Marshal.SizeOf<IntPtr>();
                IntPtr val = Marshal.AllocCoTaskMem((int)Count * size);
                for (int index = 0; index < Count; index++)
                {
                    WebView2CustomSchemeRegistration obj = this.CustomSchemeRegistrations[index];
#pragma warning disable CA1416
                    
                   
                    var iface = ComInterfaceMarshaller<ICoreWebView2CustomSchemeRegistration>.ConvertToUnmanaged(obj);
#pragma warning restore CA1416
                    Marshal.WriteIntPtr(val + index * size, (nint)iface);

                }
                Marshal.WriteIntPtr(schemeRegistrations, val);

            }
            
            return HRESULT.S_OK;
        }

        [PreserveSig]
        public int SetCustomSchemeRegistrations(uint Count, ref ICoreWebView2CustomSchemeRegistration schemeRegistrations)
        {
            Debug.Print("SetCustomSchemeRegistrations");
            return HRESULT.S_FALSE;

        }

        public int GetEnableTrackingPrevention()
        {
            Debug.Print("GetEnableTrackingPrevention");
            return this.EnableTrackingPrevention;
        }

        public void SetEnableTrackingPrevention(int value)
        {
            Debug.Print("SetEnableTrackingPrevention");
            this.EnableTrackingPrevention = value;
        }

        public WebView2EnvironmentOptions()
        {
            //this.AdditionalBrowserArguments = string.Empty;
            //this.Language = string.Empty;
            this.TargetCompatibleBrowserVersion = "119.0.2151.40";
            this.AdditionalBrowserArguments = string.Empty;
            this.AllowSingleSignOnUsingOSPrimaryAccount = new CBOOL(true);
            this.ExclusiveUserDataFolderAccess = new CBOOL(false);
            this.IsCustomCrashReportingEnabled = new CBOOL(false);
            this.EnableTrackingPrevention = new CBOOL(false);
            this.CustomSchemeRegistrations = new List<WebView2CustomSchemeRegistration>();

        }

        protected string AdditionalBrowserArguments { get; set; }
        protected string Language { get; set; }
        protected string TargetCompatibleBrowserVersion { get; set; }
        protected int AllowSingleSignOnUsingOSPrimaryAccount { get; set; }
        protected int ExclusiveUserDataFolderAccess { get; set; }
        protected int IsCustomCrashReportingEnabled { get; set; }
        protected int EnableTrackingPrevention { get; set; }
        public List<WebView2CustomSchemeRegistration> CustomSchemeRegistrations { get; }

    }
}
