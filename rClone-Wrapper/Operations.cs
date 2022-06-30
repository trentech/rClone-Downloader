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
    private Process PurgeProcess { get; set; }

    public Operations(string client)
    {
        Client = client;
    }

    public async Task<string> List(Output output, string path, string filter)
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

            ListProcess.OutputDataReceived += (Object _sender, DataReceivedEventArgs _args) => output.ListOutput(_sender, _args);
            ListProcess.Start();
            ListProcess.BeginOutputReadLine();
            ListProcess.WaitForExit();

            error = ListProcess.StandardError.ReadToEnd();

            ListProcess.Close();
            ListProcess = null;
        });

        return error;
    }

    public async Task<string> Copy(Output output, string name, string destination, bool isDirectory)
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

            if(isDirectory)
            {
                CopyProcess.OutputDataReceived += (Object _sender, DataReceivedEventArgs _args) => output.CopyDirectoryOutput(_sender, _args, name, destination);
            } else
            {
                CopyProcess.OutputDataReceived += (Object _sender, DataReceivedEventArgs _args) => output.CopyFileOutput(_sender, _args, name, destination);
            }
            
            CopyProcess.Start();
            CopyProcess.BeginOutputReadLine();
            CopyProcess.WaitForExit();

            error = CopyProcess.StandardError.ReadToEnd();

            CopyProcess.Close();
            CopyProcess = null;
        });

        return error;
    }

    public async Task<string> Sync(Output output, string name, string destination)
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

            SyncProcess.OutputDataReceived += (Object _sender, DataReceivedEventArgs _args) => output.SyncOutput(_sender, _args, name, destination);
            SyncProcess.Start();
            SyncProcess.BeginOutputReadLine();
            SyncProcess.WaitForExit();

            error = SyncProcess.StandardError.ReadToEnd();

            SyncProcess.Close();
            SyncProcess = null;
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
                    Arguments = "deletefile \"" + name + "\" --progress",
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

    public async Task<string> Purge(Output output, string name)
    {
        string error = "";

        await Task.Run(() =>
        {
            PurgeProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Client,
                    Arguments = "Purge \"" + name + "\" --progress",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            PurgeProcess.OutputDataReceived += (Object _sender, DataReceivedEventArgs _args) => output.PurgeOutput(_sender, _args, name);
            PurgeProcess.Start();
            PurgeProcess.BeginOutputReadLine();
            PurgeProcess.WaitForExit();

            error = PurgeProcess.StandardError.ReadToEnd();

            PurgeProcess.Close();
            PurgeProcess = null;
        });

        return error;
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
}
