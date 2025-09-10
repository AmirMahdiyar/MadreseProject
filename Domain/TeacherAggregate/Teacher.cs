using MadreseV6.Domain.ManyToMany.TeachersGrade;
using MadreseV6.Domain.SchoolAggregate;

namespace MadreseV6.Domain.TeacherAggregate
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public DateOnly TeacherBornDay { get; set; }


        public int SchoolId { get; set; }
        public School School { get; set; }



        public IList<TeachersGrade> Grades { get; set; } = new List<TeachersGrade>();

        public IList<Course> Courses { get; set; } = new List<Course>();


    }
}
