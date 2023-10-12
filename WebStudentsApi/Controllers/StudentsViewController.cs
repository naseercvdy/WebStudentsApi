using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStudentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsViewController : ControllerBase
    {
        private readonly Interfaces.IUnitOfWork unitOfWork;
        public StudentsViewController(Interfaces.IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var data = await unitOfWork.ViewStudents.GetAllStudents();
            return Ok(data);
        }
    }
}
