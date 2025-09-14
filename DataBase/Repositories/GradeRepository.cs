using MadreseV6.Domain.SchoolAggregate;
using MadreseV6.Domain.SchoolAggregate.SchoolContracts;
using MadreseV6.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MadreseV6.DataBase.Repositories
{
    public class GradeRepository:IGradeRepository
    {
        private readonly MadreseDbContext _context;

        public GradeRepository(MadreseDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddGradeAsync(int schoolid, GradeDTO gradedto)
        {

            var school = await _context.Schools.SingleOrDefaultAsync(x => x.SchoolId == schoolid);
            if (school == null)
                throw new Exception("DataNotFound");

            var Grade = new Grade()
            {
                SchoolId = schoolid,
                GradeName = gradedto.GradeName,
                GradePlace = gradedto.GradePlace,

            };
            await _context.Grades.AddAsync(Grade);
            await _context.SaveChangesAsync();


        }

        public async Task RemoveGradeAsync(int schoolid, int gradeid)
        {
            var grade = await _context.Grades.SingleOrDefaultAsync(x => x.SchoolId == schoolid && x.GradeId == gradeid);
            if (grade == null) throw new Exception("Grade Not Found");
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
        }
        public async Task<Grade> GetGradeAsync(int schoolid, int gradeid)
        {
            var grade = await _context.Grades.Include(x=>x.Courses).SingleOrDefaultAsync(x => x.SchoolId == schoolid && x.GradeId == gradeid);
            if (grade == null) { throw new Exception("Grade Not Found"); }
            return grade;
        }

        public async Task<List<Grade>> GetAllGradesAsync(int schoolid)
        {
            var result = await _context.Grades
                               .Where(g => g.SchoolId == schoolid)
                               .Include(x=>x.Courses)                             
                                        .ToListAsync();
            return result;
        }
        public async Task UpdateGradeAsync(int schoolid, int gradeid, GradeDTO gradeDTO)
        {
            var grade = await _context.Grades.SingleOrDefaultAsync(x => x.SchoolId == schoolid && x.GradeId == gradeid);
            if (grade == null) throw new Exception("DataNotFound");
            grade.GradeName = gradeDTO.GradeName;
            grade.GradePlace = gradeDTO.GradePlace;

            await _context.SaveChangesAsync();


        }
    }
}
