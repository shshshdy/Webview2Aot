using Diga.WebView2.Interop;

namespace Diga.WebView2.Wrapper.Types
{
    public class Point
    {
        private POINT _Point;

        public static implicit operator POINT(Point input)
        {
            return input._Point;
        }

        public static implicit operator Point(POINT input)
        {
            return new Point(input);
        }
        public Point()
        {
            this._Point = new POINT();

        }

        public Point(POINT point)
        {
            this._Point = point;
        }
        public int x
        {
            get => this._Point.x;
            set => this._Point.x = value;
        }

        public int y
        {
            get => this._Point.y;
            set => this._Point.y = value;
        }
    }
}
