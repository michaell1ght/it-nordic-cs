using System;
using System.Collections.Generic;
using System.Text;

namespace LogWritersFactory
{
    class MultipleLogWriter : AbstractLogWriter, ILogWriter
    {
        private List<ILogWriter> LogWriterList { get; set; }

        public MultipleLogWriter(List<ILogWriter> logWriterList)
        {
            LogWriterList = logWriterList;
        }

        public override void LogInfo(string message)
        {
            foreach (var WriterItem in LogWriterList)
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
