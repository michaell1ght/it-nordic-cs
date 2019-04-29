using System;

namespace LogWriters
{
    public abstract class AbstractLogWriter : ILogWriter
    {
        protected string _logRecord;
        protected const string stringSeparator = "    ";

        public virtual void LogInfo(string message)
        {
            _logRecord = this.WriteDateTimeAsString() + stringSeparator + MessageType.Info + stringSeparator + WriteMessage(message);
        }

        public virtual void LogError(string message)
        {
            _logRecord = this.WriteDateTimeAsString() + stringSeparator + MessageType.Error + stringSeparator + WriteMessage(message);
        }

        public virtual void LogWarning(string message)
        {
            _logRecord = this.WriteDateTimeAsString() + stringSeparator + MessageType.Warning + stringSeparator + WriteMessage(message);
        }

        internal string WriteDateTimeAsString()
        {
            return DateTimeOffset.Now.ToString();
        }
        internal string WriteMessage(string message)
        {
            return message;
        }
    }
}
