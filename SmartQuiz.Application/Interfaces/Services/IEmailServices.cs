using SmartQuiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartQuiz.Application.Interfaces.Services
{
    public interface IEmailServices
    {
        //Task SendEmailAsync(MailRequest mailRequest);
        Task SendHtmlEmailAsync(MailRequest request);
    }
}
