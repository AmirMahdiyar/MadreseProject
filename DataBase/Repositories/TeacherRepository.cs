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
        public async Task AddTeacherAsync(int schoolid, TeacherDTO teacherdto)
        {

            var school = await _context.Schools.SingleOrDefaultAsync(x => x.SchoolId == schoolid);
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
                var grade = await _context.Grades.SingleOrDefaultAsync(g => g.GradeId == GradeNumber && g.SchoolId == schoolid);
                if (grade == null)
                    throw new Exception($"Gradeid {GradeNumber} Not Found!");
                teacher.Grades.Add(new Domain.ManyToMany.TeachersGrade.TeachersGrade()
                {
                    GradeId = GradeNumber,

                });

            }

            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();



        }

        public async Task<List<Teacher>> GetAllTeachersAsync(int schoolid)
        {
            var school = await _context.Schools.SingleOrDefaultAsync(x=>x.SchoolId == schoolid);
            var teachers =await _context.Teachers.Include(x=>x.Courses).Include(x=>x.Grades).Where(x=>x.SchoolId ==schoolid).ToListAsync();
            
            if (school == null)
                throw new Exception("DataNotFound");
            return teachers;
        }

        public async Task<Teacher> GetTeacherAsync(int schoolid, int teacherid)
        {
            var school = await _context.Schools
                .Include(x=>x.Teachers)
                .ThenInclude(x=>x.Grades)
                .Include(x=>x.Teachers)
                .ThenInclude(x=>x.Courses).SingleOrDefaultAsync(x=>x.SchoolId==schoolid);
            if (school == null)
                throw new Exception("SchoolNotFoUnd");
            var teacher = school.Teachers.SingleOrDefault(x=>x.TeacherId==teacherid);
            if (teacher == null)
                throw new Exception("TeacherNotFound");
            return teacher;
        }

        public async Task RemoveTeacherAsync(int schoolid, int teacherid)
        {
            var teacher = await _context.Teachers.SingleOrDefaultAsync(x=>x.SchoolId==schoolid && x.TeacherId == teacherid);
            if (teacher == null)
                throw new Exception("Data Not Found");
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();

        }

        public async Task UpdateTeacherAsync(int schoolid, int teacherid,TeacherDTO teacherdto)
        {
            var school = await _context.Schools.Include(x => x.Teachers).SingleOrDefaultAsync(x => x.SchoolId == schoolid);
            if (school == null) throw new Exception("SchoolNotFOund");
            var teacher = school.Teachers.SingleOrDefault(x=>x.TeacherId == teacherid);
            if (teacher == null) throw new Exception("TeacherNotFound");
            teacher.TeacherName = teacherdto.TeacherName;
            teacher.TeacherBornDay = teacherdto.TeacherBornDay;
            await _context.SaveChangesAsync();
        }

        public async Task AddTeacherToACourseAsync(int schoolid,int gradeid,int courseid,int teacherid)
        {
        
            var course = await _context.Courses
                .Include(c => c.Grade)
                .SingleOrDefaultAsync(c => c.CourseId == courseid && c.GradeId == gradeid && c.Grade.SchoolId == schoolid);

            if (course == null)
                throw new Exception("Course not found in this school/grade");

            var teacher = await _context.Teachers
                .SingleOrDefaultAsync(t => t.TeacherId == teacherid && t.SchoolId == schoolid);

            if (teacher == null)
                throw new Exception("Teacher not found in this school");

            course.TeacherId = teacherid;

            await _context.SaveChangesAsync();
        

    }
}
}
