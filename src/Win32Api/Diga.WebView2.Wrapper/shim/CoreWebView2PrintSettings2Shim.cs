using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using System.Diagnostics;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2PrintSettings2Shim : CoreWebView2PrintSettingsShim
    {
        private ComObjectHolder<ICoreWebView2PrintSettings2> _PrintSettings;
        private ICoreWebView2PrintSettings2 PrinterSettings
        {
            get
            {
                if (_PrintSettings == null)
                {
                    Debug.Print(nameof(CoreWebView2PrintSettings2Shim) + "." + nameof(PrinterSettings) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2PrintSettings2Shim) + "." + nameof(PrinterSettings) + " is null");

                }
                return _PrintSettings.Interface;
            }
            set => _PrintSettings = new ComObjectHolder<ICoreWebView2PrintSettings2>(value);
        }
        public CoreWebView2PrintSettings2Shim(ICoreWebView2PrintSettings2 printSettings) : base(printSettings)
        {
            PrinterSettings = printSettings;
        }

        public string PageRanges { get => PrinterSettings.GetPageRanges(); set => PrinterSettings.SetPageRanges(value); }
        public int PagesPerSide { get => PrinterSettings.GetPagesPerSide(); set => PrinterSettings.SetPagesPerSide(value); }
        public int Copies { get => PrinterSettings.GetCopies(); set => PrinterSettings.SetCopies(value); }
        public COREWEBVIEW2_PRINT_COLLATION Collation { get => PrinterSettings.GetCollation(); set => PrinterSettings.SetCollation(value); }
        public COREWEBVIEW2_PRINT_COLOR_MODE ColorMode { get => PrinterSettings.GetColorMode(); set => PrinterSettings.SetColorMode(value); }
        public COREWEBVIEW2_PRINT_DUPLEX Duplex { get => PrinterSettings.GetDuplex(); set => PrinterSettings.SetDuplex(value); }
        public COREWEBVIEW2_PRINT_MEDIA_SIZE MediaSize { get => PrinterSettings.GetMediaSize(); set => PrinterSettings.SetMediaSize(value); }
        public string PrinterName { get => PrinterSettings.GetPrinterName(); set => PrinterSettings.SetPrinterName(value); }
    }
}
