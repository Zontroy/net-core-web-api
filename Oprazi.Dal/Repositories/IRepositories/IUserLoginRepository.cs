using Oprazi.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Oprazi.Entity.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Oprazi.Dal.Repositories.IRepositories
{
    public interface IUserLoginRepository : IGenericRepository<UserLogin>
    {
        Task<UserLoginResponseModel> GetUserLoginList(UserLoginFilterModel filter);
        Task<UserLogin> GetUserLoginById(int Id);
    }
}
