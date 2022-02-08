using Microsoft.Extensions.Logging;
using System;
using TimeTable.Logging.DBContext;

namespace TimeTable.Logging
{
    public class EFLogger : ILogger, IDisposable
    {
        private readonly EFLoggerContext _context;
        private readonly string _category;

        public EFLogger(EFLoggerContext context)
        {
            _context = context;
        }

        public IDisposable BeginScope<TState>(TState state) => (IDisposable)this;
        

        public void Dispose() => _context.Dispose();

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            try
            {
                _context.LogElements.Add(new LogElement
                {
                    CategoryName = state.GetType().Name,
                    Date = DateTime.UtcNow,
                    Message = exception?.Message,
                    AdditionalMessage = exception?.InnerException?.Message,
                });

                _context.SaveChangesAsync();
            }
            catch { }
        }
    }
}
