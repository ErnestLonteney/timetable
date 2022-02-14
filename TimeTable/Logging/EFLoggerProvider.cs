using Microsoft.Extensions.Logging;
using System.Runtime.Versioning;
using TimeTable.Logging.DBContext;

namespace TimeTable.Logging
{
    [UnsupportedOSPlatform("browser")]
    [ProviderAlias("EntityFramework")]
    public class EFLoggerProvider : ILoggerProvider
    {
        private readonly ILogger _logger;


        public EFLoggerProvider(EFLoggerContext context)
        {
            _logger = new EFLogger(context);
        }

        public ILogger CreateLogger(string categoryName) => _logger;

        public void Dispose() => ((EFLogger)_logger).Dispose();

    }
}
