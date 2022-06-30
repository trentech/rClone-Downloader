using System.Diagnostics;

namespace rClone_Wrapper
{
    public interface Output
    {
        void SyncOutput(object sendingProcess, DataReceivedEventArgs line, string name, string destination);
        void CopyFileOutput(object sendingProcess, DataReceivedEventArgs line, string name, string destination);
        void CopyDirectoryOutput(object sendingProcess, DataReceivedEventArgs line, string name, string destination);
        void ListOutput(object sendingProcess, DataReceivedEventArgs line);
        void PurgeOutput(object sendingProcess, DataReceivedEventArgs line, string name);
    }
}
