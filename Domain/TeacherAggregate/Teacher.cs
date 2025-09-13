using MadreseV6.Domain.ManyToMany.TeachersGrade;
using MadreseV6.Domain.SchoolAggregate;
using System.Text.Json.Serialization;

namespace MadreseV6.Domain.TeacherAggregate
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public DateOnly TeacherBornDay { get; set; }


        public int SchoolId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public School School { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<TeachersGrade> Grades { get; set; } = new List<TeachersGrade>();
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<Course> Courses { get; set; } = new List<Course>();


    }
}
