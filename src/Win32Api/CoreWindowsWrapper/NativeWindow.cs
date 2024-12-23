﻿using System;
using System.Diagnostics;
using Diga.Core.Api.Win32;
using CoreWindowsWrapper.Win32ApiForm;
using System.Threading;
using CoreWindowsWrapper.Tools;

namespace CoreWindowsWrapper
{
    public class NativeWindow : IControl, IDisposable
    {

        public static bool TryGetWindow(IntPtr hWnd, out NativeWindow wnd)
        {
            if (Win32Window.WindowList.ContainsKey(hWnd))
            {
                var item = Win32Window.WindowList[hWnd];
                wnd = new NativeWindow(item);
                return true;
            }
            wnd = null;
            return false;
        }
        private Win32Window _Window;
        private bool IsHookWindow
        {
            get
            {
                if (this._Window == null)
                    return false;
                return this._Window.IsHookedWindow;
            }
        }
        internal bool IsMainWindow
        {
            get
            {
                if (this._Window != null)
                    return this._Window.IsMainWindow;
                return this._IsMainWindow;
            }
            set
            {
                this._IsMainWindow = value;
                if (this._Window != null)
                    this._Window.IsMainWindow = value;
            }
        }

        private NativeWindow ParentWindow = null;
        public ControlCollection Controls => this._Window.Controls;
        private WindowsStartupPosition _StartUpPosition;
        private bool _isCreated = false;
        private bool _IsMainWindow;
        private bool _IsPanel;
        internal bool IsPanel
        {
            get
            {
                if (this._Window != null)
                    return this._Window.IsPanel;
                return this._IsPanel;
            }
            set
            {
                this._IsPanel = value;
                if (this._Window != null)
                    this._Window.IsPanel = value;
            }
        }
        private DockType _DockType;
        internal DockType DockType
        {
            get
            {
                if (this._Window != null)
                    return this._Window.DockType;
                return this._DockType;
            }
            set
            {
                this._DockType = value;
                if (this._Window != null)
                    this._Window.DockType = value;
            }
        }
        public NativeMenu Menu
        {
            get => (NativeMenu)this._Window.Menu;
            set => this._Window.Menu = value;
        }
        public IntPtr Handle
        {
            get
            {
                if (this._Window != null)
                {
                    return this._Window.Handle;
                }
                return IntPtr.Zero;
            }
        }

        private bool _opacity;
        /// <summary>
        /// 设置背景色
        /// </summary>
        public bool Opacity
        {
            get => _opacity;
            set
            {
                if (_opacity == value) return;
                _opacity = value;
                if (value)
                {
                    if (BackColor == 0xF0F0F0)
                    {
                        BackColor = ColorTool.Yellow;
                    }
                }
                if (_isCreated)
                    ChangeOpacity();
            }
        }

        private void ChangeOpacity()
        {
            if (_opacity)
            {
                UpdateExStyle(WindowStylesConst.WS_EX_LAYERED);
                User32.SetLayeredWindowAttributes(Handle, (uint)_Window.Color, 0, Win32Window.LWA_COLORKEY);
            }
        }

        bool _showBodyFrame = true;
        /// <summary>
        /// 显示边框
        /// </summary>
        public bool ShowBodyFrame
        {
            get => _showBodyFrame;
            set
            {
                if (_showBodyFrame == value) return;
                _showBodyFrame = value;
                if (_isCreated)
                    ChangeBodyFrame();
            }
        }

        private void ChangeBodyFrame()
        {
            if (!_showBodyFrame)
            {
                var style = GetWindowStyle();
                style = style & ~WindowStylesConst.WS_CAPTION & ~WindowStylesConst.WS_SYSMENU & ~WindowStylesConst.WS_SIZEBOX;
                UpdateStyle(style);
                User32.ShowWindow(Handle, 5);
            }
        }

        public IntPtr Accelerators
        {
            get
            {
                if (this._Window != null)
                {
                    return this._Window.AcceleratorTableHandle;
                }
                return IntPtr.Zero;
            }
        }
        public bool LoadAccelerators(int id)
        {
            if (this._Window == null)
                return false;
            if (id < 0)
                return false;
            this._Window.LoadAccelrators(id);
            return true;
        }
        public event EventHandler<CreateEventArgs> Create;
        public event EventHandler<MouseClickEventArgs> DoubleClick;
        public event EventHandler<MouseClickEventArgs> Click;
        public event EventHandler<CreateEventArgs> Destroyed;
        public event EventHandler<MouseClickPositionEventArgs> MouseDown;
        public event EventHandler<MouseClickPositionEventArgs> MouseUp;
        public event EventHandler<MouseMoveEventArgs> MouseMove;
        public event EventHandler<SizeEventArgs> Size;
        public event EventHandler<PaintEventArgs> Paint;
        public event EventHandler<NativeKeyEventArgs> KeyDown;
        public event EventHandler<NativeKeyEventArgs> KeyUp;
        public event EventHandler<NativeKeyEventArgs> SysKeyDown;

