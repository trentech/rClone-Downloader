using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rClone_GUI
{
    internal class Operation
    {
        private string Id { get; }
        private string Name { get; }
        private string LocalPath { get; }
        private string RemotePath { get; }
        Direction Direction { get; }
        public Operation(string fileName, string remotePath, string localPath, Direction direction)        {
            if(Direction == Direction.RIGHT)
            {
                Id = remotePath + "/" + fileName + " → " + localPath + @"\" + fileName;
            } else
            {
                Id = localPath + "/" + fileName + " → " + remotePath + @"\" + fileName;
            }

            Name = fileName;
            RemotePath = remotePath;
            LocalPath = localPath;
            Direction = direction;
        }
    }

    public enum Direction { LEFT, RIGHT}
}
