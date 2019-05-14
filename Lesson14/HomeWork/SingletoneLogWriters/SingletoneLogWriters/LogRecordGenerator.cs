using LogWriters;
using System;

namespace SingletoneLogWriters
{
    public static class LogRecordGenerator
    {
        private const string separator = "    ";
        public static string GenerateLogRecord(string message, LogRecordType logRecordType)
        {
            string logRecord = WriteDateTimeAsString() + separator + logRecordType + separator + message;
            return logRecord;
        }
        private static string WriteDateTimeAsString()
        {
            return DateTimeOffset.Now.ToString();
        }
    }
}
