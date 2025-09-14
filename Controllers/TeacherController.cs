using MadreseV6.Domain.TeacherAggregate.TeacherContract;
using MadreseV6.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MadreseV6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController:ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddATeacher(int schoolid,TeacherDTO teacher)
        {
            await _teacherRepository.AddTeacherAsync(schoolid, teacher);
            return Ok();
        }
        [HttpDelete("{teacherid}")]
        public async Task<IActionResult> DeleteATeacher(int schoolid, int teacherid)
        {
            await _teacherRepository.RemoveTeacherAsync(schoolid, teacherid);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> SeeAllTeachers(int schoolid)
        {
            return Ok(await _teacherRepository.GetAllTeachersAsync(schoolid));
        }
        [HttpGet("{teacherid}")]
        public async Task<IActionResult> SeeATeacher(int schoolid,int teacherid)
        {
            return Ok(await _teacherRepository.GetTeacherAsync(schoolid, teacherid));
        }
        [HttpPut("{teacherid}")]
        public async Task<IActionResult> UpdateATeacher(int schoolid,int teacherid,TeacherDTO teacher)
        {
            await _teacherRepository.UpdateTeacherAsync(schoolid, teacherid, teacher);
            return Ok();
        }
        [HttpPost("{teacherid}/AddCourse")]
        public async Task<IActionResult> AppendTeacherToCourse(int schoolid,int gradeid,int courseid,int teacherid)
        {
            await _teacherRepository.AddTeacherToACourseAsync(schoolid, gradeid, courseid, teacherid); return Ok();
        }
    }
}
