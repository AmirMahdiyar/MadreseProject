using MadreseV6.Domain.SchoolAggregate;
using MadreseV6.Domain.TeacherAggregate;
using MadreseV6.Domain.TeacherAggregate.TeacherContract;
using MadreseV6.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MadreseV6.DataBase.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MadreseDbContext _context;

        public TeacherRepository(MadreseDbContext dbContext)
        {
            _context = dbContext;
        }
            public void AddTeacher(int schoolid,TeacherDTO teacherdto)
            {

                    var school = _context.Schools.SingleOrDefault(x => x.SchoolId == schoolid);
                if (school == null)
                {
                    throw new Exception("School not Found ! ");
                }

                var teacher = new Teacher()
                {
                    SchoolId = schoolid,
                    TeacherName = teacherdto.TeacherName,
                    TeacherBornDay = teacherdto.TeacherBornDay,

                };
                foreach (var GradeNumber in teacherdto.Grades)
                {
                    var grade = _context.Grades.SingleOrDefault(g => g.GradeId == GradeNumber && g.SchoolId == schoolid);
                    if (grade == null)
                        throw new Exception($"Gradeid {GradeNumber} Not Found!");
                    teacher.Grades.Add(new Domain.ManyToMany.TeachersGrade.TeachersGrade()
                    {
                        GradeId = GradeNumber,

                    });

                }
                _context.Teachers.Add(teacher);
                _context.SaveChanges();



            }

        public List<Teacher> GetAllTeachers(int schoolid)
        {
            var school = _context.Schools.Single(x=>x.SchoolId == schoolid);
            var teachers = _context.Teachers.Where(x=>x.SchoolId ==schoolid).ToList();
            
            if (school == null)
                throw new Exception("DataNotFound");
            return teachers;
        }

        public Teacher GetTeacher(int schoolid, int teacherid)
        {
            var school = _context.Schools
                .Include(x=>x.Teachers)
                .ThenInclude(x=>x.Grades)
                .Include(x=>x.Teachers)
                .ThenInclude(x=>x.Courses).SingleOrDefault(x=>x.SchoolId==schoolid);
            if (school == null)
                throw new Exception("SchoolNotFoUnd");
            var teacher = school.Teachers.SingleOrDefault(x=>x.TeacherId==teacherid);
            if (teacher == null)
                throw new Exception("TeacherNotFound");
            return teacher;
        }

        public void RemoveTeacher(int schoolid, int teacherid)
        {
            var teacher = _context.Teachers.SingleOrDefault(x=>x.SchoolId==schoolid && x.TeacherId == teacherid);
            if (teacher == null)
                throw new Exception("Data Not Found");
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();

        }

        public void UpdateTeacher(int schoolid, int teacherid,TeacherDTO teacherdto)
        {
            var school = _context.Schools.Include(x => x.Teachers).SingleOrDefault(x => x.SchoolId == schoolid);
            if (school == null) throw new Exception("SchoolNotFOund");
            var teacher = school.Teachers.SingleOrDefault(x=>x.TeacherId == teacherid);
            if (teacher == null) throw new Exception("TeacherNotFound");
            teacher.TeacherName = teacherdto.TeacherName;
            teacher.TeacherBornDay = teacherdto.TeacherBornDay;
            _context.SaveChanges();
        }

        public void AddTeacherToACourse(int schoolid,int gradeid,int courseid,int teacherid)
        {
        
            var course = _context.Courses
                .Include(c => c.Grade)
                .SingleOrDefault(c => c.CourseId == courseid && c.GradeId == gradeid && c.Grade.SchoolId == schoolid);

            if (course == null)
                throw new Exception("Course not found in this school/grade");

            var teacher = _context.Teachers
                .SingleOrDefault(t => t.TeacherId == teacherid && t.SchoolId == schoolid);

            if (teacher == null)
                throw new Exception("Teacher not found in this school");

            course.TeacherId = teacherid;

            _context.SaveChanges();
        

    }
}
}
