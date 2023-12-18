using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartQuiz.Persistence.Context;

namespace SmartQuiz.Persistence.Extensions
{
    public static class DIServiceExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<SmartQuizDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        }
    }
}
