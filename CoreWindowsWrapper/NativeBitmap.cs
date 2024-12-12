using System;
using System.IO;
using Diga.Core.Api.Win32;

namespace CoreWindowsWrapper
{
    public class NativeBitmap : NativeLabel
    {
        private bool _created = false;
        private object _source;

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
        /// <summary>
        /// bitmap文件路径<br/>
        /// 或者bitmap内存地址
        /// </summary>
        public object? Source
        {
            get => _source;
            set
            {
                if (_source == value) return;
                _source = value;
                if (_created)
                    Refresh();
            }
        }
        public void Refresh()
        {
            if (Source == null) return;
            if (Source.GetType() == typeof(string))
            {
                var path = Source.ToString();
                if (!string.IsNullOrEmpty(path))
                {
                    if (!File.Exists(path)) return;
                    IntPtr hBmp = Tools.ImageTool.SafeLoadBitmapFromFile(path);
                    User32.SendMessage(Handle, StaticControlMessages.STM_SETIMAGE, ImageTypeConst.IMAGE_BITMAP, hBmp);
                }
            }
            else if (Source.GetType() == typeof(nint))
            {
                var hBmp = (nint)Source;
                if (hBmp != IntPtr.Zero)
                    User32.SendMessage(this.Handle, StaticControlMessages.STM_SETIMAGE, ImageTypeConst.IMAGE_BITMAP, hBmp);
            }

        }
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