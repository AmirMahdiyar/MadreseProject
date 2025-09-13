namespace MadreseV6.DTOs
{
    public class TeacherDTO
    {
        public string TeacherName { get; set; }
        public DateOnly TeacherBornDay { get; set; }

        public List<int> Grades { get; set; } = new List<int>();
        
    }
}
