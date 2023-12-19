using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SmartQuiz.Domain.Entities
{
    public class Student : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public string VerificationToken { get; set; }
        public string PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
    }
}
