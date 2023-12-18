using System.ComponentModel.DataAnnotations;

namespace SmartQuiz.Domain.Entities
{
    public class Quiz
    {
        [Key]
        public string QuizID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsPublic { get; set; }

        public bool HasTimeLimit { get; set; }

        public int TimeLimitMinutes { get; set; }

        public int MaxAttempts { get; set; }

        // Media integration
        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }

        // Navigation properties
        public int EducatorId { get; set; }
        public Educator Educator { get; set; }

        //public ICollection<Question> Questions { get; set; }

    }
}
