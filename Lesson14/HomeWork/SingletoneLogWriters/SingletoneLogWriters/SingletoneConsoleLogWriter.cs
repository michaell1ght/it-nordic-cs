using System;


namespace LogWriters
{
    public class SingletoneConsoleLogWriter : AbstractLogWriter, ILogWriter
    {
        private static SingletoneConsoleLogWriter consoleLogWriterInstance;

        private SingletoneConsoleLogWriter()
        { }

        public static SingletoneConsoleLogWriter GetConsoleLogWriterInstance()
        {
            if(consoleLogWriterInstance==null)
            {
                consoleLogWriterInstance = new SingletoneConsoleLogWriter();
            }
            return consoleLogWriterInstance;
        }

        public override void LogInfo(string message)
        {
            base.LogInfo(message);
            Console.WriteLine(base._logRecord);
        }

        public override void LogError(string message)
        {
            base.LogError(message);
            Console.WriteLine(base._logRecord);
        }

        public override void LogWarning(string message)
        {
            base.LogWarning(message);
            Console.WriteLine(base._logRecord);
        }
    }
}
