using System;
using System.Collections.Generic;
using System.Text;

namespace LogWriters
{
    interface ILogWriter
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogWarning(string message);
    }
}
