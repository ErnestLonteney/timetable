using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TimeTable.Data;
using TimeTable.Models;
using AutoMapper;
using TimeTable.Data.Entities;

namespace TimeTable.Services
{
    public class CourseService : ICourseService
    {
        private readonly TimeTableDataContext dataContext;
        private readonly ILogger<CourseService> logger;
        private readonly IMapper mapper;

        public CourseService()
        {
            dataContext = new TimeTableDataContext();
            mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<CourseDTO, Course>()));
           // logger = LoggerFactory.Create(); 
        }
        public async Task CreateCourse(CourseDTO course)
        {         
            try
            {
                var courseDB = mapper.Map<Course>(course);
                await dataContext.Courses.AddAsync(courseDB);
                await dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
            }
        }
    }
}
