using System;

namespace LogWriters
{
    public abstract class AbstractLogWriter : ILogWriter
    {
        protected string _logRecord;
        protected const string separator = "    ";

        public virtual void LogInfo(string message)
        {
            _logRecord = this.writeDateTimeAsString() + separator + MessageType.Info + separator + writeMessage(message);
        }

        public virtual void LogError(string message)
        {
            _logRecord = this.writeDateTimeAsString() + separator + MessageType.Error + separator + writeMessage(message);
        }

        public virtual void LogWarning(string message)
        {
            _logRecord = this.writeDateTimeAsString() + separator + MessageType.Warning + separator + writeMessage(message);
        }

        internal string writeDateTimeAsString()
        {
            return DateTimeOffset.Now.ToString();
        }
        internal string writeMessage(string message)
        {
            return message;
        }
    }
}
