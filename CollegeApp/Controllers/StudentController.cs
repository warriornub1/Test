using CollegeApp.Model;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("All", Name = "GetAllStudents")]
        public ActionResult<IEnumerable<Student>> GetStudentName()
        {
            return Ok(CollegeRepository.Students);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetStudentsById")]
        public ActionResult<Student> GetStudentById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var student = CollegeRepository.Students.Where(x => x.Id == id).FirstOrDefault();
            if (student == null)
                return NotFound($"The student with id {id} not found.");

            return Ok(student);
        }


        [HttpGet]
        [Route("{Name:alpha}", Name = "GetStudentByName")]
        public ActionResult<Student> GetStudentByName(string Name)
        {
            if(string.IsNullOrEmpty(Name))
                return BadRequest();

            var student = CollegeRepository.Students.Where(x => x.StudentName == Name).FirstOrDefault();
            
            if(student == null)
                return NotFound($"The student with name {Name} not found.");

            return Ok(student) ;
        }


        [HttpDelete("{id:min(1):max(100)}", Name = "DeleteStudentById")]
        public ActionResult DeleteStudent(int id)
        {
            var student = CollegeRepository.Students.Where(x => x.Id == id).FirstOrDefault();

            if (student == null)
                return NotFound($"The student with id {id} not found.");


            CollegeRepository.Students.Remove(student);

            return Ok(student);
        }
    }
}
