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

        public async Task AddCourseAsync(int schoolid, int gradeid, CourseDTO coursedto)
        {

            var grade = await _context.Grades.SingleOrDefaultAsync(x => x.SchoolId == schoolid && x.GradeId == gradeid);
            if (grade == null)
                throw new Exception("School Or Grade Not Found !");
            var course = new Course()
            {

                CourseName = coursedto.CourseName,
                Duration = coursedto.Duration,
                GradeId = grade.GradeId,

            };
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();


        }

        public async Task<List<Course>> GetAllCoursesAsync(int schoolid, int gradeid)
        {
            var result = await _context.Grades
                           .Where(g => g.SchoolId == schoolid && g.GradeId == gradeid)
                           .SelectMany(g => g.Courses)
                           .ToListAsync();
            return result;
        }

        public async Task<Course> GetCourseAsync(int schoolid, int gradeid, int courseid)
        {
            //var grade = _context.Grades.Include(g => g.Courses).Single(x => x.SchoolId == schoolid && x.GradeId == gradeid);
            var school= await _context.Schools.SingleOrDefaultAsync(x => x.SchoolId == schoolid);
            var coursee = await _context.Courses.Include(x => x.Students).Include(x => x.Teacher).SingleOrDefaultAsync(x=>x.GradeId == gradeid && x.CourseId == courseid);
            //var course = grade.Courses.Single(x=>x.CourseId == courseid);

            if (school == null || coursee == null)
                throw new Exception("Data not found");

            return coursee;
        }

        public async Task RemoveCourseAsync(int schoolid, int gradeid, int courseid)
        {
            var course = await _context.Courses
                        .Include(c => c.Grade)
                        .SingleOrDefaultAsync(c => c.CourseId == courseid
                         && c.GradeId == gradeid
                         && c.Grade.SchoolId == schoolid);

            if (course == null)
                throw new Exception("Course not found in this school/grade!");

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(int schoolid, int gradeid, int courseid, CourseDTO coursedto)
        {
            var course = await  _context.Courses.Include(x => x.Grade).SingleOrDefaultAsync(x=>x.CourseId ==courseid && x.GradeId == gradeid && x.Grade.SchoolId == schoolid);
            if (course == null) throw new Exception("Data Not Found");

            course.CourseName = coursedto.CourseName;
            course.Duration = coursedto.Duration;

            await _context.SaveChangesAsync();
        }
    }
}
