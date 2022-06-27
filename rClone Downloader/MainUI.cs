using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Linq;

namespace rClone_Downloader
{
    public partial class MainUI : System.Windows.Forms.Form
    {
        private List<string> folders = new List<string>();
        private List<string> files = new List<string>();
        private Process downloadProcess = null;
        private Process listProcess = null;
        private string rclone = null;
        private bool downloading = false;
        private bool cancel = false;

        public MainUI(string rClone)
        {
            InitializeComponent();
            this.rclone = rClone;
            string[] config = System.IO.File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\rclone\rclone.conf");

            foreach (string line in config)
            {
                if(line.StartsWith("[") && line.EndsWith("]"))
                {
                    drivesList.Items.Add(line.Replace("[", "").Replace("]", ""));
                }
            }

            string drive = Properties.Settings.Default.Drive;
            if (drive == "" || !drivesList.Items.Contains(drive))
            {
                drivesList.SelectedIndex = 0;
            } else
            {
                drivesList.SelectedItem = drive;
            }

            if(drivesList.Items.Count == 0)
            {
                MessageBox.Show("No Drives configured in rClone", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            if (Properties.Settings.Default.Source != "" && Properties.Settings.Default.Source != null)
            {
                textBoxSource.Text = Properties.Settings.Default.Source;
            }

            if (Properties.Settings.Default.Filter != "")
            {
                textBoxFilter.Text = Properties.Settings.Default.Filter;
            }

            if (Properties.Settings.Default.Destination == "" || Properties.Settings.Default.Destination == ".." || !Directory.Exists(Properties.Settings.Default.Destination))
            {
                foreach (var dDrive in DriveInfo.GetDrives())
                {
                    ListViewItem drive1 = new ListViewItem(dDrive.Name.Trim());

                    drive1.SubItems.Add("");
                    drive1.SubItems.Add(getSize(dDrive.TotalSize));
                    drive1.ImageIndex = 2;

                    listLocalFiles.Items.Add(drive1);
                }

                textBoxDest.Text = "..";
            } else
            {
                textBoxDest.Text = Properties.Settings.Default.Destination;
                SearchLocal(textBoxDest.Text);
            }

            if (Properties.Settings.Default.Action == "" || Properties.Settings.Default.Action == "Prompt")
            {
                radioSkip.Checked = false;
                radioOverwrite.Checked = false;
                radioPrompt.Checked = true;
            } 
            else if(Properties.Settings.Default.Action == "Overwrite")
            {
                radioSkip.Checked = false;
                radioOverwrite.Checked = true;
                radioPrompt.Checked = false;
            }
            else if (Properties.Settings.Default.Action == "Skip")
            {
                radioSkip.Checked = true;
                radioOverwrite.Checked = false;
                radioPrompt.Checked = false;
            }
            else if (Properties.Settings.Default.Action == "Prompt")
            {
                radioSkip.Checked = false;
                radioOverwrite.Checked = false;
                radioPrompt.Checked = true;
            }
        }

        private void onButtonSearch(object sender, EventArgs e)
        {
            string source;
            if(textBoxSource.Text == "Source" || textBoxSource.Text == "")
            {
                source = "/";
            } else
            {
                source = textBoxSource.Text;
            }

            if (source.Substring(source.Length - 1) == "/")
            {
                source = source.Substring(0, source.Length - 1);
            }

            if (!source.StartsWith("/"))
            {
                source = "/" + source;
            }

            textBoxSource.Text = source;

            Properties.Settings.Default.Source = textBoxSource.Text;
            Properties.Settings.Default.Drive = drivesList.SelectedItem.ToString();
            Properties.Settings.Default.Save();

            SearchRClone();
        }

        private void onListrCloneDoubleClick(object sender, EventArgs e)
        {
            string item = listFiles.SelectedItems[0].SubItems[0].Text;

            if (listFiles.SelectedItems[0].ImageIndex == 1)
            {
                string source = Properties.Settings.Default.Source;

                if (source.EndsWith("/"))
                {
                    Properties.Settings.Default.Source = textBoxSource.Text + item;
                }
                else
                {
                    Properties.Settings.Default.Source = textBoxSource.Text + "/" + item;
                }

                Properties.Settings.Default.Save();

                SearchRClone();
            }
            else if (listFiles.SelectedItems[0].ImageIndex == 3)
            {
                string source = Properties.Settings.Default.Source;

                string[] split = source.TrimStart('/').Split('/');

                if (source != "/")
                {
                    if (split.Length == 1)
                    {
                        Properties.Settings.Default.Source = "/";
                    }
                    else
                    {
                        string parent = null;

                        for (int i = 0; i < split.Length; i++)
                        {
                            if ((i + 1) == split.Length)
                            {
                                break;
                            }
                            else
                            {
                                if (parent == null)
                                {
                                    parent = split[i] + "/";
                                }
                                else
                                {
                                    parent = parent + split[i] + "/";
                                }
                            }
                        }

                        Properties.Settings.Default.Source = parent.Substring(0, parent.Length - 1);
                    }

                    Properties.Settings.Default.Save();

                    SearchRClone();
                }
            }
        }

        private void onListLocalDoubleClick(object sender, EventArgs e)
        {
            ListViewItem selected = listLocalFiles.SelectedItems[0];

            string selectedDirectory = selected.SubItems[0].Text;

            if (selectedDirectory != ".." && selected.ImageIndex == 0)
            {
                return;
            }

            SearchLocal(selectedDirectory);
        }

        private void onTextFilterChange(object sender, EventArgs e)
        {
            if (textBoxFilter.Text == "Filter" || textBoxFilter.Text == "")
            {
                textBoxFilter.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                textBoxFilter.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void onTextFilterKey(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                onButtonSearch(sender, e);
            }
        }

        private void onTextFilterEnter(object sender, EventArgs e)
        {
            if (textBoxFilter.Text == "Filter")
            {
                textBoxFilter.Text = "";
            }
        }

        private void onTextFilterLeave(object sender, EventArgs e)
        {
            if (textBoxFilter.Text == "")
            {
                textBoxFilter.Text = "Filter";
            }
        }

        private void onOverwriteClick(object sender, EventArgs e)
        {
            radioOverwrite.Checked = true;
            radioPrompt.Checked = !radioOverwrite.Checked;
            radioSkip.Checked = !radioOverwrite.Checked;

            Properties.Settings.Default.Action = "Overwrite";
            Properties.Settings.Default.Save();
        }

        private void onSkipClicked(object sender, EventArgs e)
        {
            radioSkip.Checked = true;
            radioOverwrite.Checked = !radioSkip.Checked;
            radioPrompt.Checked = !radioSkip.Checked;

            Properties.Settings.Default.Action = "Skip";
            Properties.Settings.Default.Save();
        }

        private void onPromptClick(object sender, EventArgs e)
        {
            radioPrompt.Checked = true;
            radioSkip.Checked = !radioPrompt.Checked;
            radioOverwrite.Checked = !radioPrompt.Checked;

            Properties.Settings.Default.Action = "Prompt";
            Properties.Settings.Default.Save();
        }

        private void onDragDropLocal(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
            {
                var items = (List<ListViewItem>)e.Data.GetData(typeof(List<ListViewItem>));

                string source = Properties.Settings.Default.Source;

                foreach (ListViewItem file in items)
                {
                    string fileName;
                    if (source == "/")
                    {
                        fileName = drivesList.SelectedItem.ToString() + ":" + source + file.SubItems[0].Text;
                    } else
                    {
                        fileName = drivesList.SelectedItem.ToString() + ":" + source + "/" + file.SubItems[0].Text;
                    }

                    string destination;
                    if (listLocalFiles.SelectedItems.Count == 0)
                    {
                        destination = Properties.Settings.Default.Destination;
                    }
                    else
                    {
                        destination = Properties.Settings.Default.Destination + listLocalFiles.SelectedItems[0].SubItems[0].Text;
                    }

                    string operation = (fileName + "→" + destination + @"\" + file.SubItems[0].Text).Replace(@"\\", @"\");

                    if (listDownloads.FindItemWithText(operation) == null)
                    {
                        ListViewItem item = new ListViewItem((fileName + "→" + destination + @"\" + file.SubItems[0].Text).Replace(@"\\", @"\"));
                        item.SubItems.Add("Queued");
                        item.SubItems.Add("");
                        item.SubItems.Add("");
                        item.SubItems.Add("");

                        listDownloads.Items.Add(item);
                    }
                }

                DownloadFiles();
            }
        }

        private void onDragLocal(object sender, ItemDragEventArgs e)
        {
            List<ListViewItem> items = new List<ListViewItem>();

            foreach (ListViewItem item in listFiles.SelectedItems)
            {
                if (item.ImageIndex == 1 || item.ImageIndex == 3)
                {
                    continue;
                }

                items.Add(item);
            }

            listFiles.DoDragDrop(items, DragDropEffects.Copy);
        }

        private void onDragOverLocal(object sender, DragEventArgs e)
        {
            listLocalFiles.Select();

            listLocalFiles.SelectedItems.Clear();

            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
            {
                e.Effect = e.AllowedEffect;
            }

            Point localPoint = listLocalFiles.PointToClient(Cursor.Position);
            ListViewItem item = listLocalFiles.GetItemAt(localPoint.X, localPoint.Y);

            if(item != null)
            {                           
                item.Selected = true;
            }
        }
        private void onDragDroprClone(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
            {
                var items = (List<ListViewItem>)e.Data.GetData(typeof(List<ListViewItem>));

                string source = Properties.Settings.Default.Source;

                foreach (ListViewItem file in items)
                {
                    string fileName;
                    if (source == "/")
                    {
                        fileName = drivesList.SelectedItem.ToString() + ":" + source + file.SubItems[0].Text;
                    }
                    else
                    {
                        fileName = drivesList.SelectedItem.ToString() + ":" + source + "/" + file.SubItems[0].Text;
                    }

                    string destination;
                    if (listLocalFiles.SelectedItems.Count == 0)
                    {
                        destination = Properties.Settings.Default.Destination;
                    }
                    else
                    {
                        destination = Properties.Settings.Default.Destination + listLocalFiles.SelectedItems[0].SubItems[0].Text;
                    }

                    string operation = (fileName + "←" + destination + @"\" + file.SubItems[0].Text).Replace(@"\\", @"\");

                    if (listDownloads.FindItemWithText(operation) == null)
                    {
                        ListViewItem item = new ListViewItem(operation);
                        item.SubItems.Add("Queued");
                        item.SubItems.Add("");
                        item.SubItems.Add("");
                        item.SubItems.Add("");
                        item.SubItems.Add(file.SubItems[1].Text);
                        item.SubItems.Add(file.SubItems[2].Text);

                        listDownloads.Items.Add(item);
                    }
                }

                DownloadFiles();
            }
        }

        private void onDragrClone(object sender, ItemDragEventArgs e)
        {
            List<ListViewItem> items = new List<ListViewItem>();

            foreach (ListViewItem item in listLocalFiles.SelectedItems)
            {
                if (item.ImageIndex == 1 || item.ImageIndex == 3)
                {
                    continue;
                }

                items.Add(item);
            }

            listLocalFiles.DoDragDrop(items, DragDropEffects.Copy);
        }

        private void onDragOverrClone(object sender, DragEventArgs e)
        {
            listFiles.Select();

            listFiles.SelectedItems.Clear();

            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
            {
                e.Effect = e.AllowedEffect;
            }

            Point localPoint = listFiles.PointToClient(Cursor.Position);
            ListViewItem item = listFiles.GetItemAt(localPoint.X, localPoint.Y);

            if (item != null)
            {
                item.Selected = true;
            }
        }

        private void onLocalRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuLocal.Show(Cursor.Position);
            }
        }

        private void onContextMenuLocalClick(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Refresh")
            {
                SearchLocal(textBoxDest.Text);
            }
            else if (e.ClickedItem.Text == "Delete")
            {
                contextMenuLocal.Close();
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete Files/Folders", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    foreach (ListViewItem item in listLocalFiles.SelectedItems)
                    {
                        DirectoryInfo directory = new DirectoryInfo(textBoxDest.Text + @"\" + item.SubItems[0].Text);

                        if(directory.Exists)
                        {
                            directory.Delete();
                        } else
                        {
                            FileInfo file = new FileInfo(textBoxDest.Text + @"\" + item.SubItems[0].Text);

                            if (file.Exists)
                            {
                                file.Delete();
                            }
                        }
                    }

                    SearchLocal(textBoxDest.Text);
                }
            }
            else if (e.ClickedItem.Text == "New Folder")
            {
                NameDialog dialog = new NameDialog();
                Program.CenterToScreen(dialog);
                DialogResult result = dialog.ShowDialog();

                if(result == DialogResult.OK)
                {
                    string name = dialog.getName();

                    new DirectoryInfo(textBoxDest.Text + @"\" + name).Create();

                    SearchLocal(textBoxDest.Text);
                }
            }
        }

        private void onDownloadsRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuDownloads.Show(Cursor.Position);
            }
        }

        private void onContextMenuDownloadsClick(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Remove")
            {
                foreach (ListViewItem file in listDownloads.SelectedItems)
                {
                    string status = file.SubItems[1].Text;

                    if (status.StartsWith("Queued") || status.StartsWith("Complete") || status.StartsWith("Error:"))
                    {
                        listDownloads.Items.Remove(file);
                    }
                }
            }
            else if (e.ClickedItem.Text == "Clear")
            {
                foreach (ListViewItem item in listDownloads.Items)
                {
                    string status = item.SubItems[1].Text;

                    if (status.StartsWith("Queued") || status.StartsWith("Complete") || status.StartsWith("Error:"))
                    {
                        listDownloads.Items.Remove(item);
                    }
                }
            }
            else if (e.ClickedItem.Text == "Cancel Downloads")
            {
                cancel = !cancel;
                downloading = false;
            }
            else if (e.ClickedItem.Text == "Start Downloads")
            {
                DownloadFiles();
            }
        }

        private async Task<string> UpdateList()
        {
            string source = Properties.Settings.Default.Source;
            string drive = Properties.Settings.Default.Drive;

            folders.Clear();
            files.Clear();

            textBoxSource.Text = source;

            string error = null;

            await Task.Run(() =>
            {
                string args = "lsf --format stp --separator \"|\" \"" + drive + ":" + source + "\"";

                if (textBoxFilter.Text == "" || textBoxFilter.Text == "Filter")
                {
                    Properties.Settings.Default.Filter = "";
                }
                else
                {
                    args = args + " " + textBoxFilter.Text;
                    Properties.Settings.Default.Filter = textBoxFilter.Text;
                }

                Properties.Settings.Default.Save();

                listProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = rclone,
                        Arguments = args,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    }
                };

                listProcess.Start();

                while (!listProcess.StandardOutput.EndOfStream)
                {
                    string line = listProcess.StandardOutput.ReadLine();

                    if (line.Substring((line.Length - 1)) == "/")
                    {
                        folders.Add(line.Substring(0, (line.Length - 1)));
                    }
                    else
                    {
                        files.Add(line);
                    }
                }

                error = listProcess.StandardError.ReadToEnd();

                listProcess.Close();
                listProcess = null;
            });

            return error;
        }

        private async void SearchRClone()
        {
            Write("Searching...");

            drivesList.Enabled = false;
            textBoxFilter.Enabled = false;
            buttonGo.Enabled = false;

            listFiles.Items.Clear();

            string error = await UpdateList();

            if (error != "")
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ListViewItem back = new ListViewItem("..");

                back.SubItems.Add("");
                back.SubItems.Add("");
                back.ImageIndex = 3;

                listFiles.Items.Add(back);

                double total = 0;
                foreach (string line in folders)
                {
                    string[] split = line.Split('|');
                    string date = split[1];
                    DateTime dateTime = DateTime.ParseExact(date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    
                    ListViewItem item = new ListViewItem(split[2]);
                    item.SubItems.Add(dateTime.ToString("MM/dd/yyyy hh:mm tt"));
                    item.ImageIndex = 1;

                    listFiles.Items.Add(item);
                }
                foreach (string line in files)
                {
                    string[] split = line.Split('|');
                    string date = split[1];
                    DateTime dateTime = DateTime.ParseExact(date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    double sizeDouble = Int64.Parse(split[0]);
                    string size = getSize(sizeDouble);

                    ListViewItem item = new ListViewItem(split[2]);
                    item.SubItems.Add(dateTime.ToString("MM/dd/yyyy hh:mm tt"));
                    item.SubItems.Add(size);
                    item.ImageIndex = 0;

                    listFiles.Items.Add(item);

                    total = total+ sizeDouble;
                }

                Write("Folders: " + folders.Count + "    Files: " + listFiles.Items.Count + "    Total: " + getSize(total));
            }

            drivesList.Enabled = true;
            textBoxFilter.Enabled = true;
            buttonGo.Enabled = true;

            listFiles.Focus();
            listFiles.Items[1].Selected = true;
        }

        private void SearchLocal(string selectedDirectory)
        {
            listLocalFiles.Items.Clear();

            string[] split = textBoxDest.Text.Split('\\');

            if (selectedDirectory == ".." && split.Length == 2 && split[1] == "")
            {
                foreach (var dDrive in DriveInfo.GetDrives())
                {
                    ListViewItem drive1 = new ListViewItem(dDrive.Name.Trim());

                    drive1.SubItems.Add("");
                    drive1.SubItems.Add(getSize(dDrive.TotalSize));
                    drive1.ImageIndex = 2;

                    listLocalFiles.Items.Add(drive1);
                }

                textBoxDest.Text = "..";

                Properties.Settings.Default.Destination = textBoxDest.Text;
                Properties.Settings.Default.Save();

                return;
            }

            if (selectedDirectory == "..")
            {
                DirectoryInfo parentDirectory = new DirectoryInfo(textBoxDest.Text).Parent;

                selectedDirectory = parentDirectory.FullName;
            }
            else
            {
                if (textBoxDest.Text != "..")
                {
                    if (selectedDirectory != textBoxDest.Text)
                    {
                        selectedDirectory = textBoxDest.Text + selectedDirectory + @"\";
                    }
                }
            }

            textBoxDest.Text = selectedDirectory;

            Properties.Settings.Default.Destination = textBoxDest.Text;
            Properties.Settings.Default.Save();

            ListViewItem back = new ListViewItem("..");

            back.SubItems.Add("");
            back.SubItems.Add("");
            back.ImageIndex = 3;

            listLocalFiles.Items.Add(back);

            foreach (string file in Directory.GetDirectories(selectedDirectory))
            {
                DirectoryInfo directory = new DirectoryInfo(file);

                if (directory.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    continue;
                }

                ListViewItem item1 = new ListViewItem(directory.Name);
                item1.SubItems.Add(directory.LastWriteTime.ToString("MM/dd/yyyy hh:mm tt"));
                item1.SubItems.Add("");
                item1.ImageIndex = 1;

                listLocalFiles.Items.Add(item1);
            }

            foreach (string file in Directory.GetFiles(selectedDirectory))
            {

                FileInfo fileInfo = new FileInfo(file);

                if (fileInfo.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    continue;
                }

                ListViewItem item1 = new ListViewItem(fileInfo.Name);
                item1.SubItems.Add(fileInfo.LastWriteTime.ToString("MM/dd/yyyy hh:mm tt"));
                item1.SubItems.Add(getSize(fileInfo.Length));
                item1.ImageIndex = 0;

                listLocalFiles.Items.Add(item1);
            }
        }

        private async Task<string> Download(string name, string destination, string direction)
        {
            string error = null;

            await Task.Run(() =>
            {
                if(direction == "→")
                {
                    if (File.Exists(destination))
                    {
                        if (radioOverwrite.Checked)
                        {
                            File.Delete(destination);
                        }
                        else if (radioSkip.Checked)
                        {
                            return;
                        }
                        else if (radioPrompt.Checked)
                        {
                            DialogResult result = MessageBox.Show(destination + "\r\n File Already Exists. Overwrite?", "File Exists", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                            if (result == DialogResult.Cancel)
                            {
                                cancel = true;
                                error = "Cancel";
                                return;
                            }
                            else if (result == DialogResult.No)
                            {
                                error = "Skipped";
                                return;
                            }
                            else if (result == DialogResult.Yes)
                            {
                                File.Delete(destination);
                            }
                        }
                    }
                }

                downloadProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = rclone,
                        Arguments = "copyto \"" + name + "\" \"" + destination + "\" --progress",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    }
                };

                if(direction == "→")
                {
                    downloadProcess.OutputDataReceived += (Object _sender, DataReceivedEventArgs _args) => ProcessOutput(_sender, _args, name + direction + destination);
                } else
                {
                    downloadProcess.OutputDataReceived += (Object _sender, DataReceivedEventArgs _args) => ProcessOutput(_sender, _args, destination + direction + name);
                }
               
                downloadProcess.Start();
                downloadProcess.BeginOutputReadLine();

                downloadProcess.WaitForExit();

                if(cancel)
                {
                    error = "Cancel";
                    File.Delete(destination);
                } else
                {
                    error = downloadProcess.StandardError.ReadToEnd();
                    downloadProcess.Close();
                }

                downloadProcess = null;
            });

            return error;
        }

        bool run = false;
        private async void DownloadFiles()
        {
            if (downloading)
            {
                run = true;
                return;
            }

            downloading = true;
            run = false;

            List<ListViewItem> list = new List<ListViewItem>();

            list.AddRange(listDownloads.Items.Cast<ListViewItem>());

            foreach (ListViewItem item in list)
            {
                if (cancel)
                {
                    cancel = false;
                    downloading = false;
                    return;
                }

                string operation = item.SubItems[0].Text;

                ListViewItem test = listDownloads.FindItemWithText(operation);

                if (test == null || test.SubItems[1].Text != "Queued")
                {
                    continue;
                }

                string fileName;
                string destination;
                string direction;
                if(operation.Contains("→"))
                {
                    fileName = operation.Split('→')[0];
                    destination = operation.Split('→')[1];
                    direction = "→";
                } else
                {
                    fileName = operation.Split('←')[1];
                    destination = operation.Split('←')[0];
                    direction = "←";
                }

                UpdateListViewItem(operation, "Initializing", "", "", "");

                string error = await Download(fileName, destination, direction);

                if (error != "" && error != null)
                {
                    if (error == "Cancel")
                    {
                        UpdateListViewItem(operation, "Queued");
                    } else
                    {
                        UpdateListViewItem(operation, error);
                    }
                }
                else
                {
                    UpdateListViewItem(operation, "Complete");

                    if (operation.Contains("→"))
                    {
                        SearchLocal(textBoxDest.Text);
                    } else
                    {
                        string[] split = fileName.Split('\\');

                        ListViewItem item1 = new ListViewItem(split[split.Length - 1]);
                        item1.SubItems.Add(item.SubItems[5].Text);
                        item1.SubItems.Add(item.SubItems[6].Text);
                        item1.ImageIndex = 0;

                        listFiles.Items.Add(item1);
                    }    
                }
            }

            downloading = false;

            if (run)
            {
                DownloadFiles();
            }
        }

        private void UpdateListViewItem(string operation, string status, string progress, string speed, string eta)
        {
            if (this.listDownloads.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => {
                    listDownloads.FindItemWithText(operation).SubItems[1].Text = status;
                    listDownloads.FindItemWithText(operation).SubItems[2].Text = progress;
                    listDownloads.FindItemWithText(operation).SubItems[3].Text = speed;
                    listDownloads.FindItemWithText(operation).SubItems[4].Text = eta;
                }));
            }
            else
            {
                listDownloads.FindItemWithText(operation).SubItems[1].Text = status;
                listDownloads.FindItemWithText(operation).SubItems[2].Text = progress;
                listDownloads.FindItemWithText(operation).SubItems[3].Text = speed;
                listDownloads.FindItemWithText(operation).SubItems[4].Text = eta;
            }
        }

        private void UpdateListViewItem(string operation, string status)
        {
            if (this.listDownloads.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => {
                    listDownloads.FindItemWithText(operation).SubItems[1].Text = status;
                    listDownloads.FindItemWithText(operation).SubItems[2].Text = "";
                    listDownloads.FindItemWithText(operation).SubItems[3].Text = "";
                    listDownloads.FindItemWithText(operation).SubItems[4].Text = "";
                }));
            }
            else
            {
                listDownloads.FindItemWithText(operation).SubItems[1].Text = status;
                listDownloads.FindItemWithText(operation).SubItems[2].Text = "";
                listDownloads.FindItemWithText(operation).SubItems[3].Text = "";
                listDownloads.FindItemWithText(operation).SubItems[4].Text = "";
            }
        }

