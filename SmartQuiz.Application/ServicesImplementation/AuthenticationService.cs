using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartQuiz.Application.Interfaces.Services;
using SmartQuiz.Domain;
using SmartQuiz.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SmartQuiz.Application.ServicesImplementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<Student> _userManager;
        private readonly SignInManager<Student> _signInManager;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IConfiguration _config;
        //private readonly IOptions<EmailSettings> _emailSettings;
        //private readonly EmailServices _emailServices;

        public AuthenticationService(UserManager<Student> userManager, SignInManager<Student> signInManager, ILogger<AuthenticationService> logger, IOptions<EmailSettings> emailSettings, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _config = config;
            //_emailSettings = emailSettings.Value;
            // _emailServices = new EmailServices(emailSettings);
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
            try
            {
                var token = authToken.Replace("Bearer ", "");

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                var userId = jsonToken?.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sub)?.Value;

                if (string.IsNullOrWhiteSpace(userId))
                {
                    return new ApiResponse<string>(false, "Invalid or expired token.", 401, null, new List<string>());
                }

                return new ApiResponse<string>(true, "User ID extracted successfully.", 200, userId, new List<string>());
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>(false, "Error extracting user ID from token.", 500, null, new List<string> { ex.Message });
            }
        }

        //public async Task<ApiResponse<string>> ForgotPasswordAsync(string email)
        //{
        //    try
        //    {
        //        var student = await _userManager.FindByEmailAsync(email);

        //        if (student == null)
        //        {
        //            return new ApiResponse<string>(false, "User not found or email not confirmed.", StatusCodes.Status404NotFound, null, new List<string>());
        //        }
        //        string token = await _userManager.GeneratePasswordResetTokenAsync(student);

        //        student.PasswordResetToken = token;
        //        student.ResetTokenExpires = DateTime.UtcNow.AddHours(24);

        //        await _userManager.UpdateAsync(student);

        //        var resetPasswordUrl = "http://localhost:3000/reset-password?email=" + Uri.EscapeDataString(email) + "&token=" + Uri.EscapeDataString(token);

        //        var mailRequest = new MailRequest
        //        {
        //            ToEmail = email,
        //            Subject = "TicketEase Password Reset Instructions",
        //            Body = $"Please reset your password by clicking <a href='{resetPasswordUrl}'>here</a>."
        //        };
        //        await _emailServices.SendHtmlEmailAsync(mailRequest);

        //        return new ApiResponse<string>(true, "Password reset email sent successfully.", 200, null, new List<string>());
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error occurred while resolving password change");
        //        var errorList = new List<string>();
        //        errorList.Add(ex.Message);
        //        return new ApiResponse<string>(true, "Error occurred while resolving password change", 500, null, errorList);
        //    }
        //}

        public async Task<ApiResponse<string>> ResetPasswordAsync(string email, string token, string newPassword)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    return new ApiResponse<string>(false, "User not found.", 404, null, new List<string>());
                }
                var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

                if (result.Succeeded)
                {
                    user.PasswordResetToken = null;
                    user.ResetTokenExpires = null;

                    await _userManager.UpdateAsync(user);

                    return new ApiResponse<string>(true, "Password reset successful.", 200, null, new List<string>());
                }
                else
                {
                    return new ApiResponse<string>(false, "Password reset failed.", 400, null, result.Errors.Select(error => error.Description).ToList());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while resetting password");
                var errorList = new List<string> { ex.Message };
                return new ApiResponse<string>(true, "Error occurred while resetting password", 500, null, errorList);
            }
        }

        public  ApiResponse<string> ValidateTokenAsync(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_config.GetSection("JwtSettings:Secret").Value);

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = null,
                    ValidAudience = null,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                SecurityToken securityToken;
                var principal =  tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                var emailClaim = principal.FindFirst(JwtRegisteredClaimNames.Email)?.Value;

                return new ApiResponse<string>(true, "Token is valid.", 200, null, new List<string>());
            }
            catch (SecurityTokenException ex)
            {
                _logger.LogError(ex, "Token validation failed");
                var errorList = new List<string> { ex.Message };
                return new ApiResponse<string>(false, "Token validation failed.", 400, null, errorList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during token validation");
                var errorList = new List<string> { ex.Message };
                return new ApiResponse<string>(false, "Error occurred during token validation", 500, null, errorList);
            }
        }
    }
}
