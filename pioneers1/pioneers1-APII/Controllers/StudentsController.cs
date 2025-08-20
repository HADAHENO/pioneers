using Microsoft.AspNetCore.Mvc;

namespace pioneers1_APII.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = new List<string> { "Huda", "Ahmed", "Omar" };
            return Ok(students);
        }
    }
}
