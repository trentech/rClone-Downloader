using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Linq;

namespace rClone_GUI
{
    public partial class MainUI : Form
    {
        private List<string> folders = new List<string>();
        private List<string> files = new List<string>();

        private Process downloadProcess = null;
        private Process searchProcess = null;

        private string rclone;
        private bool downloading = false;
        private bool cancel = false;

        public MainUI(string rClone)
        {
            InitializeComponent();

            Screen screen = Screen.FromControl(this);
            Rectangle workingArea = screen.WorkingArea;

            Location = new Point
            {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - Height) / 2)
            };

            rclone = rClone;

            string[] config = System.IO.File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\rclone\rclone.conf");

            foreach (string line in config)
            {
                if(line.StartsWith("[") && line.EndsWith("]"))
                {
                    drivesList.Items.Add(line.Replace("[", "").Replace("]", ""));
                }
            }

            drivesList.SelectedIndex = 0;

            if(drivesList.Items.Count == 0)
            {
                MessageBox.Show("No Drives configured in rClone", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            if (Properties.Settings.Default.Filter != "")
            {
                textBoxFilter.Text = Properties.Settings.Default.Filter;
            }

            if (Properties.Settings.Default.LocalPath == "" || Properties.Settings.Default.LocalPath == ".." || !Directory.Exists(Properties.Settings.Default.LocalPath))
            {
                foreach (var dDrive in DriveInfo.GetDrives())
                {
                    ListViewItem drive = new ListViewItem(dDrive.Name.Trim());

                    drive.SubItems.Add("");
                    drive.SubItems.Add(ConvertSize(dDrive.TotalSize));
                    drive.ImageIndex = 2;

                    listLocalFiles.Items.Add(drive);
                }

                textBoxLocal.Text = "..";
            }
            else
            {
                textBoxLocal.Text = Properties.Settings.Default.LocalPath;
                SearchLocal(textBoxLocal.Text);
            }

            if (Properties.Settings.Default.Overwrite == "" || Properties.Settings.Default.Overwrite == "Prompt")
            {
                radioSkip.Checked = false;
                radioOverwrite.Checked = false;
                radioPrompt.Checked = true;
            }
            else if (Properties.Settings.Default.Overwrite == "Overwrite")
            {
                radioSkip.Checked = false;
                radioOverwrite.Checked = true;
                radioPrompt.Checked = false;
            }
            else if (Properties.Settings.Default.Overwrite == "Skip")
            {
                radioSkip.Checked = true;
                radioOverwrite.Checked = false;
                radioPrompt.Checked = false;
            }
            else if (Properties.Settings.Default.Overwrite == "Prompt")
            {
                radioSkip.Checked = false;
                radioOverwrite.Checked = false;
                radioPrompt.Checked = true;
            }
        }

        private void onButtonSearch(object sender, EventArgs e)
        {
            string source;
            if(textBoxRemote.Text == "")
            {
                source = "/";
            } else
            {
                source = textBoxRemote.Text;
            }

            if (source.Substring(source.Length - 1) == "/")
            {
                source = source.Substring(0, source.Length - 1);
            }

            if (!source.StartsWith("/"))
            {
                source = "/" + source;
            }

            textBoxRemote.Text = source;

            SearchRemote();
        }

        private void onListRemoteDoubleClick(object sender, EventArgs e)
        {
            string item = listRemoteFiles.SelectedItems[0].SubItems[0].Text;

            if (listRemoteFiles.SelectedItems[0].ImageIndex == 1)
            {
                string source = textBoxRemote.Text;

                if (source.EndsWith("/"))
                {
                    textBoxRemote.Text += item;
                }
                else
                {
                    textBoxRemote.Text = textBoxRemote.Text + "/" + item;
                }

                SearchRemote();
            }
            else if (listRemoteFiles.SelectedItems[0].ImageIndex == 3)
            {
                string source = textBoxRemote.Text;

                string[] split = source.TrimStart('/').Split('/');

                if (source != "/")
                {
                    if (split.Length == 1)
                    {
                        textBoxRemote.Text = "/";
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

                        textBoxRemote.Text = parent.Substring(0, parent.Length - 1);
                    }

                    SearchRemote();
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
                textBoxFilter.ForeColor = Color.Gray;
            }
            else
            {
                textBoxFilter.ForeColor = Color.Black;
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
            if (textBoxFilter.Text == "" || textBoxFilter.Text == "Filter")
            {
                textBoxFilter.Text = "Filter";
            }
        }

        private void onListRemoteKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.A | Keys.Control))
            {
                listRemoteFiles.BeginUpdate();

                for (int i = 0; i < listRemoteFiles.Items.Count; i++)
                {
                    foreach (ListViewItem item in listRemoteFiles.Items)
                    {
                        if (item.ImageIndex != 3)
                        {
                            item.Selected = true;
                        }
                    }
                }
                e.SuppressKeyPress = true;
                listRemoteFiles.EndUpdate();
            }
        }

