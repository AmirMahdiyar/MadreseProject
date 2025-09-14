using MadreseV6.DTOs;

namespace MadreseV6.Domain.StudentAggregate.StudentAggregate
{
    public interface IStudentRepository
    {
        Task AddStudentAsync(int schoolid,int gradeid,StudentDTO studentdto);
        Task RemoveStudentAsync(int schoolid, int studentid);
        Task<Student> GetStudentAsync(int schoolid,int studentid);
        Task<List<Student>> GetAllStudentsAsync(int schoolid);
        Task UpdateStudentAsync(int schoolid,int studentid,StudentDTO studentdto);
    }
}
