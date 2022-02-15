using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTable.Data;
using TimeTable.Data.Entities;
using TimeTable.Data.Repositories;
using TimeTable.Models;
using TimeTable.Services;

namespace TimeTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {        
        public IRepository<Course> _repo;

        private readonly ICourseService service;
        public CoursesController(ICourseService service)
        {
            this.service = service;
            _repo = new Repository<Course>();
        }

        [Route("CreateCourse")]
        [HttpPost]
        public async Task<IActionResult> CreateCourse(CourseDTO course)
        {
            if (ModelState.IsValid)
            {
                await service.CreateCourse(course);

                return Ok();
            }

            return BadRequest();
        }

        [Route("AllCourses")]
        [HttpGet]
        public async Task<List<CourseDTO>> GetAllCourses()
        {
            return await service.GetAllCoursesAsync();
        }
    }
}
