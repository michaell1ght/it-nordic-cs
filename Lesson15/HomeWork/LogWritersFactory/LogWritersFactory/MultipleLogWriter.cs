using System;
using System.Collections.Generic;
using System.Text;

namespace LogWriters
{
    class MultipleLogWriter : AbstractLogWriter, ILogWriter
    {
        List<ILogWriter> LogWriterList;
        public MultipleLogWriter(List <ILogWriter> LogWriterList)
            {
            if (LogWriterList.Count==0)
            {
                throw new ArgumentNullException();
            }

            this.LogWriterList = LogWriterList;

        }
        public override void LogInfo(string message)
        {
            foreach(var WriterItem in LogWriterList)
            {
                WriterItem.LogInfo(message);
            }
        }

        public override void LogError(string message)
        {
            foreach (var WriterItem in LogWriterList)
            {
                WriterItem.LogError(message);
            }
        }

        public override void LogWarning(string message)
        {
            foreach (var WriterItem in LogWriterList)
            {
                WriterItem.LogWarning(message);
            }
        }
    }
}
