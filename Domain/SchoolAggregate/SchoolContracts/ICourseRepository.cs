using MadreseV6.DTOs;

namespace MadreseV6.Domain.SchoolAggregate.SchoolContracts
{
    public interface ICourseRepository
    {
        Task AddCourseAsync(int schoolid, int gradeid, CourseDTO coursedto);
        Task RemoveCourseAsync(int schoolid, int gradeid,int courseid);
        Task<Course> GetCourseAsync(int schoolid,int gradeid,int courseid);
        Task<List<Course>> GetAllCoursesAsync(int schoolid,int gradeid);
        Task UpdateCourseAsync(int schoolid,int gradeid,int courseid,CourseDTO coursedto);
    }
}
