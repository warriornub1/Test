using AutoMapper;
using CollegeApp.Data;
using CollegeApp.Data.Repository;
using CollegeApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Xml.Linq;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "LoginForLocalUsers", Roles = "Superadmin,Admin")]
    public class StudentController : ControllerBase
    {

        private readonly ILogger<DemoController> _logger;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        public StudentController(ILogger<DemoController> logger, IMapper mapper, IStudentRepository studentRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("All", Name = "GetAllStudents")]
        //[AllowAnonymous]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
        {
            _logger.LogInformation("GetStudents method started");
            var students = _studentRepository.GetAllAsync();
            var studentDTOData = _mapper.Map<List<StudentDTO>>(students);
            return Ok(studentDTOData);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<StudentDTO>> GetStudentById(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Bad Request");
                return BadRequest();
            }

            var student = await _studentRepository.GetByIdAsync(x => x.Id == id);
            if (student == null)
            {
                _logger.LogError("student not found with given Id");
                return NotFound($"The student with id {id} not found.");
            }

            var studentDTO = _mapper.Map<StudentDTO>(student);

            return Ok(studentDTO);
        }


        [HttpGet]
        [Route("{Name:alpha}", Name = "GetStudentByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<StudentDTO>> GetStudentByName(string Name)
        {
            if(string.IsNullOrEmpty(Name))
                return BadRequest();

            var student = await _studentRepository.GetByNameAsync(x => x.StudentName == Name);
            
            if(student == null)
                return NotFound($"The student with name {Name} not found.");

            var studentDTO = _mapper.Map<StudentDTO>(student);

            return Ok(studentDTO);
        }


        [HttpDelete("{id:min(1):max(100)}", Name = "DeleteStudentById")]
        // api/student/delete/1
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var student = await _studentRepository.GetByIdAsync(x => x.Id == id);

            if (student == null)
                return NotFound($"The student with id {id} not found.");


            await _studentRepository.DeleteAsync(student);
            return Ok(student);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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

            var student1 = _mapper.Map<Student>(model);
            var id = await _studentRepository.CreateAsync(student1);

            // Status - 201
            // api/Student/3

            return CreatedAtRoute("GetStudentById", model);
        }

        [HttpPut]
        [Route("Update")]
        // api/student/update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> UpdateStudentAsync([FromBody] StudentDTO model)
        {
            if (model == null || model.Id <= 0)
                BadRequest();

            //var existingStudent = await _dbContext.Students.AsNoTracking().Where(x => x.Id == model.Id).FirstOrDefaultAsync();

            var existingStudent = await _studentRepository.GetByIdAsync(x => x.Id == model.Id, true);
            if (existingStudent == null)
                return NotFound();


            var newRecord = _mapper.Map<Student>(model);

            await _studentRepository.UpdateAsync(newRecord);
            return NoContent();
        }

        [HttpPatch]
        [Route("{id:int}/UpdatePartial")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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

            var existingStudent = await _studentRepository.GetByIdAsync(x => x.Id == id, true);

            if (existingStudent == null)
                return NotFound();

            var studentDTO1 = _mapper.Map<StudentDTO>(existingStudent);
            patchDocument.ApplyTo(studentDTO1, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            existingStudent = _mapper.Map<Student>(studentDTO1);

            await _studentRepository.UpdateAsync(existingStudent);
            return NoContent();
        }

    }
}
