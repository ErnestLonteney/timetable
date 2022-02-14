using Microsoft.Extensions.Logging;

namespace TimeTable.Logging
{
    public class FileLogProvider : ILoggerProvider
    {
        private readonly string path;
        public FileLogProvider(string path)
        {
            this.path = path;
        }
        public ILogger CreateLogger(string categoryName) => new FileLogger(path);

        public void Dispose()
        {           
        }
    }
}
