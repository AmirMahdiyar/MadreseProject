using MadreseV6.DTOs;

namespace MadreseV6.Domain.StudentAggregate.StudentAggregate
{
    public interface IStudentRepository
    {
        void AddStudent(int schoolid,int gradeid,StudentDTO studentdto);
        void RemoveStudent(int schoolid, int studentid);
        Student GetStudent(int schoolid,int studentid);
        List<Student> GetAllStudents(int schoolid);
        void UpdateStudent(int schoolid,int studentid,StudentDTO studentdto);
    }
}
