using API_SCHOOL.Application.School;
using API_SCHOOL.Models.School;
using Microsoft.AspNetCore.Mvc;

namespace API_SCHOOL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : ControllerBase
    {
        public ISchoolApplication _schoolApplication;
        public SchoolController(ISchoolApplication schoolApplication)
        {
            _schoolApplication = schoolApplication;
        }

        [HttpGet("GetAllSchools")]
        public string GetAllSchools()
        {
            return _schoolApplication.GetAllSchools();
        }

        [HttpGet("GetSchoolById")]
        public SchoolModel GetSchoolById(int id)
        {
            return _schoolApplication.GetSchoolById(id);
        }

        [HttpPost("CreateSchool")]
        public bool CreateSchool(SchoolModel School)
        {
            return _schoolApplication.CreateSchool(School);
        }

        [HttpPut("EditSchool")]
        public bool EditSchoolById(SchoolModel School)
        {
            return _schoolApplication.EditSchool(School);
        }

        [HttpDelete("DeleteSchoolById")]
        public bool DeleteSchoolById(int id)
        {
            return _schoolApplication.DeleteSchool(id);
        }
    }
}
