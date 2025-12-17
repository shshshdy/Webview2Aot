using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{
    public class CoreWebView2PrintSettingsShim : IDisposable
    {
        private ComObjectHolder<ICoreWebView2PrintSettings> _PrintSettings;
        private bool _IsDesposed;
        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private readonly SafeHandle handle = new SafeFileHandle(nint.Zero, true);

        private ICoreWebView2PrintSettings PrinterSettings
        {
            get
            {
                if (_PrintSettings == null)
                {
                    Debug.Print(nameof(CoreWebView2PrintSettingsShim) + "." + nameof(PrinterSettings) + " is null");
                    throw new InvalidOperationException(nameof(CoreWebView2PrintSettingsShim) + "." + nameof(PrinterSettings) + " is null");

                }
                return _PrintSettings.Interface;
            }
            set => _PrintSettings = new ComObjectHolder<ICoreWebView2PrintSettings>(value);
        }

        public CoreWebView2PrintSettingsShim(ICoreWebView2PrintSettings printSettings)
        {
            PrinterSettings = printSettings;
            //CloneInterface(printSettings);
        }

        public ComObjectHolder<ICoreWebView2PrintSettings> NativeSettings => _PrintSettings;
        //private void CloneInterface(ICoreWebView2PrintSettings printSettings)
        //{
        //    this.FooterUri = printSettings.FooterUri;
        //    this.HeaderTitle = printSettings.HeaderTitle;
        //    this.MarginBottom = printSettings.MarginBottom;
        //    this.MarginLeft = printSettings.MarginLeft;
        //    this.MarginRight = printSettings.MarginRight;
        //    this.MarginTop = printSettings.MarginTop;
        //    this.Orientation = printSettings.Orientation;
        //    this.PageHeight = printSettings.PageHeight;
        //    this.PageWidth = printSettings.PageWidth;
        //    this.ScaleFactor = printSettings.ScaleFactor;
        //    this.ShouldPrintBackgrounds = printSettings.ShouldPrintBackgrounds;
        //    this.ShouldPrintHeaderAndFooter = printSettings.ShouldPrintHeaderAndFooter;
        //    this.ShouldPrintSelectionOnly = printSettings.ShouldPrintSelectionOnly;
        //}
        public COREWEBVIEW2_PRINT_ORIENTATION Orientation { get => PrinterSettings.GetOrientation(); set => PrinterSettings.SetOrientation(value); }
        public double ScaleFactor { get => PrinterSettings.GetScaleFactor(); set => PrinterSettings.SetScaleFactor(value); }
        public double PageWidth { get => PrinterSettings.GetPageWidth(); set => PrinterSettings.SetPageWidth(value); }
        public double PageHeight { get => PrinterSettings.GetPageHeight(); set => PrinterSettings.SetPageHeight(value); }
        public double MarginTop { get => PrinterSettings.GetMarginTop(); set => PrinterSettings.SetMarginTop(value); }
        public double MarginBottom { get => PrinterSettings.GetMarginBottom(); set => PrinterSettings.SetMarginBottom(value); }
        public double MarginLeft { get => PrinterSettings.GetMarginLeft(); set => PrinterSettings.SetMarginLeft(value); }
        public double MarginRight { get => PrinterSettings.GetMarginRight(); set => PrinterSettings.SetMarginRight(value); }
        public int ShouldPrintBackgrounds { get => PrinterSettings.GetShouldPrintBackgrounds(); set => PrinterSettings.SetShouldPrintBackgrounds(value); }
        public int ShouldPrintSelectionOnly { get => PrinterSettings.GetShouldPrintSelectionOnly(); set => PrinterSettings.SetShouldPrintSelectionOnly(value); }
        public int ShouldPrintHeaderAndFooter { get => PrinterSettings.GetShouldPrintHeaderAndFooter(); set => PrinterSettings.SetShouldPrintHeaderAndFooter(value); }
        public string HeaderTitle { get => PrinterSettings.GetHeaderTitle(); set => PrinterSettings.SetHeaderTitle(value); }
        public string FooterUri { get => PrinterSettings.GetFooterUri(); set => PrinterSettings.SetFooterUri(value); }

        protected virtual void Dispose(bool disposing)
        {
            if (!_IsDesposed)
            {
                if (disposing)
                {
                    handle.Dispose();
                    //this._PrintSettings = null;
                }


                _IsDesposed = true;
            }
        }



        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public ICoreWebView2PrintSettings ToInterface() => this.PrinterSettings;
        //public COREWEBVIEW2_PRINT_ORIENTATION Orientation { get; set; }
        //public double ScaleFactor { get; set; }
        //public double PageWidth { get; set; }
        //public double PageHeight { get; set; }
        //public double MarginTop { get; set; }
        //public double MarginBottom { get; set; }
        //public double MarginLeft { get; set; }
        //public double MarginRight { get; set; }
        //public int ShouldPrintBackgrounds { get; set; }
        //public int ShouldPrintSelectionOnly { get; set; }
        //public int ShouldPrintHeaderAndFooter { get; set; }
        //public string HeaderTitle { get; set; }
        //public string FooterUri { get; set; }
    }
}
