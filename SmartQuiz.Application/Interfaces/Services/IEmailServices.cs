using SmartQuiz.Domain.Entities;

namespace SmartQuiz.Application.Interfaces.Services
{
    public interface IEmailServices
    {
        //Task SendEmailAsync(MailRequest mailRequest);
        Task SendHtmlEmailAsync(MailRequest request);
    }
}
