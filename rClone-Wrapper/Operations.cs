using rClone_Wrapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

public class Operations
{
    public string Client { get; set; }

    private Process SyncProcess { get; set; }
    private Process ListProcess { get; set; }
    private Process CopyProcess { get; set; }
    private Process DeleteProcess { get; set; }
    private Process MkDirProcess { get; set; }
    private Process PurgeProcess { get; set; }

    public Operations(string client)
    {
        Client = client;
    }

    public async Task<string> List(string path, string filter)
    {
        string error = "";

        List<string> folders = new List<string>();
        List<string> files = new List<string>();

        await Task.Run(() =>
        {
            string args = "lsf --format stp --separator \"|\" \"" + path + "\"";

            if(filter != null)
            {
                args = args + " " + filter;
            }

            ListProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Client,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            ListProcess.OutputDataReceived += (Object _sender, DataReceivedEventArgs _args) => ListOutput(_sender, _args);
            ListProcess.Start();
            ListProcess.BeginOutputReadLine();
            ListProcess.WaitForExit();

            error = ListProcess.StandardError.ReadToEnd();

            ListProcess.Close();
            ListProcess = null;
        });

        return error;
    }


    public async Task<string> Copy(string name, string destination, bool isDirectory)
    {
        string error = "";

        await Task.Run(() =>
        {
            CopyProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Client,
                    Arguments = "copyto \"" + name + "\" \"" + destination + "\" --progress",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            CopyProcess.OutputDataReceived += (Object _sender, DataReceivedEventArgs _args) => CopyOutput(_sender, _args, name, destination, isDirectory);
            CopyProcess.Start();
            CopyProcess.BeginOutputReadLine();
            CopyProcess.WaitForExit();

            error = CopyProcess.StandardError.ReadToEnd();

            CopyProcess.Close();
            CopyProcess = null;
        });

        return error;
    }


    public async Task<string> Sync(string name, string destination)
    {
        string error = "";

        await Task.Run(() =>
        {
            SyncProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Client,
                    Arguments = "sync \"" + name + "\" \"" + destination + "\" --progress",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            SyncProcess.OutputDataReceived += (Object _sender, DataReceivedEventArgs _args) => SyncOutput(_sender, _args, name, destination);
            SyncProcess.Start();
            SyncProcess.BeginOutputReadLine();
            SyncProcess.WaitForExit();

            error = SyncProcess.StandardError.ReadToEnd();

            SyncProcess.Close();
            SyncProcess = null;
        });

        return error;
    }


    public async Task<string> MkDir(string name)
    {
        string error = "";

        await Task.Run(() =>
        {
            MkDirProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Client,
                    Arguments = "mkdir \"" + name + "\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            MkDirProcess.Start();
            MkDirProcess.BeginOutputReadLine();
            MkDirProcess.WaitForExit();

            error = MkDirProcess.StandardError.ReadToEnd();

            MkDirProcess.Close();
            MkDirProcess = null;
        });

        return error;
    }

    public async Task<string> DeleteFile(string name)
    {
        string error = "";

        await Task.Run(() =>
        {
            DeleteProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Client,
                    Arguments = "deletefile \"" + name + "\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            DeleteProcess.Start();
            DeleteProcess.BeginOutputReadLine();
            DeleteProcess.WaitForExit();

            error = DeleteProcess.StandardError.ReadToEnd();

            DeleteProcess.Close();
            DeleteProcess = null;
        });

        return error;
    }

    public async Task<string> Purge(string name)
    {
        string error = "";

        await Task.Run(() =>
        {
            PurgeProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Client,
                    Arguments = "purge \"" + name + "\" --progress",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            PurgeProcess.OutputDataReceived += (Object _sender, DataReceivedEventArgs _args) => PurgeOutput(_sender, _args, name);
            PurgeProcess.Start();
            PurgeProcess.BeginOutputReadLine();
            PurgeProcess.WaitForExit();

            error = PurgeProcess.StandardError.ReadToEnd();

            PurgeProcess.Close();
            PurgeProcess = null;
        });

        return error;
    }

