using MadreseV6.Domain.ManyToMany.StudentsCourse;
using MadreseV6.Domain.StudentAggregate;
using MadreseV6.Domain.StudentAggregate.StudentAggregate;
using MadreseV6.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace MadreseV6.DataBase.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MadreseDbContext _context;

        public StudentRepository(MadreseDbContext dbContext)
        {
            _context = dbContext;
        }

        public void AddStudent(int schoolid,int gradeid, StudentDTO studentdto)
        {
            var grade = _context.Grades.SingleOrDefault(x=>x.SchoolId == schoolid && x.GradeId == gradeid);
            if (grade == null) throw new Exception("SchoolNotFound");
            var student = new Student()
            {
                SchoolId = schoolid,
                GradeId = gradeid,
                StudentName = studentdto.StudentName,
                StudentPhoneNumber = studentdto.StudentPhoneNumber,
            };

            foreach(var Courseid in studentdto.Courses)
            {
                var course = _context.Courses.SingleOrDefault(x => x.CourseId == Courseid);
                if (course == null) throw new Exception("CourseNotFound");
                student.Courses.Add(new StudentsCourse()
                {
                    CourseId = Courseid,
                });

            }
            _context.Students.Add(student);
            _context.SaveChanges();



        }

        public List<Student> GetAllStudents(int schoolid)
        {
            return _context.Students.Include(x=>x.Courses).Where(x=>x.SchoolId == schoolid).ToList();
        }

        public Student GetStudent(int schoolid, int studentid)
        {
            var student= _context.Students.Include(x=>x.Courses).SingleOrDefault(x=>x.SchoolId == schoolid && x.StudentId == studentid);
            if (student == null) throw new Exception("StudentNotFound");
            return student;
        }

        public void RemoveStudent(int schoolid, int studentid)
        {
            var student = _context.Students.SingleOrDefault(x=>x.SchoolId == schoolid && x.StudentId == studentid);
            if (student == null) throw new Exception("StudentNotFOUNd");
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(int schoolid, int studentid, StudentDTO studentdto)
        {
            var student = _context.Students.SingleOrDefault(x => x.SchoolId == schoolid && x.StudentId == studentid);
            if (student == null) throw new Exception("StudentNotFOUNd");
            student.StudentName = studentdto.StudentName;
            student.StudentPhoneNumber = studentdto.StudentPhoneNumber;

            _context.SaveChanges();

        }
    }
}
