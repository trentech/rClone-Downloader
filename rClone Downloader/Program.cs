using System;
using System.Windows.Forms;

namespace rClone_GUI
{
    static class Program
    {
        public static MainUI mainUI { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UIStart UIStart = new UIStart();
        }
    }
}
