using Oprazi.Dto.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oprazi.Bll.Services.IServices
{
    public interface IRoleClaimService
    {
        Task<RoleClaimToResponseDTO> GetRoleClaims(RoleClaimToFilterDTO filter);
        Task<RoleClaimToResponseDTO> GetRoleClaimsByRole(List<int> RoleIds);
        Task<RoleClaimDTO> GetRoleClaimById(int Id);
        Task<RoleClaimDTO> AddRoleClaim(RoleClaimToAddDTO roleclaimToAddDTO);
        Task UpdateRoleClaim(RoleClaimDTO roleclaimDTO);
        Task DeleteRoleClaim(int Id);
    }
}
