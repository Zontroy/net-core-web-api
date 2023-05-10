using Oprazi.Dto.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oprazi.Bll.Services.IServices
{
    public interface IUserTokenService
    {
        Task<UserTokenToResponseDTO> GetUserTokens(UserTokenToFilterDTO filter);
        Task<UserTokenDTO> GetUserTokenById(int Id);
        Task<UserTokenDTO> AddUserToken(UserTokenToAddDTO usertokenToAddDTO);
        Task UpdateUserToken(UserTokenDTO usertokenDTO);
        Task DeleteUserToken(int Id);
    }
}
