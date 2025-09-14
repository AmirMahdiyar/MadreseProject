using MadreseV6.Domain.SchoolAggregate;
using MadreseV6.Domain.SchoolAggregate.SchoolContracts;
using MadreseV6.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MadreseV6.DataBase.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly MadreseDbContext _context;

        public SchoolRepository(MadreseDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddSchoolAsync(SchoolDTO schooldto)
        {



            var school = new School
            {
                SchoolName = schooldto.SchoolName,
                PhoneNumber = schooldto.PhoneNumber,
                CreationDate = schooldto.CreationDate
            };

            await _context.Schools.AddAsync(school);
            await _context.SaveChangesAsync();



        }
        public async Task RemoveSchoolAsync(int schoolid)
        {
            
            
            var school = await _context.Schools.FirstOrDefaultAsync(x => x.SchoolId == schoolid);
            if (school == null)
            {
                throw new Exception("");
            }
            else
            {
                _context.Schools.Remove(school);
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task<School> GetSchoolAsync(int schoolid)
        {
            var school = await _context.Schools.Include(x=>x.Grades).ThenInclude(x=>x.Courses).FirstOrDefaultAsync(x => x.SchoolId == schoolid);
            if (school == null)
            {
                throw new Exception("School Not Found");
            }
            else
            {
                return school;
            }

        }
        public async Task<List<School>> GetAllSchoolsAsync()
        {
            return await _context.Schools.Include(x=>x.Grades).ThenInclude(x=>x.Courses).ToListAsync();
        }

        public async Task UpdateSchoolAsync(int schoolid , SchoolDTO schooldto)
        {
            var school = await _context.Schools.FindAsync(schoolid);
            if (school == null)
                throw new Exception("School not found");
            school.SchoolName = schooldto.SchoolName;
            school.PhoneNumber = schooldto.PhoneNumber;
            school.CreationDate = schooldto.CreationDate;

            await _context.SaveChangesAsync();
        }


 
    }
}
