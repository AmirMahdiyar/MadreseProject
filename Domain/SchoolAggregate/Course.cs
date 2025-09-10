using MadreseV6.Domain.ManyToMany.StudentsCourse;
using MadreseV6.Domain.TeacherAggregate;
using System.Text.Json.Serialization;

namespace MadreseV6.Domain.SchoolAggregate
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Duration { get; set; }


        public int GradeId { get; set; }
        [JsonIgnore]
        public Grade Grade { get; set; }


        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }


        public IList<StudentsCourse> Students { get; set; } = new List<StudentsCourse>();

    }
}
