using Microsoft.AspNetCore.Mvc;
using SmartQuiz.Application.DTO;
using SmartQuiz.Application.Interfaces.Services;
using SmartQuiz.Domain;

namespace SmartQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;
        private readonly ILogger<StudentController> _logger;              

        public StudentController(IStudentServices studentServices, ILogger<StudentController> logger)
        {
            _studentServices = studentServices;
            _logger = logger;
        }

        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            var response = _studentServices;
            return Ok(response);
        }

        [HttpGet("{StudentId}")]
        public IActionResult GetStudentById(string studentId)
        {
            var response = _studentServices.GetStudentByIdAsync(studentId);
            if (response.Succeeded)
            {
                return Ok(response.Data);
            }
            return StatusCode(response.StatusCode, new {errors = response.Errors});
        }

        [HttpPut("UpdateStudent/{id}")]
        public IActionResult UpdateStudent(string studentId, [FromBody] UpdateStudentDto updateStudentDto)
        {
            var updateStudent = _studentServices.UpdateStudentAsync(studentId, updateStudentDto);
            if (updateStudent.Succeeded)
            {
                return Ok(new ApiResponse<bool>(true, "Student updated successfully.", 200, true, null));
            }
            _logger.LogError("Student update failed: {Message}", updateStudent.Message);
            return BadRequest(new ApiResponse<bool>(false, "Failed to update student.", 400, false, updateStudent.Errors));
        }

        [HttpDelete("DeleteStudentById")]
        public async Task<IActionResult> DeleteStudentById(string id)
        {
            return Ok(await _studentServices.DeleteStudentAsync(id));
        }
    }
}