    private void SyncOutput(object sender, DataReceivedEventArgs args, string name, string destination)
    {
        if (!String.IsNullOrEmpty(args.Data))
        {
            if (args.Data.Contains("-Transferred:"))
            {
                string stats = args.Data.Substring(args.Data.IndexOf("-Transferred:")).Replace("-Transferred:", "").TrimStart();
                string[] split = stats.Split(',');

                OnSync(this, new SyncArgs(name, destination, split[0].TrimStart(), split[2].TrimStart(), split[3].Replace(" ETA ", "")));
            }
        }
    }

    private void PurgeOutput(object sender, DataReceivedEventArgs args, string name)
    {
        if (!String.IsNullOrEmpty(args.Data))
        {
            string lineData = args.Data;

            Console.WriteLine(lineData);

            // I NEVER FINISHED THIS APPARENTLY
        }
    }

    private void ListOutput(object sender, DataReceivedEventArgs args)
    {
        if (!String.IsNullOrEmpty(args.Data))
        {
            string lineData = args.Data;

            if (lineData.Substring((lineData.Length - 1)) == "/")
            {
                OnList(this, new ListArgs(lineData.Substring(0, (lineData.Length - 1)), true));
            }
            else
            {
                OnList(this, new ListArgs(lineData, true));
            }
        }
    }

    private void CopyOutput(object sender, DataReceivedEventArgs args, string name, string destination, bool isDirectory)
    {
        if (!String.IsNullOrEmpty(args.Data))
        {
            if (args.Data.Contains("transferringTransferred:"))
            {
                string stats = args.Data.Split(':')[2].TrimStart();
                string[] split = stats.Split(',');

                OnCopy(this, new CopyArgs(name, destination, split[0].TrimStart(), split[2].TrimStart(), split[3].Replace(" ETA ", ""), isDirectory));
            }
        }
    }

    public void Kill()
    {
        if (ListProcess != null)
        {
            ListProcess.Close();
        }
        if (CopyProcess != null)
        {
            CopyProcess.Close();
        }
        if (DeleteProcess != null)
        {
            DeleteProcess.Close();
        }
        if (PurgeProcess != null)
        {
            PurgeProcess.Close();
        }
        if (SyncProcess != null)
        {
            SyncProcess.Close();
        }
    }

    public event ListHandler OnList;
    public delegate void ListHandler(object source, ListArgs e);
    public class ListArgs : EventArgs
    {
        public string Name { get; }
        public bool isDirectory { get; }

        public ListArgs(string name, bool isDirectory)
        {
            Name = name;
            this.isDirectory = isDirectory;
        }
    }

    public event CopyHandler OnCopy;
    public delegate void CopyHandler(object source, CopyArgs e);
    public class CopyArgs : EventArgs
    {
        public string Name { get; }
        public string Destination { get; }
        public string Progress { get; }
        public string Speed { get; }
        public string ETA { get; }

        public bool isDirectory { get; }

        public CopyArgs(string name, string destination, string progress, string speed, string eta, bool isDirectory)
        {
            Name = name;
            Destination = destination;
            Progress = progress;
            Speed = speed;
            ETA = eta;
            this.isDirectory = isDirectory;
        }
    }

    public event SyncHandler OnSync;
    public delegate void SyncHandler(object source, SyncArgs e);
    public class SyncArgs : EventArgs
    {
        public string Name { get; }
        public string Destination { get; }
        public string Progress { get; }
        public string Speed { get; }
        public string ETA { get; }

        public SyncArgs(string name, string destination, string progress, string speed, string eta)
        {
            Name = name;
            Destination = destination;
            Progress = progress;
            Speed = speed;
            ETA = eta;
        }
    }
}
