using MadreseV6.Domain.DTOs;

namespace MadreseV6.Domain.SchoolAggregate.SchoolContracts
{
    public interface ISchoolRepository
    {
        void AddSchool(SchoolDTO schooldto);
        public void RemoveSchool(int schoolid);
        public School GetSchool(int schoolid);
        public List<School> GetAllSchools();
        public void UpdateSchool(int schoolid, SchoolDTO schooldto);

    }
}
