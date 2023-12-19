using Microsoft.AspNetCore.Identity;
using SmartQuiz.Application.Interfaces.Services;
using SmartQuiz.Domain.Entities;

namespace SmartQuiz.Application.ServicesImplementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<Student> _userManager;
        private readonly SignInManager<Student> _signInManager;

        public AuthenticationService(UserManager<Student> userManager, SignInManager<Student> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
    }
}
