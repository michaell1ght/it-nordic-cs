using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LogWriters
{
    class SingletoneFileLogWriter : AbstractLogWriter, ILogWriter
    {
        private string FilePath { get; set; } = @"D:\Logs\";
        private string FileName { get; set; } = "logs.txt";
        private FileManager fileManager;
        private static SingletoneFileLogWriter fileLogWriterInstance;

        private SingletoneFileLogWriter()
        { }

        public static SingletoneFileLogWriter GetFileLogWriterInstance()
        {
            if (fileLogWriterInstance == null)
            {
                fileLogWriterInstance = new SingletoneFileLogWriter();
            }
            return fileLogWriterInstance;
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
