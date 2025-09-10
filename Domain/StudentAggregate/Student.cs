using MadreseV6.Domain.ManyToMany.StudentsCourse;
using MadreseV6.Domain.SchoolAggregate;

namespace MadreseV6.Domain.StudentAggregate
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public string StudentPhoneNumber { get; set; }


        public int SchoolId { get; set; }
        public School School { get; set; }



        public int GradeId { get; set; }
        public Grade Grade { get; set; }


        public IList<StudentsCourse> Courses { get; set; } = new List<StudentsCourse>();


    }
}
