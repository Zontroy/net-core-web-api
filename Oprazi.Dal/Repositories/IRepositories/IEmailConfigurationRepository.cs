using Oprazi.Dto.DTOs;
using Oprazi.Entity.Entities;
using Oprazi.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oprazi.Dal.Repositories.IRepositories
{
    public interface IEmailConfigurationRepository : IGenericRepository<EmailConfiguration>
    {

        Task<EmailConfigurationResponseModel> GetEmailConfigurationList(EmailConfigurationFilterModel filter);
    }

}
