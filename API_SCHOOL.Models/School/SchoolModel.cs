namespace API_SCHOOL.Models.School
{
    public class SchoolModel
    {
        public int Id { get; set; }
        public int IsActive { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int Capacity { get; set; }
        public string? Grade { get; set; }

    }
}
