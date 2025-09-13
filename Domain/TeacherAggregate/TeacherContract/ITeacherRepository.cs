using MadreseV6.DTOs;

namespace MadreseV6.Domain.TeacherAggregate.TeacherContract
{
    public interface ITeacherRepository
    {
        void AddTeacher(int schoolid, TeacherDTO teacherdto);
        void RemoveTeacher(int schoolid,int teacherid);
        Teacher GetTeacher(int schoolid,int teacherid);
        List<Teacher> GetAllTeachers(int schoolid);
        void UpdateTeacher(int schoolid,int teacherid,TeacherDTO teacherdto);
        public void AddTeacherToACourse(int schoolid, int gradeid, int courseid, int teacherid);

    }
}
