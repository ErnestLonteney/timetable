using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TimeTable.Data;
using TimeTable.Models;
using TimeTable.Services;

namespace TimeTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService service;
        public CoursesController(ICourseService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> CreateCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                await service.CreateCourse(course);

                return Ok();
            }

            return BadRequest();
        }
    }
}
