using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TimeTable.Data;
using TimeTable.Models;
using AutoMapper;
using TimeTable.Data.Entities;
using TimeTable.Data.Repositories;
using System.Collections.Generic;

namespace TimeTable.Services
{
    public class CourseService : ICourseService
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IRepository<Course> courseConext;

        public CourseService(ILogger logger, IRepository<Course> courseConext)
        {
            this.courseConext = courseConext;
            mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<CourseDTO, Course>()));
            this.logger = logger; 
        }
        public async Task CreateCourse(CourseDTO course)
        {         
            try
            {
                var courseDB = mapper.Map<Course>(course);
                await courseConext.AddAsync(courseDB);
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
            }
        }

        public async Task<List<CourseDTO>> GetAllCoursesAsync()
        {
            try
            {
                var courses = await courseConext.GetAllAsync();
                return mapper.Map<List<CourseDTO>>(courses);
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
            }

            return null;
        }
    }
}
