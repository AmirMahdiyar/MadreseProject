using MadreseV6.Domain.DTOs;
using MadreseV6.Domain.StudentAggregate.StudentAggregate;
using Microsoft.AspNetCore.Mvc;

namespace MadreseV6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPost]
        public IActionResult AddAStudent(int schoolid,int gradeid,StudentDTO student)
        {
            _studentRepository.AddStudent(schoolid,gradeid,student);
            return Ok();
        }
        [HttpDelete("{studentid}")]
        public IActionResult DeleteAStudent(int schoolid,int studentid)
        {
            _studentRepository.RemoveStudent(schoolid,studentid);
            return Ok();
        }
        [HttpGet("{studentid}")]   
        public IActionResult SeeAStudent(int schoolid,int studentid)
        {
            return Ok(_studentRepository.GetStudent(schoolid,studentid));

        }
        [HttpGet]
        public IActionResult SeeAllStudents(int schoolid)
        {
            return Ok(_studentRepository.GetAllStudents(schoolid));

        }

        [HttpPut("{studentid}")]
        public IActionResult UpdateAStudent(int schoolid,int studentid,StudentDTO student)
        {
            _studentRepository.UpdateStudent(schoolid,studentid,student); return Ok();
        }


    }
}
