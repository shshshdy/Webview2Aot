using System;
using System.IO;
using Diga.Core.Api.Win32;

namespace CoreWindowsWrapper
{
    public class NativeBitmap : NativeLabel
    {
        private string _bitMap;
        private byte[] _data;

        protected override void Initialize()
        {
            base.Initialize();
            this.ControlType = Win32ApiForm.ControlType.Label;
            this.TypeIdentifier = "static";
            this.Style = WindowStylesConst.WS_VISIBLE | WindowStylesConst.WS_CHILD | StaticControlStyles.SS_BITMAP | StaticControlStyles.SS_NOTIFY;

        }

#nullable enable
        public string? BitMap
        {
            get => _bitMap;
            set
            {
                if (_bitMap == value) return;
                _bitMap = value;
                Refresh();
            }
        }
        public byte[]? Data
        {
            get => _data; set
            {
                if (_data == value) return;
                _data = value;
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
                IntPtr hBmp = Tools.ImageTool.SafeLoadBitmapFromResource(Data);
                User32.SendMessage(this.Handle, StaticControlMessages.STM_SETIMAGE, ImageTypeConst.IMAGE_BITMAP, hBmp);
            }


        }

    }
}