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

            ILogWriter consoleLogWriter = SingletoneConsoleLogWriter.GetConsoleLogWriterInstance();
            consoleLogWriter.LogWarning(warningText + stringSeparator + nameof(consoleLogWriter));
            consoleLogWriter.LogError(errorText + stringSeparator + nameof(consoleLogWriter));
            consoleLogWriter.LogInfo(infoText + stringSeparator + nameof(consoleLogWriter));

            ILogWriter fileLogWriter = SingletoneFileLogWriter.GetFileLogWriterInstance();
            fileLogWriter.LogWarning(warningText + stringSeparator + nameof(fileLogWriter));
            fileLogWriter.LogError(errorText + stringSeparator + nameof(fileLogWriter));
            fileLogWriter.LogInfo(infoText + stringSeparator + nameof(fileLogWriter));

            ILogWriter oneMoreConsoleWriter = SingletoneConsoleLogWriter.GetConsoleLogWriterInstance();
            ILogWriter oneMoreFileWriter = SingletoneFileLogWriter.GetFileLogWriterInstance();

            List<ILogWriter> LogWriterList = new List<ILogWriter>
            {
                oneMoreConsoleWriter,
                oneMoreFileWriter
            };

            ILogWriter multipleLogWriter = SingletoneMultipleLogWriter.GetMultipleLogWriterInstance();
            SingletoneMultipleLogWriter.GetMultipleLogWriterInstance().LogWriterList = LogWriterList;
            multipleLogWriter.LogWarning(warningText + stringSeparator + nameof(multipleLogWriter));
            multipleLogWriter.LogError(errorText + stringSeparator + nameof(multipleLogWriter)) ;
            multipleLogWriter.LogInfo(infoText + stringSeparator + nameof(multipleLogWriter));
            System.Console.ReadKey();
        }
    }
}
