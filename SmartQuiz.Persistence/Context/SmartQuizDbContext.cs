using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartQuiz.Domain.Entities;

namespace SmartQuiz.Persistence.Context
{
    public class SmartQuizDbContext : IdentityDbContext<Student>
    {
        public SmartQuizDbContext(DbContextOptions<SmartQuizDbContext> options) : base(options) { }

        public DbSet<Educator> Educators { get; set; }
        public DbSet<Quiz> Quizs { get; set; }
    }
}