        private void onOverwriteClick(object sender, EventArgs e)
        {
            radioOverwrite.Checked = true;
            radioPrompt.Checked = !radioOverwrite.Checked;
            radioSkip.Checked = !radioOverwrite.Checked;
        }

        private void onSkipClicked(object sender, EventArgs e)
        {
            radioSkip.Checked = true;
            radioOverwrite.Checked = !radioSkip.Checked;
            radioPrompt.Checked = !radioSkip.Checked;
        }

        private void onPromptClick(object sender, EventArgs e)
        {
            radioPrompt.Checked = true;
            radioSkip.Checked = !radioPrompt.Checked;
            radioOverwrite.Checked = !radioPrompt.Checked;
        }

        private void onListLocalDragDrop(object sender, DragEventArgs e)
        {
            if(rCloneInternal)
            {
                rCloneInternal = false;
                return;
            }

            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
            {
                var items = (List<ListViewItem>)e.Data.GetData(typeof(List<ListViewItem>));

                string source = textBoxRemote.Text;

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
                        destination = textBoxLocal.Text;
                    }
                    else
                    {
                        destination = textBoxLocal.Text + listLocalFiles.SelectedItems[0].SubItems[0].Text;
                    }

                    string operation = (fileName + " → " + destination + @"\" + file.SubItems[0].Text).Replace(@"\\", @"\");

                    if (listQueue.FindItemWithText(operation) == null)
                    {
                        ListViewItem item = new ListViewItem((fileName + " → " + destination + @"\" + file.SubItems[0].Text).Replace(@"\\", @"\"));
                        item.SubItems.Add("Queued");
                        item.SubItems.Add("");
                        item.SubItems.Add("");
                        item.SubItems.Add("");

                        listQueue.Items.Add(item);
                    }
                }

                DownloadFiles();
            }
        }

        bool Localinternal = false;
        private void onListLocalDrag(object sender, ItemDragEventArgs e)
        {
            Localinternal = true;
            List<ListViewItem> items = new List<ListViewItem>();

            foreach (ListViewItem item in listRemoteFiles.SelectedItems)
            {
                if (item.ImageIndex == 1 || item.ImageIndex == 3)
                {
                    continue;
                }

                items.Add(item);
            }

            listRemoteFiles.DoDragDrop(items, DragDropEffects.Copy);

            Localinternal = false;
        }

        private void onListLocalDragOver(object sender, DragEventArgs e)
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
        private void onListRemoteDragDrop(object sender, DragEventArgs e)
        {
            if(Localinternal)
            {
                Localinternal = false;
                return;
            }

            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
            {
                var items = (List<ListViewItem>)e.Data.GetData(typeof(List<ListViewItem>));

                string source = textBoxRemote.Text;

                foreach (ListViewItem file in items)
                {
                    string fileName = textBoxLocal.Text + @"\" + file.SubItems[0].Text;

                    string destination;
                    if (listRemoteFiles.SelectedItems.Count == 0)
                    {
                        destination = drivesList.SelectedItem.ToString() + ":" + textBoxRemote.Text;
                    }
                    else
                    {
                        destination = drivesList.SelectedItem.ToString() + ":" + textBoxRemote.Text + listRemoteFiles.SelectedItems[0].SubItems[0].Text;
                    }

                    string operation = (fileName + " → " + destination + "/" + file.SubItems[0].Text).Replace("//", "/").Replace(@"\\", @"\");

                    if (listQueue.FindItemWithText(operation) == null)
                    {
                        ListViewItem item = new ListViewItem(operation);
                        item.SubItems.Add("Queued");
                        item.SubItems.Add("");
                        item.SubItems.Add("");
                        item.SubItems.Add("");
                        item.SubItems.Add(file.SubItems[1].Text);
                        item.SubItems.Add(file.SubItems[2].Text);

                        listQueue.Items.Add(item);
                    }
                }

                DownloadFiles();
            }
        }

        bool rCloneInternal = false;
        private void onListRemoteDrag(object sender, ItemDragEventArgs e)
        {
            rCloneInternal = true;
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

            rCloneInternal = false;
        }

        private void onListRemoteDragOver(object sender, DragEventArgs e)
        {
            listRemoteFiles.Select();

            listRemoteFiles.SelectedItems.Clear();

            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
            {
                e.Effect = e.AllowedEffect;
            }

            Point localPoint = listRemoteFiles.PointToClient(Cursor.Position);
            ListViewItem item = listRemoteFiles.GetItemAt(localPoint.X, localPoint.Y);

            if (item != null)
            {
                item.Selected = true;
            }
        }

        private void onListRemoteRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuRemote.Show(Cursor.Position);
            }
        }

