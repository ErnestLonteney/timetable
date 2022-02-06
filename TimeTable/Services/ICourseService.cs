using System.Threading.Tasks;
using TimeTable.Models;

namespace TimeTable.Services
{
    public interface ICourseService
    {
        Task CreateCourse(CourseDTO course);
    }
}
