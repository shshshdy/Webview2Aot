using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebviewTestAot
{
    public static class CommonEx
    {
        public static nint ToUint(this byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(stream);
                return bmp.GetHbitmap(System.Drawing.Color.FromArgb(0));
            }
        }
    }
}
