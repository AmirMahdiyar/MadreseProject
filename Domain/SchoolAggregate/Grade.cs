using MadreseV6.Domain.ManyToMany.TeachersGrade;
using MadreseV6.Domain.StudentAggregate;
using System.Text.Json.Serialization;

namespace MadreseV6.Domain.SchoolAggregate
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public int GradePlace {  get; set; }


        
        public int SchoolId { get; set; }
        [JsonIgnore]
        public School School { get; set; }


        public IList<Course> Courses { get; set; } = new List<Course>();

        public IList<TeachersGrade> Teachers { get; set; } = new List<TeachersGrade>();

        public IList<Student> Students { get; set; } = new List<Student>();




    }
}
