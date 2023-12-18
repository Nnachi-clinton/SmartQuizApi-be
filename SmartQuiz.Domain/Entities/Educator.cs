using SmartQuiz.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class Educator : BaseEntity
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string State { get; set; }
    public string Gender { get; set; }
    public string ImageUrl { get; set; }
    public ICollection<Quiz> Quizzes { get; set; }
}
