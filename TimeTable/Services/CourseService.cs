using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TimeTable.Data;
using TimeTable.Models;

namespace TimeTable.Services
{
    public class CourseService : ICourseService
    {
        private readonly TimeTableDataContext dataContext;
        private readonly ILogger<CourseService> logger;

        public CourseService()
        {
            dataContext = new TimeTableDataContext();
           // logger = LoggerFactory.Create(); 
        }
        public async Task CreateCourse(Course course)
        {
            try
            {
               await dataContext.Courses.AddAsync(course);
               await dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
            }
        }
    }
}
