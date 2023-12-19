using System.ComponentModel.DataAnnotations;

namespace SmartQuiz.Application.DTO
{
    public class ValidateTokenDto
    {
        [Required]
        public string Token { get; set; }
    }
}
