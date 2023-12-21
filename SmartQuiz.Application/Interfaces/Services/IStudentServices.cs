using SmartQuiz.Application.DTO;
using SmartQuiz.Domain;

namespace SmartQuiz.Application.Interfaces.Services
{
    public interface IStudentServices
    {
        List<StudentDto> GetAllStudents();
        ApiResponse<StudentDto> GetStudentByIdAsync(string studentId);
        ApiResponse<bool> UpdateStudentAsync(string studentId, UpdateStudentDto updateStudentDto);
        Task<ApiResponse<StudentDto>> DeleteStudentAsync(string studentId);
    }
}
