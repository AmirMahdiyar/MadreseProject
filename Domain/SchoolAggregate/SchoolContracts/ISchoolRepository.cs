using MadreseV6.DTOs;

namespace MadreseV6.Domain.SchoolAggregate.SchoolContracts
{
    public interface ISchoolRepository
    {
        Task AddSchoolAsync(SchoolDTO schooldto);
        Task RemoveSchoolAsync(int schoolid);
        Task<School> GetSchoolAsync(int schoolid);
        Task<List<School>> GetAllSchoolsAsync();
        Task UpdateSchoolAsync(int schoolid, SchoolDTO schooldto);

    }
}
