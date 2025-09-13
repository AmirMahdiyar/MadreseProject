using MadreseV6.Domain.SchoolAggregate;
using MadreseV6.Domain.StudentAggregate;
using System.Text.Json.Serialization;

namespace MadreseV6.Domain.ManyToMany.StudentsCourse
{
    public class StudentsCourse
    {

        public int StudentId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Student Student { get; set; }



        public int CourseId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Course Course { get; set; }






    }
}
