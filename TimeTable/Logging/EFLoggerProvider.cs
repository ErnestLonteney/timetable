using Microsoft.Extensions.Logging;

namespace TimeTable.Logging
{
    public class EFLoggerProvider : ILoggerProvider
    {
        private ILogger _logger;
        public EFLoggerProvider(ILogger logger)
        {
            _logger = logger;
        }

        public ILogger CreateLogger(string categoryName) => _logger;

        public void Dispose() => ((EFLogger)_logger).Dispose();

    }
}
