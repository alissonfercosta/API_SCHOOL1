using API_SCHOOL.Models.School;

namespace API_SCHOOL.Domain.School
{
    public interface ISchoolDomain
    {
        string GetAllSchools();
        SchoolModel GetSchoolById(int Id);
        bool CreateSchool(SchoolModel school);
        bool DeleteSchool(int Id);
        bool EditSchool(SchoolModel school);
    }
}