        private void onClosing(object sender, FormClosingEventArgs e)
        {
            if (listProcess != null)
            {
                listProcess.Close();
            }
            if (downloadProcess != null)
            {
                downloadProcess.Close();
            }
        }

        private void ProcessOutput(object sendingProcess, DataReceivedEventArgs outLine, string operation)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                if (outLine.Data.StartsWith(" *"))
                {
                    if (cancel)
                    {
                        Process process = sendingProcess as Process;

                        try
                        {
                            process.Kill();
                        }
                        catch { }
                    }
                    else
                    {
                        string[] split = outLine.Data.Replace("*", "").TrimStart().Split(':');
                        string stats = split[2].TrimStart();
                        string[] split2 = stats.Split(',');

                        UpdateListViewItem(operation, "Downloading", split2[0].TrimStart(), split2[2].TrimStart(), split2[3].Replace(" ETA ", ""));
                    }
                }
            }
        }

        private string getSize(double sizeDouble)
        {
            String size;
            if (sizeDouble < 1024)
            {
                size = sizeDouble + " B";
            }
            else if (sizeDouble < 1048576)
            {
                size = Math.Round(sizeDouble / 1024, 2) + " KB";
            }
            else if (sizeDouble < 1073741824)
            {
                size = Math.Round(sizeDouble / 1048576, 2) + " MB";
            }
            else if (sizeDouble < 1099511627776)
            {
                size = Math.Round(sizeDouble / 1073741824, 2) + " GB";
            }
            else if (sizeDouble < 1125899906842624)
            {
                size = Math.Round(sizeDouble / 1099511627776, 2) + " TB";
            }
            else
            {
                size = sizeDouble.ToString();
            }

            return size;
        }

        private void Write(string text)
        {
            if (this.log.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => log.Text = text));
            }
            else
            {
                log.Text = text;
            }
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == (Keys.A | Keys.Control))
            {
                listFiles.BeginUpdate();

                for (int i = 0; i < listFiles.Items.Count; i++)
                {
                    foreach (ListViewItem item in listFiles.Items)
                    {
                        if(item.ImageIndex != 3)
                        {
                            item.Selected = true;
                        }                       
                    }
                }
                e.SuppressKeyPress = true;
                listFiles.EndUpdate();
            }
        }

        private void onWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if(e.ColumnIndex == 5 || e.ColumnIndex == 6)
            {
                e.Cancel = true;
                e.NewWidth = 0;
            }
        }
    }
}
