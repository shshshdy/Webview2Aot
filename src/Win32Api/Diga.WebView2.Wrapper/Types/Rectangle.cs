using Diga.WebView2.Interop;

namespace Diga.WebView2.Wrapper.Types
{
    public class Rectangle
    {
        private RECT _Rect;

        public static implicit operator RECT(Rectangle input)
        {
            return input._Rect;
        }

        public static implicit operator Rectangle(RECT input)
        {
            return new Rectangle(input);
        }

        public Rectangle()
        {
            this._Rect = new RECT();
        }

        public Rectangle(RECT rect)
        {
            this._Rect = rect;
        }
        public int Left
        {
            get => this._Rect.left;
            set => this._Rect.left = value;
        }
        public int Top
        {
            get => this._Rect.top; set => this._Rect.top = value;
        }
        public int Right
        {
            get => this._Rect.right; set => this._Rect.right = value;
        }
        public int Bottom
        {
            get => this._Rect.bottom; set => this._Rect.bottom = value;
        }
    }
}
