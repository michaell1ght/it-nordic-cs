using System;
using System.Collections.Generic;
using System.Text;

namespace LogWriters
{
    static class LogWriterFactory
    {
        public static ILogWriter GetLogWriter(LogWriterType writetType, List<ILogWriter> LogWriterList=null)
        {
            switch (writetType)
            {
                case LogWriterType.ConsoleLogWriter:
                    ILogWriter consoleLogWriterInstence = new ConsoleLogWriter();
                    return consoleLogWriterInstence;
                case LogWriterType.FileLogWriter:
                    ILogWriter fileLogWriterInstence = new FileLogWriter();
                    return fileLogWriterInstence;
                case LogWriterType.MultipleLogWriter:
                    ILogWriter multipleLogWriterInstance = new MultipleLogWriter(LogWriterList);
                    return multipleLogWriterInstance;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
