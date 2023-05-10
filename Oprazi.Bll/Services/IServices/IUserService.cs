using Oprazi.Dto.DTOs;
using Oprazi.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oprazi.Bll.Services.IServices
{
    public interface IUserService
    {
        Task<UserToListDTO> GetUserById(int Id);
        Task<UserToListDTO> GetUserByAuth(string email, string password);
        Task<UserToListDTO> GetUserByEmail(string email);
        Task<UserProfileToListDTO> GetUserProfileByEmail(string email, string currentRole = null);
        Task<string> GetResetToken(string email);
        Task<bool> ResetPassword(string email, string token, string password);
        Task<bool> ForgotPassword(ForgotPasswordModel forgotPasswordModel);
        Task DeleteUser(int Id);
        Task UpdateUser(UserToListDTO userDTO);

        Task<UserToResponseDTO> GetUsers(UserToFilterDTO filter);
        Task<UserDTO> AddUser(UserToAddDTO userToAddDTO);
        Task<UserToListDTO> RegisterUser(UserToRegisterDTO userToRegisterDTO);
    }
}
