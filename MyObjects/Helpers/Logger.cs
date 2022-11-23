using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyObjects.Helpers
{
    /// <summary>
    /// A helper static class to get access the logger
    /// </summary>
    
    public enum LogSeverity 
    { 
        Error, 
        Warning,
        Info 
    };
    public static class Logger
    {
        private static readonly FileLogger _logger = FileLogger.GetInstance();

        public static void WriteLog(String log)
        {
            _logger.Write(log);
        }
        public static void WriteLog(LogSeverity logLevel, String log)
        {
            _logger.Write(logLevel, log);
        }
        public static void Info(String log)
        {
            WriteLog(LogSeverity.Info, log);

        }
        public static void Warn(String log)
        {
            WriteLog(LogSeverity.Warning, log);

        }
        public static void Error(String log)
        {
            WriteLog(LogSeverity.Error, log);

        }

    }
}
