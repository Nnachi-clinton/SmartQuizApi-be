using SmartQuiz.Domain.Entities;
using SmartQuiz.Domain;

namespace SmartQuiz.Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
       // Task<ApiResponse<string>> ForgotPasswordAsync(string email);
        Task<ApiResponse<string>> ResetPasswordAsync(string email, string token, string newPassword);
        ApiResponse<string> ValidateTokenAsync(string token);
        ApiResponse<string> ExtractUserIdFromToken(string authToken);
        Task<ApiResponse<string>> ChangePasswordAsync(Student student, string currentPassword, string newPassword);
    }
}
