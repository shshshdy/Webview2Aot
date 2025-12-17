using Diga.WebView2.Wrapper.Types;

namespace Diga.WebView2.Wrapper
{
    public class SchemeRegistration
    {
        public string SchemeName { get; set; }
        public bool TreatAsSecure { get; set; }
        public string[] AllowedOrignis { get; set; } = { };


        internal WebView2CustomSchemeRegistration GetAsWebView2CustomSchemeRegistration()
        {
            var newValue = new WebView2CustomSchemeRegistration(this.SchemeName);
            newValue.AllowedOrgins.AddRange(this.AllowedOrignis);
            newValue.SetTreatAsSecure((CBOOL)this.TreatAsSecure);
            return newValue;
        }
    }
}
