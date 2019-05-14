using SingletoneLogWriters;

namespace LogWriters
{
    class SingletoneFileLogWriter : AbstractLogWriter, ILogWriter
    {
        private string _filePath;
        private string _fileName;
        private FileManager fileManager;
        private static SingletoneFileLogWriter fileLogWriterInstance;

        private SingletoneFileLogWriter(string _filePath, string _fileName)
        {
            this._filePath = _filePath;
            this._fileName = _fileName;
        }

        public static SingletoneFileLogWriter GetFileLogWriterInstance(string _filePath = @"D:\Logs\", string _fileName = "logs.txt")
        {
            if (fileLogWriterInstance == null)
            {
                fileLogWriterInstance = new SingletoneFileLogWriter(_filePath,_fileName);
            }
            return fileLogWriterInstance;
        }

        public override void LogInfo(string message)
        {
            this.LogRecord(message, LogRecordType.Info);
        }

        public override void LogError(string message)
        {
            this.LogRecord(message, LogRecordType.Error);
        }

        public override void LogWarning(string message)
        {
            this.LogRecord(message, LogRecordType.Warning);
        }

        protected override void LogRecord(string message, LogRecordType logRecordType)
        {
            fileManager = new FileManager(LogRecordGenerator.GenerateLogRecord(message, logRecordType), _filePath, _fileName);
            fileManager.UpdateFileInFolder();
        }
    }
}
