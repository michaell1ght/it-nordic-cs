using System;
using System.Collections.Generic;
using System.Text;

namespace LogWriters
{
    class SingletoneMultipleLogWriter : AbstractLogWriter, ILogWriter
    {
        public List<ILogWriter> LogWriterList { get; set; }

        private static SingletoneMultipleLogWriter multipleLogWriterInstance;

        private SingletoneMultipleLogWriter()
        { }

        public static SingletoneMultipleLogWriter GetMultipleLogWriterInstance()
        {
            if (multipleLogWriterInstance == null)
            {
                multipleLogWriterInstance = new SingletoneMultipleLogWriter();
            }
            return multipleLogWriterInstance;
        }
        public override void LogInfo(string message)
        {
            if(LogWriterList==null)
            {
                throw new ArgumentOutOfRangeException("The list of log writers is empty");
            }
            foreach(var WriterItem in LogWriterList)
            {
                WriterItem.LogInfo(message);
            }
        }

        public override void LogError(string message)
        {
            if (LogWriterList == null)
            {
                throw new ArgumentOutOfRangeException("The list of log writers is empty");
            }
            foreach (var WriterItem in LogWriterList)
            {
                WriterItem.LogError(message);
            }
        }

        public override void LogWarning(string message)
        {
            if (LogWriterList == null)
            {
                throw new ArgumentOutOfRangeException("The list of log writers is empty");
            }
            foreach (var WriterItem in LogWriterList)
            {
                WriterItem.LogWarning(message);
            }
        }
    }
}
