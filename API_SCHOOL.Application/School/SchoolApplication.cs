using API_SCHOOL.Domain.School;
using API_SCHOOL.Models.School;

namespace API_SCHOOL.Application.School
{
    public class SchoolApplication : ISchoolApplication
    {
        public ISchoolDomain _schoolDomain;

        public SchoolApplication(ISchoolDomain schoolDomain)
        {
            _schoolDomain = schoolDomain;
        }

        #region Public methods

        public string GetAllSchools() { return _schoolDomain.GetAllSchools(); }

        public SchoolModel GetSchoolById(int Id) { return _schoolDomain.GetSchoolById(Id); }

        public bool CreateSchool(SchoolModel school) { return _schoolDomain.CreateSchool(school); }

        public bool DeleteSchool(int Id) { return _schoolDomain.DeleteSchool(Id); }

        public bool EditSchool(SchoolModel school) { return _schoolDomain.EditSchool(school); }

        #endregion
    }
}
