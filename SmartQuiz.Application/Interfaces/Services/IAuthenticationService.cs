using SmartQuiz.Domain.Entities;
using SmartQuiz.Domain;
using SmartQuiz.Application.DTO;

namespace SmartQuiz.Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<ApiResponse<string>> RegisterAsync(StudentDto studentDto);
        Task<ApiResponse<string>> LoginAsync(LoginDto loginDTO);
        Task<ApiResponse<string>> ForgotPasswordAsync(string email);
        Task<ApiResponse<string>> ResetPasswordAsync(string email, string token, string newPassword);
        ApiResponse<string> ValidateTokenAsync(string token);
        ApiResponse<string> ExtractUserIdFromToken(string authToken);
        Task<ApiResponse<string>> ChangePasswordAsync(Student student, string currentPassword, string newPassword);
    }
}
