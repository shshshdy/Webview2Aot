using CoreWindowsWrapper;

namespace WebviewTestAot
{
    internal class Program
    {
        public static string? ServerPrivateCertAllow { get; private set; }
        [STAThread]
        static void Main(string[] args)
        {
            NativeApp.ExceptInEvents = true;
            MainForm nw = new MainForm();
            NativeApp.Run(nw);
        }
    }
}
