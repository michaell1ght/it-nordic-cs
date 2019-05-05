using System;
using System.Collections.Generic;

namespace LogWritersFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            string warningText = "warning by";
            string errorText= "error by";
            string infoText ="info by";
            string stringSeparator = " ";

            LogWriterFactory factory = LogWriterFactory.GetLogWriterFactoryInstance();

            ILogWriter consoleLogWriter = factory.GetLogWriter<ConsoleLogWriter>(null);
            consoleLogWriter.LogWarning(warningText + stringSeparator + consoleLogWriter.GetType());
            consoleLogWriter.LogError(errorText + stringSeparator + consoleLogWriter.GetType());
            consoleLogWriter.LogInfo(infoText + stringSeparator + consoleLogWriter.GetType());

            ILogWriter fileLogWriter = factory.GetLogWriter<FileLogWriter>($"log.txt");
            fileLogWriter.LogWarning(warningText + stringSeparator + fileLogWriter.GetType());
            fileLogWriter.LogError(errorText + stringSeparator + fileLogWriter.GetType());
            fileLogWriter.LogInfo(infoText + stringSeparator + fileLogWriter.GetType());

            ILogWriter oneMoreConsoleWriter = new ConsoleLogWriter();
            ILogWriter oneMoreFileWriter = new FileLogWriter($"log.txt");

            List<ILogWriter> LogWriterList = new List<ILogWriter>
            {
                oneMoreConsoleWriter,
                oneMoreFileWriter
            };

            ILogWriter multipleLogWriter = factory.GetLogWriter<MultipleLogWriter>(LogWriterList);
            multipleLogWriter.LogWarning(warningText + stringSeparator + multipleLogWriter.GetType());
            multipleLogWriter.LogError(errorText + stringSeparator + multipleLogWriter.GetType());
            multipleLogWriter.LogInfo(infoText + stringSeparator + multipleLogWriter.GetType());
        }
    }
}
