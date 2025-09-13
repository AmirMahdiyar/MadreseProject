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

        public void AddSchool(SchoolDTO schooldto)
        {
            try
            {

                var school = new School
                {
                    SchoolName = schooldto.SchoolName,
                    PhoneNumber = schooldto.PhoneNumber,
                    CreationDate = schooldto.CreationDate
                };

                _context.Schools.Add(school);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Error !");
            }


        }
        public void RemoveSchool(int schoolid)
        {
            try
            {
                var school = _context.Schools.First(x => x.SchoolId == schoolid);
                if (school != null)
                {
                    _context.Schools.Remove(school);
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("School Not Found");
            }
        }

        public School GetSchool(int schoolid)
        {
            var school = _context.Schools.FirstOrDefault(x => x.SchoolId == schoolid);
            if (school != null)
            {
                return school;

            }
            else
            {
                throw new Exception("School Not Found");
            }

        }
        public List<School> GetAllSchools()
        {
            return _context.Schools.ToList();
        }

        public void UpdateSchool(int schoolid , SchoolDTO schooldto)
        {
            var school = _context.Schools.Find(schoolid);
            if (school == null)
                throw new Exception("School not found");
            school.SchoolName = schooldto.SchoolName;
            school.PhoneNumber = schooldto.PhoneNumber;
            school.CreationDate = schooldto.CreationDate;

            _context.SaveChanges();
        }


 
    }
}
