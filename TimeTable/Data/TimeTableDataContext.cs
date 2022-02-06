using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TimeTable.Data.Entities;
using TimeTable.Models;

namespace TimeTable.Data
{
    public class TimeTableDataContext : DbContext
    {
        public TimeTableDataContext(DbContextOptions<TimeTableDataContext> options)
            :base(options)
        {

        }

        public TimeTableDataContext()
        {

        }


        public DbSet<Client> Clients { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ReservedTime> Times { get; set; }
    }
}
