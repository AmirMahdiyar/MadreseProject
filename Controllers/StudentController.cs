using MadreseV6.Domain.StudentAggregate.StudentAggregate;
using MadreseV6.DTOs;
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
        public async Task<IActionResult> AddAStudent(int schoolid,int gradeid,StudentDTO student)
        {
            await _studentRepository.AddStudentAsync(schoolid,gradeid,student);
            return Ok();
        }
        [HttpDelete("{studentid}")]
        public async Task<IActionResult> DeleteAStudent(int schoolid,int studentid)
        {
            await _studentRepository.RemoveStudentAsync(schoolid, studentid);
            return Ok();
        }
        [HttpGet("{studentid}")]   
        public async Task<IActionResult> SeeAStudent(int schoolid,int studentid)
        {
            return Ok(await _studentRepository.GetStudentAsync(schoolid, studentid));

        }
        [HttpGet]
        public async Task<IActionResult> SeeAllStudents(int schoolid)
        {
            return Ok(await _studentRepository.GetAllStudentsAsync(schoolid));

        }

        [HttpPut("{studentid}")]
        public async Task<IActionResult> UpdateAStudent(int schoolid,int studentid,StudentDTO student)
        {
            await _studentRepository.UpdateStudentAsync(schoolid, studentid, student); return Ok();
        }


    }
}
