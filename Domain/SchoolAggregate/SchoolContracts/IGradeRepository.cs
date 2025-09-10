using MadreseV6.Domain.DTOs;

namespace MadreseV6.Domain.SchoolAggregate.SchoolContracts
{
    public interface IGradeRepository
    {
        public void AddGrade(int schoolid, GradeDTO gradedto);
        public void RemoveGrade(int schoolid, int gradeid);
        public Grade GetGrade(int schoolid, int gradeid);
        public List<Grade> GetAllGrades(int schoolid);
        public void UpdateGrade(int schoolid, int gradeid, GradeDTO gradeDTO);
    }
}
