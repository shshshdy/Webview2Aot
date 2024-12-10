using CoreWindowsWrapper;

namespace WebviewTestAot
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            NativeApp.ExceptInEvents = true;
            MainForm nw = new MainForm();
            NativeApp.Run(nw);
        }
    }
}