        internal NativeWindow(Win32Window wnd)
        {
            this._Window = wnd;
            InitEvents();
            Create += Created;
        }

        public NativeWindow()
        {
            this.ControlType = ControlType.Window;
            Initialize();
            Create += Created;
        }


        public NativeWindow(IntPtr hookWindowHandle)
        {
            this.ControlType = ControlType.Window;
            this._Window = Win32Window.CreateAsHook(hookWindowHandle);
            InitializeHook();
            Create += Created;
        }

        public NativeWindow(NativeWindow parent)
        {
            this.ParentWindow = parent;

            Initialize(parent.Handle);
            this.ParentWindow.Create += OnParentCreate;
            //this.ParentWindow.Destroed += OnParentDestroyed;
            Create += Created;

        }
        private void Created(object sender, CreateEventArgs e)
        {
            ChangeOpacity();
            ChangeBodyFrame();
        }
        private void OnParentDestroyed(object sender, CreateEventArgs e)
        {
            this.Close();
        }

        private void OnParentCreate(object sender, CreateEventArgs e)
        {
            ((IControl)this).ParentHandle = e.Handle;
        }
        public bool SetWindowRectByClientRect(Rect rect)
        {
            var rrect = GetWindowRectByClientRect(rect);
            if (rrect.Width != 0 && rrect.Height != 0)
            {
                this.Left = rrect.Left;
                this.Top = rrect.Top;
                this.Width = rrect.Width;
                this.Height = rrect.Height;
                return true;
            }
            return false;
        }

        public Rect GetWindowRectByClientRect(Rect rect)
        {
            bool result = User32.AdjustWindowRectEx(ref rect, this.GetWindowStyle(), this.Menu != null, this.GetWindowExStyle());
            if (result)
            {
                return rect;
            }
            else
            {
                return new Rect(0, 0, 0, 0);
            }

        }
        public void Close()
        {
            this._Window.Close();
        }

        public IntPtr ParentHandle
        {
            get => ((IControl)this).ParentHandle;
            private set => ((IControl)this).ParentHandle = value;
        }

        IntPtr IControl.ParentHandle
        {
            get => this._Window.ParentHandle;
            set => this._Window.ParentHandle = value;
        }

        public string Name
        {
            get => this._Window.Name;
            set => this._Window.Name = value;
        }

        public string Text
        {
            get
            {

                return this._Window.Text;

            }
            set
            {
                this._Window.Text = value;
                if (this.Handle != IntPtr.Zero)
                    User32.SetWindowText(this.Handle, this._Window.Text);
            }
        }

        public int BackColor
        {
            get { return this._Window.Color; }
            set { this._Window.Color = value; }
        }

        public int Left
        {
            get => this._Window.Left;
            set => this._Window.Left = value;
        }

        public int Top
        {
            get => this._Window.Top;
            set => this._Window.Top = value;
        }

        public int Width
        {
            get => this._Window.Width;
            set => this._Window.Width = value;
        }

        public int Height
        {
            get => this._Window.Height;
            set => this._Window.Height = value;
        }

        public bool StatusBar
        {
            get => this._Window.StatusBar;
            set => this._Window.StatusBar = value;
        }

        public bool Visible
        {
            get => this._Window.Visible;
            set => this._Window.Visible = value;
        }
        public void Invalidate()
        {
            this._Window.Invlidate();
        }



        public void Redraw()
        {
            this._Window.Redraw();
        }
        //public bool ToolBar
        //{
        //    get => this._Window.ToolBar;
        //    set => this._Window.ToolBar = value;
        //}
        public WindowsStartupPosition StartUpPosition
        {
            get
            {
                return this._StartUpPosition;
            }
            set
            {
                this._StartUpPosition = value;
                switch (this._StartUpPosition)
                {
                    case WindowsStartupPosition.Normal:
                        this._Window.CenterForm = false;
                        this._Window.MinimizeForm = false;
                        this._Window.MaximizeForm = false;

                        break;
                    case WindowsStartupPosition.CenterScreen:
                        this._Window.CenterForm = true;
                        this._Window.MinimizeForm = false;
                        this._Window.MaximizeForm = false;
                        break;
                    case WindowsStartupPosition.Maximized:
                        this._Window.CenterForm = false;
                        this._Window.MinimizeForm = false;
                        this._Window.MaximizeForm = true;
                        break;
                    case WindowsStartupPosition.Minimized:
                        this._Window.CenterForm = false;
                        this._Window.MaximizeForm = false;
                        this._Window.MinimizeForm = true;
                        break;
                }
            }
        }

