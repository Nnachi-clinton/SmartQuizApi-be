using Microsoft.AspNetCore.Mvc;
using SmartQuiz.Application.Interfaces.Services;
using SmartQuiz.Application.ServicesImplementation;
using SmartQuiz.Domain.Entities;
using System.Reflection;

namespace SmartQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducatorController : ControllerBase
    {
        private readonly IEducatorServices _services;
        private readonly IQuizServices _quizServices;
        private readonly ILogger _logger;

        public EducatorController(IEducatorServices services, IQuizServices quizServices, ILogger logger)
        {
            _services = services;
            _quizServices = quizServices;
            _logger = logger;
        }

        [HttpGet("GetById")]

        public  IActionResult GetQuizzesByEducatorId(string id)
        {
            var response =  _services.GetQuizzesByEducatorId(id); 
            return Ok(response);
        }

        [HttpGet("GetQuizDetails")]
        public IActionResult GetQuizDetails(string id) 
        { 
            var quiz = _services.GetQuizDetails(id);
            
            {
                //id = quiz.Id
                //QuizName = quiz.Title, // Map Title to QuizName in the ViewModel
                //Description = quiz.Description,
                
            };
            return Ok(quiz);
        }

        public IActionResult Delete(string quizId)
        {
            var isDeleted = _services.DeleteQuiz(quizId);
            return Ok(isDeleted);
        }

    }
}
