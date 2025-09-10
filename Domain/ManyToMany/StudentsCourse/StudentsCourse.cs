using MadreseV6.Domain.SchoolAggregate;
using MadreseV6.Domain.StudentAggregate;

namespace MadreseV6.Domain.ManyToMany.StudentsCourse
{
    public class StudentsCourse
    {

        public int StudentId { get; set; }
        public Student Student { get; set; }



        public int CourseId { get; set; }
        public Course Course { get; set; }






    }
}
