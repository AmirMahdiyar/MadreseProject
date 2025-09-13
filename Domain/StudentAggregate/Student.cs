using MadreseV6.Domain.ManyToMany.StudentsCourse;
using MadreseV6.Domain.SchoolAggregate;
using System.Text.Json.Serialization;

namespace MadreseV6.Domain.StudentAggregate
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public string StudentPhoneNumber { get; set; }


        public int SchoolId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public School School { get; set; }



        public int GradeId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Grade Grade { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<StudentsCourse> Courses { get; set; } = new List<StudentsCourse>();


    }
}
