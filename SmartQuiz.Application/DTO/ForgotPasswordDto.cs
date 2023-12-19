using System.ComponentModel.DataAnnotations;

namespace SmartQuiz.Application.DTO
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
