using Oprazi.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Oprazi.Entity.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Oprazi.Dal.Repositories.IRepositories
{
    public interface IRoleClaimRepository : IGenericRepository<RoleClaim>
    {
        Task<RoleClaimResponseModel> GetRoleClaimList(RoleClaimFilterModel filter);

        Task<RoleClaimResponseModel> GetRoleClaimListByRole(List<int> roleIds);

        Task<RoleClaim> GetRoleClaimById(int Id);
    }
}
