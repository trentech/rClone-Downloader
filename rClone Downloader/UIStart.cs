using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace rClone_GUI
{
    public partial class UIStart : Form
    {
        private string rClone;
        private string directory;
        [DllImport("kernel32.dll",
            EntryPoint = "AllocConsole",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();

        public UIStart()
        {
            InitializeComponent();

            Screen screen = Screen.FromControl(this);
            Rectangle workingArea = screen.WorkingArea;

            Location = new Point
            {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - Height) / 2)
            };

            directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            rClone = directory + @"\rClone\rclone.exe";

            if (!File.Exists(rClone))
            {
                Show();

                using (var client = new WebClient())
                {
                    client.DownloadFileCompleted += (s, e) =>
                    {
                        label1.Text = "Extracting...";
                        ZipFile.ExtractToDirectory(directory + @"\rclone-current-windows-amd64.zip", directory);

                        foreach (DirectoryInfo dir in new DirectoryInfo(directory).GetDirectories())
                        {
                            if (dir.Name.StartsWith("rclone-v") && dir.Name.EndsWith("-windows-amd64"))
                            {
                                Directory.Move(dir.FullName, directory + @"\rClone");
                            }
                        }

                        File.Delete(directory + @"\rclone-current-windows-amd64.zip");
                    };

                    client.DownloadProgressChanged += (s, e) =>
                    {
                        label1.Text = $"Downloading rClone {e.ProgressPercentage}%";
                    };

                    client.DownloadFileAsync(new Uri("https://downloads.rclone.org/rclone-current-windows-amd64.zip"), "rclone-current-windows-amd64.zip");

                    while (client.IsBusy) { Application.DoEvents(); }
                }
            }

            Hide();

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\rclone\rclone.conf"))
            {
                AllocConsole();
                // NEED A WAY TO ALLOW USERS TO CONFIGURE RCLONE...

                // BELOW DOES NOT WORK

/*                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = @"/C " + rClone + " config";

                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                }*/

                MessageBox.Show("rClone has not been setup", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.mainUI = new MainUI(rClone);
            Program.mainUI.ShowDialog();
            Close();
        }
    }
}
