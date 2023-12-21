using SmartQuiz.Application.DTO;
using SmartQuiz.Domain;

namespace SmartQuiz.Application.Interfaces.Services
{
    public interface IStudentServices
    {
        List<StudentDto> GetAllStudents();
        Task<ApiResponse<StudentDto>> GetStudentByIdAsync(string studentId);
        Task<ApiResponse<StudentDto>> UpdateStudentAsync(string studentId, UpdateStudentDto updateStudentDto);
        Task<ApiResponse<StudentDto>> DeleteStudentAsync(string studentId);
    }
}
