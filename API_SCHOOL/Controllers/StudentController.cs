using Microsoft.AspNetCore.Mvc;

namespace API_SCHOOL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet("GetAllStudents")]
        public string GetAllStudents()
        {
            return "";
        }

        [HttpGet("GetStudentById")]
        public string GetStudentById(int id)
        {
            return "";
        }

        [HttpPut("EditStudentById")]
        public string EditStudentById(int id)
        {
            return "";
        }

        [HttpDelete("DeleteStudentById")]
        public string DeleteStudentById(int id)
        {
            return "";
        }
    }
}
