using System;
using System.IO;
using System.Runtime.InteropServices;
using Diga.Core.Api.Win32;
using Diga.Core.Api.Win32.GDI;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoreWindowsWrapper
{
    public class NativeBitmap : NativeLabel
    {
        private bool _created = false;
        private string _bitMap;
        private byte[] _data;

        protected override void Initialize()
        {
            base.Initialize();
            this.ControlType = Win32ApiForm.ControlType.Label;
            this.TypeIdentifier = "static";
            this.Style = WindowStylesConst.WS_VISIBLE | WindowStylesConst.WS_CHILD | StaticControlStyles.SS_BITMAP | StaticControlStyles.SS_NOTIFY;

        }
        protected override void AfterCreate()
        {
            base.AfterCreate();
            _created = true;
            Refresh();
        }

#nullable enable
        public string? BitMap
        {
            get => _bitMap;
            set
            {
                if (_bitMap == value) return;
                _bitMap = value;
                if (_created)
                    Refresh();
            }
        }
        public byte[]? Data
        {
            get => _data; set
            {
                if (_data == value) return;
                _data = value;
                if (_created)
                    Refresh();
            }
        }
        public void Refresh()
        {
            if (!string.IsNullOrEmpty(this.BitMap))
            {
                if (!File.Exists(this.BitMap)) return;
                IntPtr hBmp = Tools.ImageTool.SafeLoadBitmapFromFile(this.BitMap);
                User32.SendMessage(this.Handle, StaticControlMessages.STM_SETIMAGE, ImageTypeConst.IMAGE_BITMAP, hBmp);
            }
            else if (Data?.Length > 0)
            {

                var lpBites = System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(Data, 0);
                var hBitmap = Gdi32.CreateBitmap(258, 96, 1, 24, lpBites);
                User32.SendMessage(this.Handle, StaticControlMessages.STM_SETIMAGE, ImageTypeConst.IMAGE_BITMAP, hBitmap);

                //var screenDC = GetDC(this.Handle);
                //var compatibleDC = Gdi32.CreateCompatibleDC(screenDC);
                //var oldBitmap = Gdi32.SelectObject(compatibleDC, hBitmap);
                //const int SRCCOPY = 0x00CC0020;
                //Gdi32.BitBlt(screenDC, Left, Top, 258, 96, compatibleDC, 0, 0, SRCCOPY);

                //Gdi32.SelectObject(compatibleDC, oldBitmap);
                //Gdi32.DeleteObject(hBitmap);
                //ReleaseDC(this.Handle, screenDC);
                //ReleaseDC(this.Handle, compatibleDC);

            }

        }
        [DllImport("user32.dll", EntryPoint = "GetDC")]
        private static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        private static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
        protected override bool ControlProc(IntPtr hWndParent, IntPtr hWndControl, int controlId, uint command, IntPtr wParam, IntPtr lParam)
        {
            bool handled = false;
            switch (command)
            {
                case StaticControlMessages.STN_DBLCLK:

                    OnDblClicked();
                    handled = true;
                    break;
                case StaticControlMessages.STN_CLICKED:
                    OnClicked();
                    handled = true;
                    break;


            }

            return handled;
        }
    }
}