        public Point Location
        {
            get => this._Window.Location;
            set => this._Window.Location = value;

        }


        int IControl.ControlId { get; set; } = -1;
        string IControl.TypeIdentifyer
        {
            get => "window";
            set { Console.Write("Window try to set dietifier=>" + value); }
        }

        public ControlType ControlType { get; set; }

        public string IconFile
        {
            get => this._Window.IconFile;
            set => this._Window.IconFile = value;
        }
        public int IconId
        {
            get => this._Window.IconResourceId;
            set => this._Window.IconResourceId = value;
        }
        public int ForeColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Font Font { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        bool IControl.Create(IntPtr parentId)
        {
            this._Window.ParentHandle = parentId;
            bool val = this._Window.Create(true);
            return val;
        }

        bool IControl.ClientEdge { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Enabled
        {
            get => this._Window.Enable;
            set => this._Window.Enable = value;
        }

        public bool HandleEvents(IntPtr hWndParent, IntPtr hWndControl, int controlId, uint command, IntPtr wParam, IntPtr lParam)
        {
            throw new NotImplementedException();
        }

        private void Initialize()
        {
            this._Window = new Win32Window(this.IsMainWindow);
            //{
            //    Style = WindowStylesConst.WS_CAPTION | WindowStylesConst.WS_SYSMENU |
            //            WindowStylesConst.WS_EX_STATICEDGE
            //};
            InitDefaults();
        }

        private void InitEvents()
        {
            this._Window.BeforeCreate += OnBeforeCreateInternal;
            this._Window.CreateForm += OnCreateForm;
            this._Window.DoubleClick += OnFormDoubleClick;
            this._Window.Click += OnFormClick;
            this._Window.Destroyed += OnDestroyed;
            this._Window.MouseDown += OnFormMouseDown;
            this._Window.MouseUp += OnFormMouseUp;
            this._Window.Size += OnFormSize;
            this._Window.Paint += OnPaintIntern;
            this._Window.MouseMove += OnMouseMoveIntern;
            this._Window.KeyDown += OnKeyDownInternal;
            this._Window.KeyUp += OnKeyUpInternal;
            this._Window.SysKeyDown += OnSysKeyDownInternal;
            this._Window.ParentResize += OnParentResizeInternl;


        }

        private void OnParentResizeInternl(object sender, EventArgs e)
        {
            OnParentResize();
        }

        private void OnSysKeyDownInternal(object sender, NativeKeyEventArgs e)
        {
            OnSysKeyDown(e);
        }

        private void OnKeyUpInternal(object sender, NativeKeyEventArgs e)
        {
            OnKeyUp(e);
        }

        private void OnKeyUp(NativeKeyEventArgs e)
        {
            KeyUp?.Invoke(this, e);
        }

        private void OnKeyDownInternal(object sender, NativeKeyEventArgs e)
        {
            OnKeyDown(e);
        }

        private void OnBeforeCreateInternal(object sender, BeforeWindowCreateEventArgs e)
        {
            OnBeforeCreate(e);
        }

        protected virtual void OnBeforeCreate(BeforeWindowCreateEventArgs e)
        {
            //Do something;
        }
        private void OnMouseMoveIntern(object sender, MouseMoveEventArgs e)
        {
            //Do something
            OnMouseMove(e);

        }

        private void OnPaintIntern(object sender, PaintEventArgs e)
        {
            //Do some paint
            //Debug.Print("OnPaint in window=>" + this.Name);
            OnPaint(e);
        }

        private void InitDefaults()
        {
            this.StartUpPosition = WindowsStartupPosition.Normal;
            InitEvents();
            this._Window.Width = unchecked((int)0x80000000);
            this._Window.Height = unchecked((int)0x80000000);
            this._Window.Left = unchecked((int)0x80000000);
            this._Window.Top = unchecked((int)0x80000000);
            InitControls();
        }

        private void OnFormSize(object sender, SizeEventArgs e)
        {
            this.OnSize(e);
        }

        private void OnFormMouseUp(object sender, MouseClickPositionEventArgs e)
        {
            this.OnMouseUp(e);
        }

        private void OnFormMouseDown(object sender, MouseClickPositionEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void OnMouseUp(MouseClickPositionEventArgs e)
        {
            SafeInvoke(this.MouseUp, e);
            //this.MouseUp?.Invoke(this,e);
        }

        private void OnMouseDown(MouseClickPositionEventArgs e)
        {
            SafeInvoke(this.MouseDown, e);

        }

        private void OnDestroyed(object sender, CreateEventArgs e)
        {
            Destroyed?.Invoke(this, e);
            this.Destroy();
        }

        private void InitializeHook()
        {
            InitEvents();
            InitControls();
        }
        private void Initialize(IntPtr parentHandle)
        {
            this._Window = new Win32Window(parentHandle, this.IsMainWindow, this.IsPanel, this.DockType);

            InitDefaults();
        }

        protected virtual void InitControls()
        {
            //INitControls
        }

        public void Dispatch()
        {
            this._Window.Dispatch();
        }

        private void OnFormClick(object sender, MouseClickEventArgs e)
        {
            this.OnClick(e);

        }

        private void SafeInvoke<T>(EventHandler<T> eventHandler, T ars) where T : EventArgs
        {
            try
            {
                eventHandler?.Invoke(this, ars);
            }
            catch (Exception e)
            {
                MessageBox.Show("Event Error:" + e.Message + Environment.NewLine + e.StackTrace.ToString());
            }
        }

        private void OnFormDoubleClick(object sender, MouseClickEventArgs e)
        {
            this.OnDoubleClick(e);
        }

        private void OnCreateForm(object sender, CreateEventArgs e)
        {

            this.OnCreate(e);
        }
        //private bool IsDestroyed = false;
        public void ShowModal(NativeWindow parent)
        {
            ManualResetEvent manualResetEvent = new ManualResetEvent(false);

            this.ParentWindow = parent;
            if (this.ParentWindow != null)
                this.ParentWindow.Enabled = false;
            this._Window.Create();
            this._Window.Destroyed += (o, e) =>
            {
                NativeApp.StopModalDispatch();
            };
            NativeApp.RunModalDispatch();

        }
        public void Show()
        {

            this._Window.Create();

        }

        protected virtual void OnCreate(CreateEventArgs e)
        {
            SafeInvoke(this.Create, e);
            //Create?.Invoke(this, e);
        }

        protected virtual void OnDoubleClick(MouseClickEventArgs e)
        {
            SafeInvoke(this.DoubleClick, e);
            //DoubleClick?.Invoke(this, e);

        }

        protected virtual void OnClick(MouseClickEventArgs e)
        {
            SafeInvoke(this.Click, e);
            //Click?.Invoke(this, e);
        }

        public void Destroy()
        {
            // ReSharper disable once RedundantCheckBeforeAssignment
            if (this.ParentWindow != null)
            {

                this.ParentWindow.Create -= OnParentCreate;
                this.ParentWindow.Destroyed -= OnParentDestroyed;
                this.ParentWindow.Enabled = true;
                this.ParentWindow = null;
                //this._Window.Close();
            }
            //IsDestroyed = true;
            Debug.Write("On Window Destroy");
        }


        public void AttachToWindow(IntPtr parent)
        {
            this._Window.AttachToWindow(parent);
        }

        protected virtual void OnSize(SizeEventArgs e)
        {
            Size?.Invoke(this, e);
        }
        public virtual void OnParentResize()
        {

        }
        public virtual void OnKeyDown(NativeKeyEventArgs e)
        {
            KeyDown?.Invoke(this, e);
        }
        public Rect GetClientRect()
        {
            return this._Window.GetCleanClientRect();
        }

        public void PostCreateControls()
        {
            this._Window.PostCreateControls();
        }
        public void Dispose()
        {
            this._Window?.Dispose();
        }

        protected virtual void OnMouseMove(MouseMoveEventArgs e)
        {
            MouseMove?.Invoke(this, e);
        }

        protected virtual void OnPaint(PaintEventArgs e)
        {
            Paint?.Invoke(this, e);
        }

        public uint GetWindowStyle()
        {
            return this._Window.GetStyle();
        }

        public uint GetWindowExStyle()
        {
            return this._Window.GetExStyle();
        }
        public void SetWindowState(WindowState state)
        {
            this._Window.SetWindowState(state);
        }

        public WindowState GetWindowState()
        {
            return this._Window.GetWindowState();
        }

        public void UpdateStyle(uint style)
        {
            this._Window.UpdateStyle(style);
        }

        public void UpdateExStyle(uint exStyle)
        {
            this._Window.UpdateExStyle(exStyle);
        }


        public void UpdateWidow()
        {
            this._Window.UpdateWidow();
        }

        protected virtual void OnSysKeyDown(NativeKeyEventArgs e)
        {
            SysKeyDown?.Invoke(this, e);
        }
    }
}