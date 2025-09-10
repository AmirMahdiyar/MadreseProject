namespace MadreseV6.Domain.DTOs
{
    public class StudentDTO
    {
        public string StudentName { get; set; }

        public string StudentPhoneNumber { get; set; }

        public List<int> Courses { get; set; }
    }
}
