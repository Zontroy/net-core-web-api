using Oprazi.Dto.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oprazi.Utility.EmailService
{
    public interface IEmailSender
    {
        void SendEmail(EmailMessage message, EmailConfigurationDTO _emailConfig);
        Task SendEmailAsync(EmailMessage message, EmailConfigurationDTO _emailConfig);
    }
}
