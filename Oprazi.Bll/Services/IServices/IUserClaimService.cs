using Oprazi.Dto.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oprazi.Bll.Services.IServices
{
    public interface IUserClaimService
    {
        Task<UserClaimToResponseDTO> GetUserClaims(UserClaimToFilterDTO filter);
        Task<UserClaimDTO> GetUserClaimById(int Id);
        Task<UserClaimDTO> AddUserClaim(UserClaimToAddDTO userclaimToAddDTO);
        Task UpdateUserClaim(UserClaimDTO userclaimDTO);
        Task DeleteUserClaim(int Id);
    }
}
