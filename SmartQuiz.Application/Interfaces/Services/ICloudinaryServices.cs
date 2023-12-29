using Microsoft.AspNetCore.Http;

namespace SmartQuiz.Application.Interfaces.Services
{
    public interface ICloudinaryServices<T> where T : class
    {
        Task<string> UploadImageAsync(string entityId, IFormFile file);
    }
}