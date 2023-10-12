using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStudentsApi.Models;

namespace WebStudentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsApiController : ControllerBase
    {
        private readonly Interfaces.IUnitOfWork unitOfWork;
        public StudentsApiController(Interfaces.IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

       
        [HttpPost]
        public async Task<IActionResult> AddStudents(Students students)
        {
            var data = await unitOfWork.Students.AddStudents(students);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudents(int id)
        {
            var data = await unitOfWork.Students.DeleteStudents(id);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentsByID(int id)
        {
            var data = await unitOfWork.Students.GetStudentsByID(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudents(Students students)
        {
            var data = await unitOfWork.Students.UpdateStudents(students);
            return Ok(data);
        }

        [HttpPut("UnAssignCourse")]
        public async Task<IActionResult> UnAssignCourse(Students students)
        {
            var data = await unitOfWork.Students.UnAssignCourse(students.studentsID);
            return Ok(data);
        }
        [HttpPut("AssignCourse")]
        public async Task<IActionResult> AssignCourse(Students students)
        {
            var data = await unitOfWork.Students.AssignCourse(students.studentsID,students.courseID);
            return Ok(data);
        }

    }
}
