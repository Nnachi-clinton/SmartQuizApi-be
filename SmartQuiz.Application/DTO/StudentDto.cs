using System.ComponentModel.DataAnnotations;

namespace SmartQuiz.Application.DTO
{
    public class StudentDto
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        public string Address { get; set; }
        public string State { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
    }
}
