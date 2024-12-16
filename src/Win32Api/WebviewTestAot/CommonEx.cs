namespace WebviewTestAot
{
    public static class CommonEx
    {
        /// <summary>
        /// 任意图片转bmp内存地址
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
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
