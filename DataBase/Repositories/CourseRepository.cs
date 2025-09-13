using MadreseV6.Domain.SchoolAggregate;
using MadreseV6.Domain.SchoolAggregate.SchoolContracts;
using MadreseV6.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MadreseV6.DataBase.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly MadreseDbContext _context;

        public CourseRepository(MadreseDbContext dbContext)
        {
            _context = dbContext;
        }

        public void AddCourse(int schoolid, int gradeid, CourseDTO coursedto)
        {

            var grade = _context.Grades.SingleOrDefault(x => x.SchoolId == schoolid && x.GradeId == gradeid);
            if (grade == null)
                throw new Exception("School Or Grade Not Found !");
            var course = new Course()
            {

                CourseName = coursedto.CourseName,
                Duration = coursedto.Duration,
                GradeId = grade.GradeId,

            };
            _context.Courses.Add(course);
            _context.SaveChanges();


        }

        public List<Course> GetAllCourses(int schoolid, int gradeid)
        {
            return _context.Grades
                           .Where(g => g.SchoolId == schoolid && g.GradeId == gradeid)
                           .SelectMany(g => g.Courses)
                           .ToList();
        }

        public Course GetCourse(int schoolid, int gradeid, int courseid)
        {
            //var grade = _context.Grades.Include(g => g.Courses).Single(x => x.SchoolId == schoolid && x.GradeId == gradeid);
            var school = _context.Schools.Single(x => x.SchoolId == schoolid);
            if (school == null)
                throw new Exception("DataNotFoundd");
            var coursee = _context.Courses.Include(x => x.Students).Include(x => x.Teacher).SingleOrDefault(x=>x.GradeId == gradeid && x.CourseId == courseid);
            if (coursee == null)
                throw new Exception("DataNotFound");
            //var course = grade.Courses.Single(x=>x.CourseId == courseid);
            return coursee;
        }

        public void RemoveCourse(int schoolid, int gradeid, int courseid)
        {
            var course = _context.Courses
                        .Include(c => c.Grade)
                        .SingleOrDefault(c => c.CourseId == courseid
                         && c.GradeId == gradeid
                         && c.Grade.SchoolId == schoolid);

            if (course == null)
                throw new Exception("Course not found in this school/grade!");

            _context.Courses.Remove(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(int schoolid, int gradeid, int courseid, CourseDTO coursedto)
        {
            var course = _context.Courses.Include(x => x.Grade).Single(x=>x.CourseId ==courseid && x.GradeId == gradeid && x.Grade.SchoolId == schoolid);
            if (course == null) throw new Exception("Data Not Found");

            course.CourseName = coursedto.CourseName;
            course.Duration = coursedto.Duration;

            _context.SaveChanges();
        }
    }
}
