using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.IO;
using System.Globalization;

namespace rClone_Downloader
{
    public partial class MainUI : System.Windows.Forms.Form
    {
        private List<string> folders = new List<string>();
        private List<string> files = new List<string>();
        private Process downloadProcess = null;
        private Process listProcess = null;
        private string rclone = null;
        private static BlockingCollection<string> queue = new BlockingCollection<string>();
        private bool downloading = false;

        public MainUI()
        {
            InitializeComponent();

            rclone = Properties.Settings.Default.Path;

            string[] config = System.IO.File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\rclone\rclone.conf");

            foreach (string line in config)
            {
                if(line.StartsWith("[") && line.EndsWith("]"))
                {
                    drivesList.Items.Add(line.Replace("[", "").Replace("]", ""));
                }
            }

            if(drivesList.Items.Count == 0)
            {
                MessageBox.Show("No Drives configured in rClone", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            drivesList.SelectedIndex = 0;

            if (Properties.Settings.Default.Source != "" && Properties.Settings.Default.Source != null)
            {
                textBoxSource.Text = Properties.Settings.Default.Source;
            }

            if (Properties.Settings.Default.Filter != "")
            {
                textBoxFilter.Text = Properties.Settings.Default.Filter;
            }

            if (Properties.Settings.Default.Destination != "")
            {
                textBoxDest.Text = Properties.Settings.Default.Destination;
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

        private void onButtonGo(object sender, EventArgs e)
        {
            if(textBoxSource.Text == "Source" || textBoxSource.Text == "")
            {
                Search("/");
            } else
            {
                Search(textBoxSource.Text);
            }
        }

        private void onButtonBack(object sender, EventArgs e)
        {
            string[] split = textBoxSource.Text.TrimStart('/').Split('/');

            if(textBoxSource.Text != "/")
            {
                if(split.Length == 1)
                {
                    Search("/");
                } else
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

                    Search(parent.Substring(0, parent.Length - 1));
                }
            }
        }
        
        private void onButtonDownload(object sender, EventArgs e)
        {
            if (textBoxDest.Text == "" || textBoxDest.Text == "Destination")
            {
                onButtonBrowse(sender, e);

                return;
            }

            Properties.Settings.Default.Destination = textBoxDest.Text;
            Properties.Settings.Default.Save();

            DownloadFiles(textBoxDest.Text);
        }

        private void onButtonBrowse(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();

            DialogResult dialogResult = openFolderDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                string directory = openFolderDialog.SelectedPath;

                textBoxDest.Text = directory;

                Properties.Settings.Default.Destination = textBoxDest.Text;
                Properties.Settings.Default.Save();

                if (listFiles.CheckedItems.Count != 0)
                {
                    buttonDownload.Enabled = true;
                }
            }
        }

        private void onButtonAdd(object sender, EventArgs e)
        {
            string source = textBoxSource.Text;
            if (!textBoxSource.Text.StartsWith("/"))
            {
                source = "/" + textBoxSource.Text;
            }

            foreach (ListViewItem file in listFiles.SelectedItems)
            {
                string fileName = drivesList.SelectedItem.ToString() + ":" + source + "/" + file.SubItems[0].Text;

                if (listDownloads.FindItemWithText(fileName) == null)
                {
                    ListViewItem item = new ListViewItem(fileName);
                    item.SubItems.Add("Queued");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("");

                    listDownloads.Items.Add(item);

                    queue.Add(fileName);
                }
            }

            if (!downloading)
            {
                if (textBoxDest.Text == "" || textBoxDest.Text == "Destination")
                {
                    onButtonBrowse(sender, e);

                    return;
                }

                Properties.Settings.Default.Destination = textBoxDest.Text;
                Properties.Settings.Default.Save();

                DownloadFiles(textBoxDest.Text);
            }
        }

        private void onButtonRemove(object sender, EventArgs e)
        {
            foreach (ListViewItem file in listDownloads.SelectedItems)
            {
                string fileName = file.SubItems[0].Text;
                string status = file.SubItems[1].Text;

                if (status.StartsWith("Queued") || status.StartsWith("Complete") || status.StartsWith("Error:") || status.StartsWith("Skipped"))
                {
                    listDownloads.Items.Remove(file);
                }
            }
        }

        private void onListClick(object sender, EventArgs e)
        {
            string item = listFiles.SelectedItems[0].SubItems[0].Text;

            if(listFiles.SelectedItems[0].ImageIndex == 1)
            {
                if (textBoxSource.Text.EndsWith("/"))
                {
                    Search(textBoxSource.Text + item);
                }
                else
                {
                    Search(textBoxSource.Text + "/" + item);
                }
            }
        }

        private void onListChange(object sender, ItemCheckedEventArgs e)
        {
            if (listFiles.CheckedItems.Count == 0)
            {
                buttonDownload.Enabled = false;
            }
            else
            {
                if (textBoxDest.Text != "" && textBoxDest.Text != "Destination")
                {
                    buttonDownload.Enabled = true;
                }
            }
        }

        private void onTextDestChange(object sender, EventArgs e)
        {
            if (textBoxDest.Text == "Destination" || textBoxDest.Text == "")
            {
                textBoxDest.ForeColor = System.Drawing.Color.Gray;
                buttonDownload.Enabled = false;
            }
            else
            {
                textBoxDest.ForeColor = System.Drawing.Color.Black;

                if (textBoxSource.Text != "Source" && textBoxSource.Text != "")
                {
                    buttonDownload.Enabled = true;
                }
            }
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

        private void onTextSourceChange(object sender, EventArgs e)
        {
            if (textBoxSource.Text == "Source" || textBoxSource.Text == "")
            {
                textBoxSource.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                textBoxSource.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void onTextSourceEnter(object sender, EventArgs e)
        {
            if (textBoxSource.Text == "Source")
            {
                textBoxSource.Text = "";
            }
        }

        private void onTextSourceLeave(object sender, EventArgs e)
        {
            if (textBoxSource.Text == "")
            {
                textBoxSource.Text = "Source";
            }
        }

        private void onTextSourceKey(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                onButtonGo(sender, e);
            }
        }

        private void onTextFilterKey(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                onButtonGo(sender, e);
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

        private void onTextDestEnter(object sender, EventArgs e)
        {
            if (textBoxDest.Text == "Destination")
            {
                textBoxDest.Text = "";
            }
        }

        private void onTextDestLeave(object sender, EventArgs e)
        {
            if (textBoxDest.Text == "")
            {
                textBoxDest.Text = "Destination";
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

        private void onDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
            {
                var items = (List<ListViewItem>)e.Data.GetData(typeof(List<ListViewItem>));

                string source = textBoxSource.Text;
                if (!textBoxSource.Text.StartsWith("/"))
                {
                    source = "/" + textBoxSource.Text;
                }

                foreach (ListViewItem file in items)
                {
                    string fileName = drivesList.SelectedItem.ToString() + ":" + source + "/" + file.SubItems[0].Text;

                    if (listDownloads.FindItemWithText(fileName) == null)
                    {
                        ListViewItem item = new ListViewItem(fileName);
                        item.SubItems.Add("Queued");
                        item.SubItems.Add("");
                        item.SubItems.Add("");
                        item.SubItems.Add("");

                        listDownloads.Items.Add(item);

                        queue.Add(fileName);
                    }
                }

                if(!downloading)
                {
                    if (textBoxDest.Text == "" || textBoxDest.Text == "Destination")
                    {
                        onButtonBrowse(sender, e);

                        return;
                    }

                    Properties.Settings.Default.Destination = textBoxDest.Text;
                    Properties.Settings.Default.Save();

                    DownloadFiles(textBoxDest.Text);
                }
            }
        }

        private void onDrag(object sender, ItemDragEventArgs e)
        {
            List<ListViewItem> items = new List<ListViewItem>();

            //items.Add((ListViewItem)e.Item);

            foreach (ListViewItem item in listFiles.SelectedItems)
            {
                if (item.ImageIndex == 1)
                {
                    return;
                }

                items.Add(item);
            }

            listFiles.DoDragDrop(items, DragDropEffects.Copy);
        }

        private void onDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private bool cancel = false;
        private void onCancelClick(object sender, EventArgs e)
        {
            cancel = !cancel;
            downloading = false;
        }

        private void onClearClick(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listDownloads.Items)
            {
                string fileName = item.SubItems[0].Text;
                string status = item.SubItems[1].Text;

                if (status.StartsWith("Queued") || status.StartsWith("Complete") || status.StartsWith("Error:") || status.StartsWith("Cancelled") || status.StartsWith("Skipped"))
                {
                    if (item.SubItems[1].Text.StartsWith("Queued"))
                    {
                        queue.TryTake(out fileName);
                    }

                    listDownloads.Items.Remove(item);
                }
            }
        }

        private async Task<string> UpdateList(string drive, string path)
        {
            folders.Clear();
            files.Clear();

            string error = null;

            await Task.Run(() =>
            {
                string args = "lsf --format stp --separator \"|\" \"" + drive + ":" + path + "\"";

                if(textBoxFilter.Text != "" && textBoxFilter.Text != "Filter")
                {
                    args = args + " " + textBoxFilter.Text;
                }

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

        private async void Search(string path)
        {
            Write("Searching...");

            drivesList.Enabled = false;
            textBoxSource.Enabled = false;
            textBoxFilter.Enabled = false;
            buttonBack.Enabled = false;
            buttonGo.Enabled = false;

            string drive = drivesList.SelectedItem.ToString();

            if (path.Substring(path.Length - 1) == "/")
            {
                path = path.Substring(0, path.Length - 1);
            }

            if(!path.StartsWith("/"))
            {
                path = "/" + path;
            }

            listFiles.Items.Clear();

            textBoxSource.Text = path;

            Properties.Settings.Default.Source = textBoxSource.Text;

            if(textBoxFilter.Text == "" && textBoxFilter.Text == "Filter")
            {
                Properties.Settings.Default.Filter = "";
            } else
            {
                Properties.Settings.Default.Filter = textBoxFilter.Text;
            }

            Properties.Settings.Default.Save();

            string error = await UpdateList(drive, path);

            if (error != "")
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
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
                    string size;

                    if(sizeDouble < 1024)
                    {
                        size = sizeDouble + " B";
                    } else if(sizeDouble < 1048576)
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
                    else
                    {
                        size = sizeDouble.ToString();
                    }

                    ListViewItem item = new ListViewItem(split[2]);
                    item.SubItems.Add(dateTime.ToString("MM/dd/yyyy hh:mm tt"));
                    item.SubItems.Add(size);
                    item.ImageIndex = 0;

                    listFiles.Items.Add(item);
                }

                Write("Folders: " + folders.Count + "    Files: " + listFiles.Items.Count);
            }

            drivesList.Enabled = true;
            textBoxSource.Enabled = true;
            textBoxFilter.Enabled = true;
            buttonBack.Enabled = true;
            buttonGo.Enabled = true;
        }

        private async Task<string> Download(string name, string destPath)
        {
            string error = null;

            await Task.Run(() =>
            {
                string[] split = name.Split('/');

                string dest = destPath + @"\" + split[split.Length - 1];

                if(File.Exists(dest))
                {
                    if (radioOverwrite.Checked)
                    {
                        File.Delete(dest);
                    } else if(radioSkip.Checked)
                    {
                        return;
                    } else if(radioPrompt.Checked)
                    {
                        DialogResult result = MessageBox.Show(dest + "\r\n File Already Exists. Overwrite?", "File Exists", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

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
                            File.Delete(dest);
                        }
                    }
                }

                downloadProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = rclone,
                        Arguments = "copyto \"" + name + "\" \"" + dest + "\" -P -q",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    }
                };

                downloadProcess.OutputDataReceived += (Object _sender, DataReceivedEventArgs _args) => ProcessOutput(_sender, _args, name);
                downloadProcess.Start();
                downloadProcess.BeginOutputReadLine();

                downloadProcess.WaitForExit();

                if(cancel)
                {
                    error = "Cancel";
                    File.Delete(dest);
                } else
                {
                    error = downloadProcess.StandardError.ReadToEnd();
                    downloadProcess.Close();
                }

                downloadProcess = null;
            });

            return error;
        }

        private async void DownloadFiles(string destPath)
        {
            if(downloading)
            {
                return;
            }

            downloading = true;

            while (queue.Count != 0)
            {
                if (cancel)
                {
                    cancel = false;
                    downloading = false;
                    return;
                }

                string fileName = queue.Take();

                if(listDownloads.FindItemWithText(fileName) == null)
                {
                    continue;
                }

                UpdateListViewItem(fileName, "Initializing", "", "", "");

                string error = await Download(fileName, destPath);

                if (error != "" && error != null)
                {
                    if (error == "Cancel")
                    {
                        listDownloads.FindItemWithText(fileName).Remove();

                        ListViewItem item = new ListViewItem(fileName);
                        item.SubItems.Add("Queued");
                        item.SubItems.Add("");
                        item.SubItems.Add("");
                        item.SubItems.Add("");
                        listDownloads.Items.Add(item);

                     // UpdateListViewItem(fileName, "Queued", "", "", "");

                        queue.Add(fileName);
                    }
                    else if (error == "Skipped")
                    {
                        UpdateListViewItem(fileName, "Skipped" + error);
                    }
                    else
                    {
                        UpdateListViewItem(fileName, "Error: " + error);
                    }
                }
                else
                {
                    UpdateListViewItem(fileName, "Complete");
                }
            }

            downloading = false;
        }

        private void ProcessOutput(object sendingProcess, DataReceivedEventArgs outLine, string file)
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
                    } else
                    {
                        string[] split = outLine.Data.Replace("*", "").TrimStart().Split(':');
                        string stats = split[2].TrimStart();
                        string[] split2 = stats.Split(',');

                        UpdateListViewItem(file, "Downloading", split2[0].TrimStart(), split2[2].TrimStart(), split2[3].Replace(" ETA ", ""));
                    }
                }
            }
        }

