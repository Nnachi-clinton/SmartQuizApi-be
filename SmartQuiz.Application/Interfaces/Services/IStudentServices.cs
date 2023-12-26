using Microsoft.AspNetCore.Http;
using SmartQuiz.Application.DTO;
using SmartQuiz.Domain;

namespace SmartQuiz.Application.Interfaces.Services
{
    public interface IStudentServices
    {
        List<StudentDto> GetAllStudents();
        ApiResponse<StudentDto> GetStudentByIdAsync(string studentId);
        Task<ApiResponse<bool>> UpdateStudentAsync(string studentId, UpdateStudentDto updateStudentDto);
        Task<ApiResponse<StudentDto>> DeleteStudentAsync(string studentId);
        Task<ApiResponse<bool>> UpdateStudentProfilePhoto(string studentId, UpdatePhotoDto photo);
    }
}
