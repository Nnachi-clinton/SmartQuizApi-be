using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SmartQuiz.Application.Interfaces.Services;
using SmartQuiz.Domain;
using SmartQuiz.Domain.Entities;

namespace SmartQuiz.Application.ServicesImplementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<Student> _userManager;
        private readonly SignInManager<Student> _signInManager;
        private readonly ILogger<AuthenticationService> _logger;

        public AuthenticationService(UserManager<Student> userManager, SignInManager<Student> signInManager, ILogger<AuthenticationService> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<ApiResponse<string>> ChangePasswordAsync(Student student, string currentPassword, string newPassword)
        {
            try
            {
                var result = await _userManager.ChangePasswordAsync(student, currentPassword, newPassword);

                if (result.Succeeded)
                {
                    return new ApiResponse<string>(true, "Password changed successfully.", 200, null, new List<string>());
                }
                else
                {
                    return new ApiResponse<string>(false, "Password change failed.", 400, null, result.Errors.Select(error => error.Description).ToList());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while changing password");
                var errorList = new List<string> { ex.Message };
                return new ApiResponse<string>(true, "Error occurred while changing password", 500, null, errorList);
            }
        }

        public ApiResponse<string> ExtractUserIdFromToken(string authToken)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<string>> ForgotPasswordAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<string>> ResetPasswordAsync(string email, string token, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<string>> ValidateTokenAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}
