using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace TimeTable.Logging
{
    public class FileLogger : ILogger
    {
        private readonly string path;
        private FileStream fs;

        public FileLogger(string path)
        {
            this.path = path;
        }

        public IDisposable BeginScope<TState>(TState state) => (IDisposable)fs;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string dateStr = (DateTime.Today.ToShortDateString() + ".txt").Replace('/', '-');
            string message = $"{logLevel} - {state} - { exception?.Message } ";
            string fullPath = Path.Combine(path, dateStr);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            fs = File.Exists(fullPath) ? File.Open(fullPath, FileMode.Append) : File.Create(fullPath);
            var streamWriter = new StreamWriter(fs);

            try
            {
                streamWriter.WriteLine(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                fs.Close();
            }  
        }
    }
}
