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

            ILogWriter consoleLogWriter = new ConsoleLogWriter();
            consoleLogWriter.LogWarning(warningText + " " + consoleLogWriter.GetType());
            consoleLogWriter.LogError(errorText + " " + consoleLogWriter.GetType());
            consoleLogWriter.LogInfo(infoText + " " + consoleLogWriter.GetType());

            ILogWriter fileLogWriter = new FileLogWriter();
            fileLogWriter.LogWarning(warningText + " " + fileLogWriter.GetType());
            fileLogWriter.LogError(errorText + " " + fileLogWriter.GetType());
            fileLogWriter.LogInfo(infoText + " " + fileLogWriter.GetType());

            ILogWriter writer3 = new ConsoleLogWriter();
            ILogWriter writer4 = new FileLogWriter();

            List<ILogWriter> LogWriterList = new List<ILogWriter>
            {
                writer3,
                writer4
            };

            ILogWriter multipleLogWriter = new MultipleLogWriter(LogWriterList);
            multipleLogWriter.LogWarning(warningText + " " + multipleLogWriter.GetType());
            multipleLogWriter.LogError(errorText + " " + multipleLogWriter.GetType()) ;
            multipleLogWriter.LogInfo(infoText + " " + multipleLogWriter.GetType());
        }
    }
}
