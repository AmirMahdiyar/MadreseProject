using MadreseV6.Domain.SchoolAggregate;
using MadreseV6.Domain.SchoolAggregate.SchoolContracts;
using MadreseV6.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MadreseV6.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SchoolController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IGradeRepository _gradeRepository;
        private readonly ICourseRepository _courseRepository;

        public SchoolController(ISchoolRepository schoolRepository, IGradeRepository gradeRepository, ICourseRepository courseRepository)
        {
            _schoolRepository = schoolRepository;
            _gradeRepository = gradeRepository;
            _courseRepository = courseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddASchool([FromBody] SchoolDTO school)
        {
            await _schoolRepository.AddSchoolAsync(school);
            return Ok();
        }
        [HttpDelete("{schoolid}")]
        public async Task<IActionResult> DeleteSchool(int schoolid)
        {
            await _schoolRepository.RemoveSchoolAsync(schoolid);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> SeeAllSchools()
        {
            var result = await _schoolRepository.GetAllSchoolsAsync();
            return Ok(result);
        }
        [HttpGet("{schoolid}")]
        public async Task<IActionResult> SeeASchool(int schoolid)
        {
            var result = await _schoolRepository.GetSchoolAsync(schoolid);
            return Ok(result);
        }
        [HttpPut("{schoolid}")]
        public async Task<IActionResult> UpdateASchool(int schoolid, [FromBody] SchoolDTO school)
        {
            await _schoolRepository.UpdateSchoolAsync(schoolid, school);
            return Ok();
        }




        [HttpPost("{schoolid}/Grades")]
        public async Task<IActionResult> AddAGrade(int schoolid , GradeDTO gradeDTO)
        {
            await _gradeRepository.AddGradeAsync(schoolid, gradeDTO);
            return Ok();
        }
        [HttpDelete("{schoolid}/Grades/{gradeid}")]
        public async Task<IActionResult> DeleteGrade(int schoolid,int gradeid)
        {
            await _gradeRepository.RemoveGradeAsync(schoolid, gradeid);
            return Ok();
        }
        [HttpGet("{schoolid}/Grades/{gradeid}")]
        public async Task<IActionResult> SeeAGrade(int schoolid, int gradeid)
        {
            return Ok(await _gradeRepository.GetGradeAsync(schoolid, gradeid));
        }
        [HttpGet("{schoolid}/Grades")]
        public async Task<IActionResult> SeeAllGrades(int schoolid)
        {
            return Ok(await _gradeRepository.GetAllGradesAsync(schoolid));
        }
        [HttpPut("{schoolid}/Grades/{gradeid}")]
        public async Task<IActionResult> UpdateAGrade(int schoolid,int gradeid , GradeDTO grade)
        {
            await _gradeRepository.UpdateGradeAsync(schoolid ,gradeid,grade);
            return Ok();
        }





        [HttpPost("{schoolid}/Grades/{gradeid}/Courses")]
        public async Task<IActionResult> AddACourse(int schoolid,int gradeid,CourseDTO course)
        {
            await _courseRepository.AddCourseAsync(schoolid,gradeid,course);
            return Ok();
        }
        [HttpDelete("{schoolid}/Grades/{gradeid}/Courses/{courseid}")]
        public async Task<IActionResult> DeleteCourse(int schoolid,int gradeid,int courseid)
        {
            await _courseRepository.RemoveCourseAsync(schoolid, gradeid, courseid);
            return Ok();
        }
        [HttpGet("{schoolid}/Grades/{gradeid}/Courses/{courseid}")]
        public async Task<IActionResult> SeeACourse(int schoolid,int gradeid,int courseid)
        {
            return Ok(await _courseRepository.GetCourseAsync(schoolid, gradeid, courseid));
        }
        [HttpGet("{schoolid}/Grades/{gradeid}/Courses")]
        public async Task<IActionResult> SeeAllCourses(int schoolid,int gradeid)
        {
            return Ok(await _courseRepository.GetAllCoursesAsync(schoolid, gradeid));
        }
        [HttpPut("{schoolid}/Grades/{gradeid}/Courses/{courseid}")]
        public async Task<IActionResult> UpdateACourse(int schoolid,int gradeid,int courseid,CourseDTO course)
        {
            await _courseRepository.UpdateCourseAsync(schoolid, gradeid, courseid, course);
            return Ok();
        }



    }
}
