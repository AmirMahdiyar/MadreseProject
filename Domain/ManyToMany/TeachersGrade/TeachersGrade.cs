using MadreseV6.Domain.SchoolAggregate;
using MadreseV6.Domain.TeacherAggregate;
using System.Text.Json.Serialization;

namespace MadreseV6.Domain.ManyToMany.TeachersGrade
{
    public class TeachersGrade
    {
        public int TeacherId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Teacher Teacher { get; set; }


        public int GradeId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Grade Grade { get; set; }

    }
}
