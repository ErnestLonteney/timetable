using Microsoft.EntityFrameworkCore;

namespace TimeTable.Logging.DBContext
{
    public class EFLoggerContext : DbContext
    {      
        public EFLoggerContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=Logs;Trusted_Connection=True;");
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
