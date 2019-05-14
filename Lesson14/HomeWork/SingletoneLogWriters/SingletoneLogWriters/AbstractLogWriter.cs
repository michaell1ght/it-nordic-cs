using System;

namespace LogWriters
{
    public abstract class AbstractLogWriter : ILogWriter
    {
        protected string _logRecord;

        public virtual void LogInfo(string message)
        {
            LogRecord(message, LogRecordType.Warning);
        }

        public virtual void LogError(string message)
        {
            LogRecord(message, LogRecordType.Error);
        }

        public virtual void LogWarning(string message)
        {
            LogRecord(message, LogRecordType.Warning);
        }

        protected abstract void LogRecord(string message, LogRecordType logRecordType);
    }
}
