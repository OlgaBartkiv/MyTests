using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;

namespace MyObjects.Helpers
{
    /// <summary>
    /// FileLogger class with Singleton pattern
    /// </summary>
    internal sealed class FileLogger : IDisposable
    {
        private static FileLogger _instance = null;  // Singleton object
        private static object _syncLock = new object();  // Sync lock

        internal StreamWriter _writer;   // Stream writer writting to the log file
        internal string _path = @"C:\Users\obartkiv\source\MyTests\MyObjects\bin\Debug\Logs"; // Default folder
        internal string _absolutePath;   // C:\Logs\MachineName.log
        internal string _fileName;       // MachineName.log
        internal LogSeverity _defaultSeverity = LogSeverity.Error; // Default severity

        private FileLogger()
        {

            _fileName = string.IsNullOrEmpty(Environment.MachineName) ?
                "LogFile.log" : Environment.MachineName + ".log";
            _absolutePath = _path + "\\" + _fileName;

            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            _writer = new StreamWriter(_absolutePath, true);
        }

        public static FileLogger GetInstance()
        {
            if (_instance == null)
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new FileLogger();
                    }
                }
            }
            return _instance;
        }


        public void Dispose()
        {
            lock (_syncLock)
            {
                if (_writer != null)
                {
                    _writer.Dispose();
                }
            }
        }

        // Write with default log severity
        public void Write(string msg)
        {
            Write(_defaultSeverity, msg);
        }

        // Write message to log file
        public void Write(LogSeverity logSeverity, string msg)
        {
            lock (_syncLock)
            {
                try
                {
                    if (_writer.BaseStream == null)
                    {
                        _writer = new StreamWriter(_absolutePath, true);
                    }
                    _writer.WriteLine("[{0}] at {1} -- {2}",
                        logSeverity.ToString(), DateTime.Now.ToString(), msg);
                    _writer.Flush();
                }
                catch (Exception ex)
                {
                    WriteToEventLog(ex.Message);
                }
            }
        }

        private void WriteToEventLog(string message)
        {
            string source = "Logger";
            string log = "Application";

            try
            {
                if (!EventLog.SourceExists(source))
                    EventLog.CreateEventSource(source, log);

                EventLog.WriteEntry(source, message, EventLogEntryType.Error);
            }
            catch { }
        }

    }
}
