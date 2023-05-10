using Oprazi.Dto.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oprazi.Bll.Services.IServices
{
    public interface IUserLoginService
    {
        Task<UserLoginToResponseDTO> GetUserLogins(UserLoginToFilterDTO filter);
        Task<UserLoginDTO> GetUserLoginById(int Id);
        Task<UserLoginDTO> AddUserLogin(UserLoginToAddDTO userloginToAddDTO);
        Task UpdateUserLogin(UserLoginDTO userloginDTO);
        Task DeleteUserLogin(int Id);
    }
}
