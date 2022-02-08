using Microsoft.EntityFrameworkCore;

namespace TimeTable.Logging.DBContext
{
    public class EFLoggerContext : DbContext
    {
        public EFLoggerContext(DbContextOptions<EFLoggerContext> options)
            : base(options)
        {

        }

        public EFLoggerContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogElement>().HasKey("CategoryName", "Date");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LogElement> LogElements { get; set; }
        public DbSet<RequestElement> RequestElements { get; set; }
    }
}
