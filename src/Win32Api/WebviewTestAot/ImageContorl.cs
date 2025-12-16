using CoreWindowsWrapper;

namespace WebviewTestAot
{
    internal class ImageContorl : NativeBitmap
    {
        public override object? PreSource(object? source)
        {
            if (source == null) return null;
            if (source.GetType() == typeof(string))
            {
                var path = source.ToString()!;
                var ext = Path.GetExtension(path);
                if (ext == null) return source;
                if (ext.ToLower() != ".bmp")
                {
                    using var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(stream);
                    return bmp.GetHbitmap(System.Drawing.Color.FromArgb(0));
                }
            }
            return source;
        }
    }
}
