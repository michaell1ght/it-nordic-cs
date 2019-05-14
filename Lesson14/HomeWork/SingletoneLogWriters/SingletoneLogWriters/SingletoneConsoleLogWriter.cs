using SingletoneLogWriters;
using System;

namespace LogWriters
{
    public class SingletoneConsoleLogWriter : AbstractLogWriter, ILogWriter
    {
        private static SingletoneConsoleLogWriter consoleLogWriterInstance;

        private SingletoneConsoleLogWriter()
        { }

        public static SingletoneConsoleLogWriter GetConsoleLogWriterInstance()
        {
            if(consoleLogWriterInstance==null)
            {
                consoleLogWriterInstance = new SingletoneConsoleLogWriter();
            }
            return consoleLogWriterInstance;
        }

        public override void LogInfo(string message)
        {
            LogRecord(message, LogRecordType.Info);
        }

        public override void LogError(string message)
        {
            LogRecord(message, LogRecordType.Error);
        }

        public override void LogWarning(string message)
        {
            LogRecord(message, LogRecordType.Warning);
        }

        protected override void LogRecord(string message, LogRecordType logRecordType)
        {
            Console.WriteLine(LogRecordGenerator.GenerateLogRecord(message, logRecordType));
        }
    }
}
