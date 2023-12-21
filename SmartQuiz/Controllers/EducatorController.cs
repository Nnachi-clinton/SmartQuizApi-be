using Microsoft.AspNetCore.Mvc;
using SmartQuiz.Application.Interfaces.Services;

namespace SmartQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducatorController : ControllerBase
    {
        private readonly IEducatorServices _services;
       
        public EducatorController(IEducatorServices services, IQuizServices quizServices, ILogger logger)
        {
            _services = services;
            
        }

        [HttpGet("GetById")]

        public IActionResult GetQuizzesByEducatorId(string id)
        {
            var response = _services.GetQuizzesByEducatorId(id);
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
        [HttpDelete("Delete")]
        public IActionResult Delete(string quizId)
        {
            var isDeleted = _services.DeleteQuiz(quizId);
            return Ok(isDeleted);
        }

    }
}
