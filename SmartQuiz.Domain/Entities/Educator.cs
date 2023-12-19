using System.ComponentModel.DataAnnotations;

namespace SmartQuiz.Domain.Entities
{

    public class Educator : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
    }
}
