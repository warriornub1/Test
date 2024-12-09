using CollegeApp.Data;
using CollegeApp.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly ILogger<DemoController> _logger;
        private readonly CollegeDBContext _dbContext;
        public StudentController(ILogger<DemoController> logger, CollegeDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("All", Name = "GetAllStudents")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
        {
            _logger.LogInformation("GetStudents method started");

            var students = await _dbContext.Students.ToListAsync();

            //var students = _dbContext.Students.Select(s => new StudentDTO()
            //{
            //    Id = s.Id,
            //    StudentName = s.StudentName,
            //    Address = s.Address,
            //    Email = s.Email,
            //}).ToList();
            return Ok(students);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentDTO>> GetStudentById(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Bad Request");
                return BadRequest();
            }

            var student = await _dbContext.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (student == null)
            {
                _logger.LogError("student not found with given Id");
                return NotFound($"The student with id {id} not found.");
            }

            var studentDTO = new StudentDTO
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Email = student.Email,
                Address = student.Address,
            };

            return Ok(studentDTO);
        }


        [HttpGet]
        [Route("{Name:alpha}", Name = "GetStudentByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentDTO>> GetStudentByName(string Name)
        {
            if(string.IsNullOrEmpty(Name))
                return BadRequest();

            var student = await _dbContext.Students.Where(x => x.StudentName == Name).FirstOrDefaultAsync();
            
            if(student == null)
                return NotFound($"The student with name {Name} not found.");

            var studentDTO = new StudentDTO
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Email = student.Email,
                Address = student.Address,
            };

            return Ok(studentDTO);
        }


        [HttpDelete("{id:min(1):max(100)}", Name = "DeleteStudentById")]
        // api/student/delete/1
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var student = await _dbContext.Students.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (student == null)
                return NotFound($"The student with id {id} not found.");


            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();

            return Ok(student);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // api/student/create
        public async Task<ActionResult<StudentDTO>> CreateStudent([FromBody] StudentDTO model)
        {
            // if [ApiController] is commented out, validatio can still be done.
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model == null)
                return BadRequest();

            if(model.AdmissionDate < DateTime.Now)
            {
                // 1. Directly adding error message to modelstate
                // 2. Using cusomt attribute
                ModelState.AddModelError("AdmissionDate error", "Addmission date must be greate than or equal to todays data.");
                return BadRequest(ModelState);
            }

            Student student = new Student
            {
                StudentName = model.StudentName,
                Address = model.Address,
                Email = model.Email,
            };
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();

            model.Id = student.Id;

            // Status - 201
            // api/Student/3

            return CreatedAtRoute("GetStudentById", new { id = model.Id }, model);
        }

        [HttpPut]
        [Route("Update")]
        // api/student/update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> UpdateStudentAsync([FromBody] StudentDTO model)
        {
            if (model == null || model.Id <= 0)
                BadRequest();

            var existingStudent = await _dbContext.Students.AsNoTracking().Where(x => x.Id == model.Id).FirstOrDefaultAsync();

            if(existingStudent == null)
                return NotFound();

            //existingStudent.StudentName = model.StudentName;
            //existingStudent.Email = model.Email;
            //existingStudent.Address = model.Address;

            var newRecord = new Student()
            {
                Id = existingStudent.Id,
                StudentName = existingStudent.StudentName,
                Email = existingStudent.Email,
                Address = existingStudent.Address
            };

            _dbContext.Students.Update(newRecord);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch]
        [Route("{id:int}/UpdatePartial")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        /*
         [
          {
            "path": "/studentName",
            "op": "replace",
            "value": "Anil New"
          }
        ]
         */

        public async Task<ActionResult> UpdateStudentPartialAsync(int id, [FromBody] JsonPatchDocument<StudentDTO> patchDocument)
        {
            if (patchDocument == null || id <= 0)
                return BadRequest();

            var existingStudent = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (existingStudent == null)
                return NotFound();

            var studentDTO = new StudentDTO
            {
                Id = existingStudent.Id,
                StudentName = existingStudent.StudentName,
                Email = existingStudent.Email,
                Address = existingStudent.Address,
            };

            patchDocument.ApplyTo(studentDTO, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            existingStudent.StudentName = studentDTO.StudentName;
            existingStudent.Email = studentDTO.Email;
            existingStudent.Address = studentDTO.Address;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
