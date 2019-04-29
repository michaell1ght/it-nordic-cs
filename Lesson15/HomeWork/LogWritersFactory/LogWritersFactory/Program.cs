using System.Collections.Generic;

namespace LogWriters
{
    class Program
    {
        static void Main(string[] args)
        {
            string warningText = "warning by";
            string errorText= "error by";
            string infoText ="info by";
            string stringSeparator = " ";

            ILogWriter consoleLogWriter = LogWriterFactory.GetLogWriter(LogWriterType.ConsoleLogWriter);
            consoleLogWriter.LogWarning(warningText + stringSeparator + consoleLogWriter.GetType());
            consoleLogWriter.LogError(errorText + stringSeparator + consoleLogWriter.GetType());
            consoleLogWriter.LogInfo(infoText + stringSeparator + consoleLogWriter.GetType());

            ILogWriter fileLogWriter = LogWriterFactory.GetLogWriter(LogWriterType.FileLogWriter);
            fileLogWriter.LogWarning(warningText + stringSeparator + fileLogWriter.GetType());
            fileLogWriter.LogError(errorText + stringSeparator + fileLogWriter.GetType());
            fileLogWriter.LogInfo(infoText + stringSeparator + fileLogWriter.GetType());

            ILogWriter oneMoreConsoleWriter = new ConsoleLogWriter();
            ILogWriter oneMoreFileWriter = new FileLogWriter();

            List<ILogWriter> LogWriterList = new List<ILogWriter>
            {
                oneMoreConsoleWriter,
                oneMoreFileWriter
            };

            ILogWriter multipleLogWriter = LogWriterFactory.GetLogWriter(LogWriterType.MultipleLogWriter, LogWriterList);
            multipleLogWriter.LogWarning(warningText + stringSeparator + multipleLogWriter.GetType());
            multipleLogWriter.LogError(errorText + stringSeparator + multipleLogWriter.GetType());
            multipleLogWriter.LogInfo(infoText + stringSeparator + multipleLogWriter.GetType());
        }
    }
}
