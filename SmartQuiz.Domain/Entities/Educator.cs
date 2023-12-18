using System.ComponentModel.DataAnnotations;

namespace SmartQuiz.Domain.Entities
{
    public class Educator
    {
        [Key]
        public int EducatorId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        // Identity-related properties
        public string UserName { get; set; }

        // Navigation property
        public ICollection<Quiz> Quizzes { get; set; }
    }
}
