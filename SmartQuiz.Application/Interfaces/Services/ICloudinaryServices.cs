using Microsoft.AspNetCore.Http;

namespace SmartQuiz.Application.Interfaces.Services
{
    public interface ICloudinaryServices<T> where T : class
    {
        Task<string> UploadImage(string entityId, IFormFile file);
    }
}