using MadreseV6.DTOs;

namespace MadreseV6.Domain.SchoolAggregate.SchoolContracts
{
    public interface IGradeRepository
    {
        Task AddGradeAsync(int schoolid, GradeDTO gradedto);
        Task RemoveGradeAsync(int schoolid, int gradeid);
        Task<Grade> GetGradeAsync(int schoolid, int gradeid);
        Task<List<Grade>> GetAllGradesAsync(int schoolid);
        Task UpdateGradeAsync(int schoolid, int gradeid, GradeDTO gradeDTO);
    }
}
