using System;
using System.Collections.Generic;
using System.Text;

namespace LogWritersFactory
{
    public class LogWriterFactory
    {
        private static LogWriterFactory logWriterFactoryInstance;

        private LogWriterFactory()
        { }

        public static LogWriterFactory GetLogWriterFactoryInstance()
        {
            if (logWriterFactoryInstance == null)
            {
                logWriterFactoryInstance = new LogWriterFactory();
            }
            return logWriterFactoryInstance;
        }
        

        public ILogWriter GetLogWriter<T>(object parameters) where T : ILogWriter
        {
            if (typeof(T) == typeof(ConsoleLogWriter))
            {
                return new ConsoleLogWriter();
            }
            else if (typeof(T) == typeof(FileLogWriter))
            {
                if (!(parameters is string))
                {
                    throw new ArgumentOutOfRangeException("parameter filepath is not set");
                }

                return new FileLogWriter((string)parameters);
            }
            else if (typeof(T) == typeof(MultipleLogWriter))
            {
                if (!(parameters is List<ILogWriter>))
                {
                    throw new ArgumentOutOfRangeException("parameter log writers list is not set");
                }

                return new MultipleLogWriter(parameters as List<ILogWriter>);
            }

            return null;
        }
    }
}
