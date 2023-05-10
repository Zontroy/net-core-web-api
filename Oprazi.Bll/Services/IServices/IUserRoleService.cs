using Oprazi.Dto.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oprazi.Bll.Services.IServices
{
    public interface IUserRoleService
    {
        Task<UserRoleToResponseDTO> GetUserRoles(UserRoleToFilterDTO filter);
        Task<UserRoleDTO> GetUserRoleById(int UserId, int RoleId);
        Task<UserRoleDTO> AddUserRole(UserRoleToAddDTO userroleToAddDTO);
        Task UpdateUserRole(UserRoleDTO userroleDTO);
        Task DeleteUserRole(int UserId, int RoleId);
    }
}
