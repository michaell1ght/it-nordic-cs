using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LogWritersFactory
{
    class FileLogWriter : AbstractLogWriter, ILogWriter
    {
        string FilePath = @"D:\Logs\";
        string FileName = $"log_{DateTime.Now}";
        FileManager fileManager;

        public FileLogWriter(string fileName)
        {
            FileName = fileName;
        }

        public override void LogInfo(string message)
        {
            base.LogInfo(message);
            fileManager = new FileManager(base._logRecord, FilePath, FileName);
            fileManager.UpdateFileInFolder();
        }

        public override void LogError(string message)
        {
            base.LogError(message);
            fileManager = new FileManager(base._logRecord, FilePath, FileName);
            fileManager.UpdateFileInFolder();
        }

        public override void LogWarning(string message)
        {
            base.LogWarning(message);
            fileManager = new FileManager(base._logRecord, FilePath, FileName);
            fileManager.UpdateFileInFolder();
        }
    }
}
