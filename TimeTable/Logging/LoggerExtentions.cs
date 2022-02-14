
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TimeTable.Logging.DBContext;
using Microsoft.Extensions.Configuration;

namespace TimeTable.Logging
{
    public static  class LoggerExtentions 
    {
        public static ILoggingBuilder AddEFLogger(this ILoggingBuilder builder)
        {
            builder.AddProvider(new EFLoggerProvider(new EFLoggerContext()));
         
            return builder;
        }
    }
}
