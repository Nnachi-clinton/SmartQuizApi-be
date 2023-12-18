using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartQuiz.Application.Interfaces.Services
{
    public interface ICloudinaryServices<T> where T : class
    {
        Task<string> UploadImage(string entityId, IFormFile file);
    }
}