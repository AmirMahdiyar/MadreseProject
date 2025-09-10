using MadreseV6.Domain.StudentAggregate;
using MadreseV6.Domain.TeacherAggregate;

namespace MadreseV6.Domain.SchoolAggregate
{
    public class School
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly CreationDate { get; set; }

        public IList<Grade> Grades { get; set; } = new List<Grade>();
        public IList<Teacher> Teachers { get; set; } = new List<Teacher>();
        public IList<Student> Students { get; set; } = new List<Student>();

    }
}
