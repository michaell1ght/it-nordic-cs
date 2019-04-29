using System;
using System.Collections.Generic;
using System.Text;

namespace LogWriters
{
    class SingletoneMultipleLogWriter : AbstractLogWriter, ILogWriter
    {
        private List<ILogWriter> LogWriterList { get; set; }

        private static SingletoneMultipleLogWriter multipleLogWriterInstance;

        private SingletoneMultipleLogWriter(List<ILogWriter> logWriterList)
        { }

        public static SingletoneMultipleLogWriter GetMultipleLogWriterInstance(List<ILogWriter> LogWriterList)
        {
            if (LogWriterList.Count == 0)
            {
                throw new ArgumentNullException();
            }
            if (multipleLogWriterInstance == null)
            {
                multipleLogWriterInstance = new SingletoneMultipleLogWriter(LogWriterList);
                multipleLogWriterInstance.LogWriterList= LogWriterList;
            }
            return multipleLogWriterInstance;
        }

        public override void LogInfo(string message)
        {
            foreach(var WriterItem in multipleLogWriterInstance.LogWriterList)
            {
                WriterItem.LogInfo(message);
            }
        }

        public override void LogError(string message)
        {
            foreach (var WriterItem in multipleLogWriterInstance.LogWriterList)
            {
                WriterItem.LogError(message);
            }
        }

        public override void LogWarning(string message)
        {
            foreach (var WriterItem in multipleLogWriterInstance.LogWriterList)
            {
                WriterItem.LogWarning(message);
            }
        }
    }
}
