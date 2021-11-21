using Microsoft.EntityFrameworkCore;
using TimeTable.Models;

namespace TimeTable.Data
{
    public class TimeTableDataContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ReservedTime> Times { get; set; }
    }
}
