using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rClone_Downloader
{
    static class Program
    {
        public static MainUI mainUI { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string rClone = directory + @"\rClone\rclone.exe";

            if (!File.Exists(rClone))
            {
                rCloneDownload rCloneDownload = new rCloneDownload();

                CenterToScreen(rCloneDownload);

                Application.Run(rCloneDownload);

                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\rclone\rclone.conf"))
                {
                    // NEED A WAY TO ALLOW USERS TO CONFIGURE RCLONE...
                    MessageBox.Show("rClone has not been setup", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            } else
            {
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\rclone\rclone.conf"))
                {
                    // NEED A WAY TO ALLOW USERS TO CONFIGURE RCLONE...
                    MessageBox.Show("rClone has not been setup", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mainUI = new MainUI(rClone);

                CenterToScreen(mainUI);

                Application.Run(mainUI);
            }
        }

        public static void CenterToScreen(Form form)
        {
            Screen screen = Screen.FromControl(form);
            Rectangle workingArea = screen.WorkingArea;

            form.Location = new Point
            {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - form.Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - form.Height) / 2)
            };
        }
    }
}
