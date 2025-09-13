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

        public void AddGrade(int schoolid, GradeDTO gradedto)
        {
            try
            {
                var school = _context.Schools.Single(x => x.SchoolId == schoolid);
                
                var Grade = new Grade()
                {
                    SchoolId = schoolid,
                    GradeName = gradedto.GradeName,
                    GradePlace = gradedto.GradePlace,

                };
                _context.Grades.Add(Grade);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Something Went Wrong !");
            }
        }

        public void RemoveGrade(int schoolid, int gradeid)
        {
            var grade = _context.Grades.Single(x => x.SchoolId == schoolid && x.GradeId == gradeid);
            if (grade == null) throw new Exception("Grade Not Found");
            _context.Grades.Remove(grade);
            _context.SaveChanges();
        }
        public Grade GetGrade(int schoolid, int gradeid)
        {
            var grade = _context.Grades.Include(x=>x.Teachers).Single(x => x.SchoolId == schoolid && x.GradeId == gradeid);
            if (grade == null) throw new Exception("Grade Not Found");
            return grade;
        }

        public List<Grade> GetAllGrades(int schoolid)
        {
            return _context.Grades
                               .Where(g => g.SchoolId == schoolid)
                                .Include(g => g.Teachers)                              
                                        .ToList();
        }
        public void UpdateGrade(int schoolid, int gradeid, GradeDTO gradeDTO)
        {
            var grade = _context.Grades.Single(x => x.SchoolId == schoolid && x.GradeId == gradeid);
            grade.GradeName = gradeDTO.GradeName;
            grade.GradePlace = gradeDTO.GradePlace;

            _context.SaveChanges();


        }
    }
}
