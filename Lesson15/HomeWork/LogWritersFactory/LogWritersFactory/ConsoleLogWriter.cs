using System;


namespace LogWritersFactory
{
    public class ConsoleLogWriter : AbstractLogWriter, ILogWriter
    {
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
