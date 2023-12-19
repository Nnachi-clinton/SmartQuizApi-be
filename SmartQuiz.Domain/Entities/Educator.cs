using SmartQuiz.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class Educator : BaseEntity
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string State { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    public ICollection<Quiz> Quizzes { get; set; }
}
