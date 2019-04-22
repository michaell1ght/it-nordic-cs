using System;

namespace LogWriters
{
    public abstract class AbstractLogWriter : ILogWriter
    {
        protected DateTimeOffset EventDateTime;
        protected string _logRecord;
        protected const string separator = "    ";

        //        DateTimeOffset EventTs;
        //        YYYY-MM-DDTHH:MM:SS+0000 <tab> MessageType<tab> Message
        //, где MessageType может быть “Info”, “Warning” или “Error”.
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
