using Oprazi.Bll.Services.IServices;
using Oprazi.Dal.Repositories.IRepositories;
using Oprazi.Dto.DTOs;
using Oprazi.Entity.Entities;
using Oprazi.Entity.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace Oprazi.Bll.Services
{
    public class EmailConfigurationService : IEmailConfigurationService
    {
        private readonly IEmailConfigurationRepository _emailConfigurationRepository;
        private readonly IMapper _mapper;

        public EmailConfigurationService(IEmailConfigurationRepository emailConfigurationRepository, IMapper mapper)
        {
            _emailConfigurationRepository = emailConfigurationRepository;
            _mapper = mapper;
        }


        public async Task<EmailConfigurationToResponseDTO> GetEmailConfigurations(EmailConfigurationToFilterDTO filter)
        {
            return _mapper.Map<EmailConfigurationToResponseDTO>(await _emailConfigurationRepository.GetEmailConfigurationList(_mapper.Map<EmailConfigurationFilterModel>(filter)));
        }

        public async Task<EmailConfigurationDTO> GetEmailConfigurationById(int Id)
        {
            return _mapper.Map<EmailConfigurationDTO>(await _emailConfigurationRepository.GetByIdAsync(Id));
        }

        public async Task<EmailConfigurationDTO> AddEmailConfiguration(EmailConfigurationToAddDTO emailConfigurationToAddDto)
        {
            return _mapper.Map<EmailConfigurationDTO>(await _emailConfigurationRepository.Add(_mapper.Map<EmailConfiguration>(emailConfigurationToAddDto)));
        }

        public async Task UpdateEmailConfiguration(EmailConfigurationDTO emailConfigurationDTO)
        {
            await _emailConfigurationRepository.Update(_mapper.Map<EmailConfiguration>(emailConfigurationDTO));
        }
        public async Task DeleteEmailConfiguration(int Id)
        {
            await _emailConfigurationRepository.Delete(Id);
        }

        public async Task SendEmail(EmailDTO emailDTO)
        {
            var emailConfig = GetEmailConfigurations(new EmailConfigurationToFilterDTO()).Result.Data.FirstOrDefault();
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.To.Add(emailDTO.EmailAddress);
            mail.From = new MailAddress(emailConfig.From, emailDTO.Title, System.Text.Encoding.UTF8);
            mail.Subject = emailDTO.Title;
            mail.Body = emailDTO.Message;
            mail.IsBodyHtml = true;
            SmtpClient smp = new SmtpClient();
            smp.Credentials = new NetworkCredential(emailConfig.UserName, emailConfig.Password);
            smp.Port = 587;
            smp.Host = emailConfig.SmtpServer;
            smp.EnableSsl = false;
            smp.Send(mail);
        }



    }
}
