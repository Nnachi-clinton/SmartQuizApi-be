using Microsoft.AspNetCore.Http;

namespace SmartQuiz.Application.DTO
{
    public class UpdatePhotoDto
    {
       public IFormFile Formfile {  get; set; }
    }
}
