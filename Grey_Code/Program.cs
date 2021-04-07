using System;
using System.Windows.Forms;

namespace Grey_Code
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Init();
        }

        static void Init ()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
