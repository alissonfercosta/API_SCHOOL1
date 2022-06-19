using API_SCHOOL.Models.School;

namespace API_SCHOOL.Application.School
{
    public interface ISchoolApplication
    {
        string GetAllSchools();
        SchoolModel GetSchoolById(int Id);
        bool CreateSchool(SchoolModel school);
        bool DeleteSchool(int Id);
        bool EditSchool(SchoolModel school);
    }
}