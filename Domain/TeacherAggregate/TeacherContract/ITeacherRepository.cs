using MadreseV6.DTOs;

namespace MadreseV6.Domain.TeacherAggregate.TeacherContract
{
    public interface ITeacherRepository
    {
        Task AddTeacherAsync(int schoolid, TeacherDTO teacherdto);
        Task RemoveTeacherAsync(int schoolid,int teacherid);
        Task<Teacher> GetTeacherAsync(int schoolid,int teacherid);
        Task<List<Teacher>> GetAllTeachersAsync(int schoolid);
        Task UpdateTeacherAsync(int schoolid,int teacherid,TeacherDTO teacherdto);
        Task AddTeacherToACourseAsync(int schoolid, int gradeid, int courseid, int teacherid);

    }
}
