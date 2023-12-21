using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartQuiz.Application.Interfaces.Services;
using SmartQuiz.Application.ServicesImplementation;
using SmartQuiz.Domain.Entities;
using SmartQuiz.Application.Interfaces.Repositories;
using SmartQuiz.Persistence.Context;
using SmartQuiz.Persistence.Repositories;

namespace SmartQuiz.Persistence.Extensions
{
    public static class DIServiceExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IEducatorServices, EducatorServices>();
            services.AddIdentity<Student, IdentityRole>()
            .AddEntityFrameworkStores<SmartQuizDbContext>()
            .AddDefaultTokenProviders();
            services.AddDbContext<SmartQuizDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
