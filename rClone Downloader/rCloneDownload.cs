using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rClone_Downloader
{
    public partial class rCloneDownload : Form
    {
        public rCloneDownload()
        {
            InitializeComponent();

            string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string rClone = directory + @"\rClone\rclone.exe";

            using (var client = new WebClient())
            {
                client.DownloadFileCompleted += (s, e) => {
                    label1.Text = "Extracting...";
                    ZipFile.ExtractToDirectory(directory + @"\rclone-current-windows-amd64.zip", directory);
                    // Regex regularExpression = new Regex("rclone-v\\d.\\d{2}.{0,1}d{0,2}-windows-amd64");

                    foreach (DirectoryInfo dir in new DirectoryInfo(directory).GetDirectories())
                    {
                        if (dir.Name.StartsWith("rclone-v") && dir.Name.EndsWith("-windows-amd64"))
                        {
                            Directory.Move(dir.FullName, directory + @"\rClone");
                        }
                    }

                    File.Delete(directory + @"\rclone-current-windows-amd64.zip");

                    Hide();
                    Program.mainUI = new MainUI(rClone);

                    Program.CenterToScreen(Program.mainUI);

                    Program.mainUI.ShowDialog();
                    Close();
                };

                client.DownloadProgressChanged += (s, e) =>
                {
                    label1.Text = $"Downloading rClone {e.ProgressPercentage}%";
                };

                client.DownloadFileAsync(new Uri("https://downloads.rclone.org/rclone-current-windows-amd64.zip"), "rclone-current-windows-amd64.zip");
            }
        }
    }
}
