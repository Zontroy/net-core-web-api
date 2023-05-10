using Oprazi.Dto.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oprazi.Bll.Services.IServices
{
    public interface IRoleService
    {
        Task<RoleToResponseDTO> GetRoles(RoleToFilterDTO filter);
        Task<RoleDTO> GetRoleById(int Id);
        Task<RoleDTO> AddRole(RoleToAddDTO roleToAddDTO);
        Task UpdateRole(RoleDTO roleDTO);
        Task DeleteRole(int Id);
    }
}
