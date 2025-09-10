using MadreseV6.Domain.DTOs;
using MadreseV6.Domain.TeacherAggregate.TeacherContract;
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
        public IActionResult AddATeacher(int schoolid,TeacherDTO teacher)
        {
            _teacherRepository.AddTeacher(schoolid, teacher);
            return Ok();
        }
        [HttpDelete("{teacherid}")]
        public IActionResult DeleteATeacher(int schoolid, int teacherid)
        {
            _teacherRepository.RemoveTeacher(schoolid, teacherid);
            return Ok();
        }
        [HttpGet]
        public IActionResult SeeAllTeachers(int schoolid)
        {
            return Ok(_teacherRepository.GetAllTeachers(schoolid));
        }
        [HttpGet("{teacherid}")]
        public IActionResult SeeATeacher(int schoolid,int teacherid)
        {
            return Ok(_teacherRepository.GetTeacher(schoolid,teacherid));
        }
        [HttpPut("{teacherid}")]
        public IActionResult UpdateATeacher(int schoolid,int teacherid,TeacherDTO teacher)
        {
            _teacherRepository.UpdateTeacher(schoolid, teacherid, teacher);
            return Ok();
        }
        [HttpPost("{teacherid}/AddCourse")]
        public IActionResult AppendTeacherToCourse(int schoolid,int gradeid,int courseid,int teacherid)
        {
            _teacherRepository.AddTeacherToACourse(schoolid,gradeid,courseid, teacherid); return Ok();
        }
    }
}
