using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rClone_Downloader
{
    static class Program
    {
        public static MainUI mainUI { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!File.Exists(@"C:\rclone\rclone.exe"))
            {
                MessageBox.Show("rClone needs to be installed to C:\rclone", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\rclone\rclone.conf"))
            {
                MessageBox.Show("rClone has not been setup", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Properties.Settings.Default.Path == "")
            {
                OpenFileDialog fileDialog = new OpenFileDialog();

                fileDialog.Filter = "Application|rclone.exe";
                fileDialog.Multiselect = false;
                fileDialog.DefaultExt = ".exe";
                fileDialog.CheckPathExists = true;
                fileDialog.InitialDirectory = @"C:\";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.Path = fileDialog.FileName;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    fileDialog.Dispose();
                    return;
                }

                fileDialog.Dispose();
            }

            mainUI = new MainUI();

            CenterToScreen(mainUI);

            Application.Run(mainUI);
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
