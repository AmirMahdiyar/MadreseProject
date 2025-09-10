using MadreseV6.Domain.SchoolAggregate;
using MadreseV6.Domain.TeacherAggregate;

namespace MadreseV6.Domain.ManyToMany.TeachersGrade
{
    public class TeachersGrade
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }


        public int GradeId { get; set; }
        public Grade Grade { get; set; }

    }
}
