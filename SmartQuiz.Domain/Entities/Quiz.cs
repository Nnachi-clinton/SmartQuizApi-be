using System.ComponentModel.DataAnnotations;

namespace SmartQuiz.Domain.Entities
{
    public class Quiz : BaseEntity
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public bool HasTimeLimit { get; set; }
        public int TimeLimitMinutes { get; set; }
        public int MaxAttempts { get; set; }
        public int Score { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string EducatorId { get; set; }
        public Educator Educator { get; set; }
    }
}
