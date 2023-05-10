using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oprazi.Dto.DTOs;

namespace Oprazi.Bll.Services.IServices
{
    public interface IEmailConfigurationService
    {
        Task<EmailConfigurationToResponseDTO> GetEmailConfigurations(EmailConfigurationToFilterDTO filter);
        Task<EmailConfigurationDTO> GetEmailConfigurationById(int Id);
        Task<EmailConfigurationDTO> AddEmailConfiguration(EmailConfigurationToAddDTO emailConfigurationToAddDTO);
        Task UpdateEmailConfiguration(EmailConfigurationDTO emailConfigurationDTO);
        Task DeleteEmailConfiguration(int Id);
        Task SendEmail(EmailDTO emailDTO);
    }
}
