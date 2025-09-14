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

        public async Task AddStudentAsync(int schoolid,int gradeid, StudentDTO studentdto)
        {
            var grade = await _context.Grades.SingleOrDefaultAsync(x=>x.SchoolId == schoolid && x.GradeId == gradeid);
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
                var course = await _context.Courses.SingleOrDefaultAsync(x => x.CourseId == Courseid);
                if (course == null) throw new Exception("CourseNotFound");
                student.Courses.Add(new StudentsCourse()
                {
                    CourseId = Courseid,
                });

            }
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();



        }

        public async Task<List<Student>> GetAllStudentsAsync(int schoolid)
        {
            var result = await _context.Students.Include(x=>x.Courses).Where(x=>x.SchoolId == schoolid).ToListAsync();
            return result;
        }

        public async Task<Student> GetStudentAsync(int schoolid, int studentid)
        {
            var student= await _context.Students.Include(x=>x.Courses).SingleOrDefaultAsync(x=>x.SchoolId == schoolid && x.StudentId == studentid);
            if (student == null) throw new Exception("StudentNotFound");
            return student;
        }

        public async Task RemoveStudentAsync(int schoolid, int studentid)
        {
            var student = await _context.Students.SingleOrDefaultAsync(x=>x.SchoolId == schoolid && x.StudentId == studentid);
            if (student == null) throw new Exception("StudentNotFOUNd");
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(int schoolid, int studentid, StudentDTO studentdto)
        {
            var student = await  _context.Students.SingleOrDefaultAsync(x => x.SchoolId == schoolid && x.StudentId == studentid);
            if (student == null) throw new Exception("StudentNotFOUNd");
            student.StudentName = studentdto.StudentName;
            student.StudentPhoneNumber = studentdto.StudentPhoneNumber;

            await _context.SaveChangesAsync();

        }
    }
}