        private void onListLocalRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuLocal.Show(Cursor.Position);
            }
        }

        private void onListLocalContextMenuClick(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Refresh")
            {
                SearchLocal(textBoxLocal.Text);
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
                        DirectoryInfo directory = new DirectoryInfo(textBoxLocal.Text + @"\" + item.SubItems[0].Text);

                        if(directory.Exists)
                        {
                            directory.Delete();
                        } else
                        {
                            FileInfo file = new FileInfo(textBoxLocal.Text + @"\" + item.SubItems[0].Text);

                            if (file.Exists)
                            {
                                file.Delete();
                            }
                        }
                    }

                    SearchLocal(textBoxLocal.Text);
                }
            }
            else if (e.ClickedItem.Text == "New Folder")
            {
                NameDialog dialog = new NameDialog();

                DialogResult result = dialog.ShowDialog();

                if(result == DialogResult.OK)
                {
                    string name = dialog.getName();

                    new DirectoryInfo(textBoxLocal.Text + @"\" + name).Create();

                    SearchLocal(textBoxLocal.Text);
                }
            }
        }

        private void onListRemoteContextMenuClick(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Refresh")
            {
                SearchRemote();
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
                    foreach (ListViewItem item in listRemoteFiles.SelectedItems)
                    {
                        // ADD LOGIC
                    }
                }
            }
            else if (e.ClickedItem.Text == "New Folder")
            {
                NameDialog dialog = new NameDialog();

                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // ADD LOGIC
                }
            }
        }

        private void onListQueueRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuQueue.Show(Cursor.Position);
            }
        }

        private void onListQueueContextMenuClick(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Remove")
            {
                foreach (ListViewItem file in listQueue.SelectedItems)
                {
                    string status = file.SubItems[1].Text;

                    if (status.StartsWith("Queued") || status.StartsWith("Complete") || status.StartsWith("Error:"))
                    {
                        listQueue.Items.Remove(file);
                    }
                }
            }
            else if (e.ClickedItem.Text == "Clear")
            {
                foreach (ListViewItem item in listQueue.Items)
                {
                    string status = item.SubItems[1].Text;

                    if (status.StartsWith("Queued") || status.StartsWith("Complete") || status.StartsWith("Error:"))
                    {
                        listQueue.Items.Remove(item);
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
            string source = textBoxRemote.Text;
            string drive = drivesList.SelectedItem.ToString();

            folders.Clear();
            files.Clear();

            textBoxRemote.Text = source;

            string error = null;

            await Task.Run(() =>
            {
                string args = "lsf --format stp --separator \"|\" \"" + drive + ":" + source + "\"";

                if (textBoxFilter.Text != "" && textBoxFilter.Text != "Filter")
                {
                    args = args + " " + textBoxFilter.Text;
                }

                searchProcess = new Process
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

                searchProcess.Start();

                while (!searchProcess.StandardOutput.EndOfStream)
                {
                    string line = searchProcess.StandardOutput.ReadLine();

                    if (line.Substring((line.Length - 1)) == "/")
                    {
                        folders.Add(line.Substring(0, (line.Length - 1)));
                    }
                    else
                    {
                        files.Add(line);
                    }
                }

                error = searchProcess.StandardError.ReadToEnd();

                searchProcess.Close();
                searchProcess = null;
            });

            return error;
        }

        private async void SearchRemote()
        {
            Write("Searching...");

            drivesList.Enabled = false;
            textBoxFilter.Enabled = false;
            buttonSearch.Enabled = false;

            listRemoteFiles.Items.Clear();

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

                listRemoteFiles.Items.Add(back);

                double total = 0;
                foreach (string line in folders)
                {
                    string[] split = line.Split('|');
                    string date = split[1];
                    DateTime dateTime = DateTime.ParseExact(date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    
                    ListViewItem item = new ListViewItem(split[2]);
                    item.SubItems.Add(dateTime.ToString("MM/dd/yyyy hh:mm tt"));
                    item.ImageIndex = 1;

                    listRemoteFiles.Items.Add(item);
                }
                foreach (string line in files)
                {
                    string[] split = line.Split('|');
                    string date = split[1];
                    DateTime dateTime = DateTime.ParseExact(date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    double sizeDouble = Int64.Parse(split[0]);
                    string size = ConvertSize(sizeDouble);

                    ListViewItem item = new ListViewItem(split[2]);
                    item.SubItems.Add(dateTime.ToString("MM/dd/yyyy hh:mm tt"));
                    item.SubItems.Add(size);
                    item.ImageIndex = 0;

                    listRemoteFiles.Items.Add(item);

                    total = total+ sizeDouble;
                }

                Write("Folders: " + folders.Count + "    Files: " + listRemoteFiles.Items.Count + "    Total: " + ConvertSize(total));
            }

            drivesList.Enabled = true;
            textBoxFilter.Enabled = true;
            buttonSearch.Enabled = true;

            listRemoteFiles.Focus();
            listRemoteFiles.Items[1].Selected = true;
        }

        private void SearchLocal(string selectedDirectory)
        {
            listLocalFiles.Items.Clear();

            string[] split = textBoxLocal.Text.Split('\\');

            if (selectedDirectory == ".." && split.Length == 2 && split[1] == "")
            {
                foreach (var dDrive in DriveInfo.GetDrives())
                {
                    ListViewItem drive1 = new ListViewItem(dDrive.Name.Trim());

                    drive1.SubItems.Add("");
                    drive1.SubItems.Add(ConvertSize(dDrive.TotalSize));
                    drive1.ImageIndex = 2;

                    listLocalFiles.Items.Add(drive1);
                }

                textBoxLocal.Text = "..";

                return;
            }

            if (selectedDirectory == "..")
            {
                DirectoryInfo parentDirectory = new DirectoryInfo(textBoxLocal.Text).Parent;

                selectedDirectory = parentDirectory.FullName;
            }
            else
            {
                if (textBoxLocal.Text != "..")
                {
                    if (selectedDirectory != textBoxLocal.Text)
                    {
                        selectedDirectory = textBoxLocal.Text + selectedDirectory + @"\";
                    }
                }
            }

            textBoxLocal.Text = selectedDirectory;

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
                item1.SubItems.Add(ConvertSize(fileInfo.Length));
                item1.ImageIndex = 0;

                listLocalFiles.Items.Add(item1);
            }
        }

        private async Task<string> Download(string name, string destination)
        {
            string error = null;

            await Task.Run(() =>
            {
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

                downloadProcess.OutputDataReceived += (Object _sender, DataReceivedEventArgs _args) => ProcessOutput(_sender, _args, name + " → " + destination);            
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

            list.AddRange(listQueue.Items.Cast<ListViewItem>());

            foreach (ListViewItem item in list)
            {
                if (cancel)
                {
                    cancel = false;
                    downloading = false;
                    return;
                }

                string operation = item.SubItems[0].Text;

                ListViewItem test = listQueue.FindItemWithText(operation);

                if (test == null || test.SubItems[1].Text != "Queued")
                {
                    continue;
                }

                string fileName = operation.Replace(" → ", ";").Split(';')[0];
                string destination = operation.Replace(" → ", ";").Split(';')[1];

                if(!Directory.Exists(fileName.Substring(0, 3)))
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
                                UpdateListViewItem(operation, "Queued");
                                continue;
                            }
                            else if (result == DialogResult.No)
                            {
                                UpdateListViewItem(operation, "Complete");
                                continue;
                            }
                            else if (result == DialogResult.Yes)
                            {
                                File.Delete(destination);
                            }
                        }
                    }
                }

                UpdateListViewItem(operation, "Initializing");

                string error = await Download(fileName, destination);

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

                    if (Directory.Exists(fileName.Substring(0, 3)))
                    {
                        string[] split = fileName.Split('\\');

                        ListViewItem item1 = new ListViewItem(split[split.Length - 1]);
                        item1.SubItems.Add(item.SubItems[5].Text);
                        item1.SubItems.Add(item.SubItems[6].Text);
                        item1.ImageIndex = 0;

                        listRemoteFiles.Items.Add(item1);
                    } else
                    {
                        SearchLocal(textBoxLocal.Text);
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
            if (this.listQueue.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => {
                    listQueue.FindItemWithText(operation).SubItems[1].Text = status;
                    listQueue.FindItemWithText(operation).SubItems[2].Text = progress;
                    listQueue.FindItemWithText(operation).SubItems[3].Text = speed;
                    listQueue.FindItemWithText(operation).SubItems[4].Text = eta;
                }));
            }
            else
            {
                listQueue.FindItemWithText(operation).SubItems[1].Text = status;
                listQueue.FindItemWithText(operation).SubItems[2].Text = progress;
                listQueue.FindItemWithText(operation).SubItems[3].Text = speed;
                listQueue.FindItemWithText(operation).SubItems[4].Text = eta;
            }
        }

        private void UpdateListViewItem(string operation, string status)
        {
            if (this.listQueue.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => {
                    listQueue.FindItemWithText(operation).SubItems[1].Text = status;
                    listQueue.FindItemWithText(operation).SubItems[2].Text = "";
                    listQueue.FindItemWithText(operation).SubItems[3].Text = "";
                    listQueue.FindItemWithText(operation).SubItems[4].Text = "";
                }));
            }
            else
            {
                listQueue.FindItemWithText(operation).SubItems[1].Text = status;
                listQueue.FindItemWithText(operation).SubItems[2].Text = "";
                listQueue.FindItemWithText(operation).SubItems[3].Text = "";
                listQueue.FindItemWithText(operation).SubItems[4].Text = "";
            }
        }
        private void onListQueueColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex == 5 || e.ColumnIndex == 6)
            {
                e.Cancel = true;
                e.NewWidth = 0;
            }
        }

        private void onClosing(object sender, FormClosingEventArgs e)
        {
            if (searchProcess != null)
            {
                searchProcess.Close();
            }
            if (downloadProcess != null)
            {
                downloadProcess.Close();
            }

            if(textBoxFilter.Text != "Filter" && textBoxFilter.Text != "")
            {
                Properties.Settings.Default.Filter = textBoxFilter.Text;
            }

            Properties.Settings.Default.LocalPath = textBoxLocal.Text;

            if(radioOverwrite.Checked)
            {
                Properties.Settings.Default.Overwrite = "Overwrite";
            } else if(radioPrompt.Checked)
            {
                Properties.Settings.Default.Overwrite = "Prompt";
            } else
            {
                Properties.Settings.Default.Overwrite = "Skip";
            }

            Properties.Settings.Default.Save();
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

        private string ConvertSize(double sizeDouble)
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
    }
}