        private void UpdateListViewItem(string name, string status, string progress, string speed, string eta)
        {

            if (this.listDownloads.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => {
                    listDownloads.FindItemWithText(name).SubItems[1].Text = status;
                    listDownloads.FindItemWithText(name).SubItems[2].Text = progress;
                    listDownloads.FindItemWithText(name).SubItems[3].Text = speed;
                    listDownloads.FindItemWithText(name).SubItems[4].Text = eta;
                }));
            }
            else
            {
                listDownloads.FindItemWithText(name).SubItems[1].Text = status;
                listDownloads.FindItemWithText(name).SubItems[2].Text = progress;
                listDownloads.FindItemWithText(name).SubItems[3].Text = speed;
                listDownloads.FindItemWithText(name).SubItems[4].Text = eta;
            }
        }

        private void UpdateListViewItem(string name, string status)
        {
            if (this.listDownloads.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => {
                    listDownloads.FindItemWithText(name).SubItems[1].Text = status;
                    listDownloads.FindItemWithText(name).SubItems[2].Text = "";
                    listDownloads.FindItemWithText(name).SubItems[3].Text = "";
                    listDownloads.FindItemWithText(name).SubItems[4].Text = "";
                }));
            }
            else
            {
                listDownloads.FindItemWithText(name).SubItems[1].Text = status;
                listDownloads.FindItemWithText(name).SubItems[2].Text = "";
                listDownloads.FindItemWithText(name).SubItems[3].Text = "";
                listDownloads.FindItemWithText(name).SubItems[4].Text = "";
            }
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

        private void onClosing(object sender, FormClosingEventArgs e)
        {
            if(listProcess != null)
            {
                listProcess.Close();
            }
            if (downloadProcess != null)
            {
                downloadProcess.Close();
            }
        }
    }
}
