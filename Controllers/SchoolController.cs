using MadreseV6.Domain.SchoolAggregate;
using MadreseV6.Domain.SchoolAggregate.SchoolContracts;
using MadreseV6.DTOs;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult AddAStudent([FromBody] SchoolDTO school)
        {
            _schoolRepository.AddSchool(school);
            return Ok();
        }
        [HttpDelete("{schoolid}")]
        public IActionResult DeleteSchool(int schoolid)
        {
            _schoolRepository.RemoveSchool(schoolid);
            return Ok();
        }
        [HttpGet]
        public IActionResult SeeAllSchools()
        {
            return Ok(_schoolRepository.GetAllSchools());
        }
        [HttpGet("{schoolid}")]
        public IActionResult SeeASchool(int schoolid)
        {
            return Ok(_schoolRepository.GetSchool(schoolid));
        }
        [HttpPut("{schoolid}")]
        public IActionResult UpdateASchool(int schoolid, [FromBody] SchoolDTO school)
        {
            _schoolRepository.UpdateSchool(schoolid, school);
            return Ok();
        }




        [HttpPost("{schoolid}/Grades")]
        public IActionResult AddAGrade(int schoolid , GradeDTO gradeDTO)
        {
            _gradeRepository.AddGrade(schoolid, gradeDTO);
            return Ok();
        }
        [HttpDelete("{schoolid}/Grades/{gradeid}")]
        public IActionResult DeleteGrade(int schoolid,int gradeid)
        {
            _gradeRepository.RemoveGrade(schoolid, gradeid);
            return Ok();
        }
        [HttpGet("{schoolid}/Grades/{gradeid}")]
        public IActionResult SeeAGrade(int schoolid, int gradeid)
        {
            return Ok(_gradeRepository.GetGrade(schoolid, gradeid));
        }
        [HttpGet("{schoolid}/Grades")]
        public IActionResult SeeAllGrades(int schoolid)
        {
            return Ok(_gradeRepository.GetAllGrades(schoolid));
        }
        [HttpPut("{schoolid}/Grades/{gradeid}")]
        public IActionResult UpdateAGrade(int schoolid,int gradeid , GradeDTO grade)
        {
            _gradeRepository.UpdateGrade(schoolid ,gradeid,grade);
            return Ok();
        }





        [HttpPost("{schoolid}/Grades/{gradeid}/Courses")]
        public IActionResult AddACourse(int schoolid,int gradeid,CourseDTO course)
        {
            _courseRepository.AddCourse(schoolid,gradeid,course);
            return Ok();
        }
        [HttpDelete("{schoolid}/Grades/{gradeid}/Courses/{courseid}")]
        public IActionResult DeleteCourse(int schoolid,int gradeid,int courseid)
        {
            _courseRepository.RemoveCourse(schoolid, gradeid, courseid);
            return Ok();
        }
        [HttpGet("{schoolid}/Grades/{gradeid}/Courses/{courseid}")]
        public IActionResult SeeACourse(int schoolid,int gradeid,int courseid)
        {
            return Ok(_courseRepository.GetCourse(schoolid,gradeid,courseid));
        }
        [HttpGet("{schoolid}/Grades/{gradeid}/Courses")]
        public IActionResult SeeAllCourses(int schoolid,int gradeid)
        {
            return Ok(_courseRepository.GetAllCourses(schoolid,gradeid));
        }
        [HttpPut("{schoolid}/Grades/{gradeid}/Courses/{courseid}")]
        public IActionResult UpdateACourse(int schoolid,int gradeid,int courseid,CourseDTO course)
        {
            _courseRepository.UpdateCourse(schoolid,gradeid,courseid,course);
            return Ok();
        }



    }
}
