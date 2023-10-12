using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStudentsApi.Models;
namespace WebStudentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseApiController : ControllerBase
    {
        private readonly Interfaces.IUnitOfWork unitOfWork;
        public CourseApiController(Interfaces.IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            var data = await unitOfWork.Course.GetAllCourse();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(Course course)
        {
            var data = await unitOfWork.Course.AddCourse(course);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var data = await unitOfWork.Course.DeleteCourse(id);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseByID(int id)
        {
            var data = await unitOfWork.Course.GetCourseByID(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourse(Course course)
        {
            var data = await unitOfWork.Course.UpdateCourse(course);
            return Ok(data);
        }
    }
}
