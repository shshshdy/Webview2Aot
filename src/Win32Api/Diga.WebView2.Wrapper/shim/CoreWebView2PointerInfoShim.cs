using Diga.WebView2.Interop;
using Diga.WebView2.Wrapper.Types;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.WebView2.Wrapper.shim
{

    public class CoreWebView2PointerInfoShim : IDisposable
    {
        private ComObjectHolder<ICoreWebView2PointerInfo> _PointerInfo;
        /// Wraps in SafeHandle so resources can be released if consumer forgets to call Dispose. Recommended
        ///             pattern for any type that is not sealed.
        ///             https://docs.microsoft.com/dotnet/api/system.idisposable#idisposable-and-the-inheritance-hierarchy
        private SafeHandle handle = new SafeFileHandle(nint.Zero, true);
        private bool disposedValue;

        private ICoreWebView2PointerInfo PointerInfo
        {
            get
            {
                if (_PointerInfo == null)
                {
                    Debug.Print($"{nameof(CoreWebView2PointerInfoShim)} is null!");
                    throw new InvalidOperationException($"{nameof(CoreWebView2PointerInfoShim)} is null!");
                }
                return _PointerInfo.Interface;
            }
            set
            {
                _PointerInfo = new ComObjectHolder<ICoreWebView2PointerInfo>(value);
            }
        }
        public CoreWebView2PointerInfoShim(ICoreWebView2PointerInfo pointerInfo)
        {
            PointerInfo = pointerInfo;
        }

        public uint PointerKind { get => PointerInfo.GetPointerKind(); set => PointerInfo.SetPointerKind(value); }
        public uint PointerId { get => PointerInfo.GetPointerId(); set => PointerInfo.SetPointerId(value); }
        public uint FrameId { get => PointerInfo.GetFrameId(); set => PointerInfo.SetFrameId(value); }
        public uint PointerFlags { get => PointerInfo.GetPointerFlags(); set => PointerInfo.SetPointerFlags(value); }
        public RECT PointerDeviceRect { get => PointerInfo.GetPointerDeviceRect(); set => PointerInfo.SetPointerDeviceRect(value); }
        public RECT DisplayRect { get => PointerInfo.GetDisplayRect(); set => PointerInfo.SetDisplayRect(value); }
        public POINT PixelLocation { get => PointerInfo.GetPixelLocation(); set => PointerInfo.SetPixelLocation(value); }
        public POINT HimetricLocation { get => PointerInfo.GetHimetricLocation(); set => PointerInfo.SetHimetricLocation(value); }
        public POINT PixelLocationRaw { get => PointerInfo.GetPixelLocationRaw(); set => PointerInfo.SetPixelLocationRaw(value); }
        public POINT HimetricLocationRaw { get => PointerInfo.GetHimetricLocationRaw(); set => PointerInfo.SetHimetricLocationRaw(value); }
        public uint Time { get => PointerInfo.GetTime(); set => PointerInfo.SetTime(value); }
        public uint HistoryCount { get => PointerInfo.GetHistoryCount(); set => PointerInfo.SetHistoryCount(value); }
        public int InputData { get => PointerInfo.GetInputData(); set => PointerInfo.SetInputData(value); }
        public uint KeyStates { get => PointerInfo.GetKeyStates(); set => PointerInfo.SetKeyStates(value); }
        public ulong PerformanceCount { get => PointerInfo.GetPerformanceCount(); set => PointerInfo.SetPerformanceCount(value); }
        public int ButtonChangeKind { get => PointerInfo.GetButtonChangeKind(); set => PointerInfo.SetButtonChangeKind(value); }
        public uint PenFlags { get => PointerInfo.GetPenFlags(); set => PointerInfo.SetPenFlags(value); }
        public uint PenMask { get => PointerInfo.GetPenMask(); set => PointerInfo.SetPenMask(value); }
        public uint PenPressure { get => PointerInfo.GetPenPressure(); set => PointerInfo.SetPenPressure(value); }
        public uint PenRotation { get => PointerInfo.GetPenRotation(); set => PointerInfo.SetPenRotation(value); }
        public int PenTiltX { get => PointerInfo.GetPenTiltX(); set => PointerInfo.SetPenTiltX(value); }
        public int PenTiltY { get => PointerInfo.GetPenTiltY(); set => PointerInfo.SetPenTiltY(value); }
        public uint TouchFlags { get => PointerInfo.GetTouchFlags(); set => PointerInfo.SetTouchFlags(value); }
        public uint TouchMask { get => PointerInfo.GetTouchMask(); set => PointerInfo.SetTouchMask(value); }
        public RECT TouchContact { get => PointerInfo.GetTouchContact(); set => PointerInfo.SetTouchContact(value); }
        public RECT TouchContactRaw { get => PointerInfo.GetTouchContactRaw(); set => PointerInfo.SetTouchContactRaw(value); }
        public uint TouchOrientation { get => PointerInfo.GetTouchOrientation(); set => PointerInfo.SetTouchOrientation(value); }
        public uint TouchPressure { get => PointerInfo.GetTouchPressure(); set => PointerInfo.SetTouchPressure(value); }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    handle.Dispose();
                    _PointerInfo = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public ICoreWebView2PointerInfo GetInterface()
        {
            return PointerInfo;
        }

    }
}
