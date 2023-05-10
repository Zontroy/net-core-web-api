using Oprazi.Entity.Entities;
using Oprazi.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oprazi.Dal.Repositories.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<UserResponseModel> GetUserList(UserFilterModel filter);

        Task<UserProfileModel> GetUserProfileByEmail(string email, string currentRole = null);
    }
}
