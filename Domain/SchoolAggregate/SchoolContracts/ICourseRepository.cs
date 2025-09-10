using MadreseV6.Domain.DTOs;

namespace MadreseV6.Domain.SchoolAggregate.SchoolContracts
{
    public interface ICourseRepository
    {
        void AddCourse(int schoolid, int gradeid, CourseDTO coursedto);
        void RemoveCourse(int schoolid, int gradeid,int courseid);
        Course GetCourse(int schoolid,int gradeid,int courseid);
        List<Course> GetAllCourses(int schoolid,int gradeid);
        void UpdateCourse(int schoolid,int gradeid,int courseid,CourseDTO coursedto);
    }
}
