using System;

public class Event
{
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

    public delegate void PurgeHandler(object source, PurgeArgs e);
    public class PurgeArgs : EventArgs
    {
        public string Name { get; }

        public PurgeArgs(string name)
        {
            Name = name;
        }
    }
}

