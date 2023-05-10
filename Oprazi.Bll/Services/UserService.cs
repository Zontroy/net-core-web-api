using Oprazi.Bll.Services.IServices;
using Oprazi.Dal.Repositories.IRepositories;
using Oprazi.Dto.DTOs;
using Oprazi.Entity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using Oprazi.Entity.Models;
using System.Transactions;
using System.Web;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.ObjectPool;

namespace Oprazi.Bll.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUserRoleService _userRoleService;
        private readonly IRoleService _roleService;
        private readonly IEmailConfigurationService _emailConfigurationService;
        public UserService(IUserRepository userRepository,
            IMapper mapper,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IUserRoleService userRoleService,
            IRoleService roleService,
            IEmailConfigurationService emailConfigurationService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _userRoleService = userRoleService;
            _roleService = roleService;
            _emailConfigurationService = emailConfigurationService;
        }

        public async Task<UserToResponseDTO> GetUsers(UserToFilterDTO filter)
        {
            return _mapper.Map<UserToResponseDTO>(await _userRepository.GetUserList(_mapper.Map<UserFilterModel>(filter)));
        }

        public async Task<UserToListDTO> GetUserById(int Id)
        {
            return _mapper.Map<UserToListDTO>(await _userRepository.GetByIdAsync(Id));
        }

        public async Task<UserToListDTO> GetUserByAuth(string email, string password)
        {
            var user = await _userManager.FindByNameAsync(email);

            //Kullanıcı var ise;
            if (user == null)
            {
                throw new Exception();
            }

            SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);

            if (signInResult.Succeeded == false)
            {
                throw new Exception();
            }

            if (user != null)
            {
                var userLoginInfo = new UserLoginInfo("Oprazi", user.Id.ToString(), user.UserName);
                await _userManager.AddLoginAsync(user, userLoginInfo);
            }
            return _mapper.Map<UserToListDTO>(user);
        }

        public async Task<UserToListDTO> GetUserByEmail(string email)
        {
            User user = await _userManager.FindByNameAsync(email);

            //Kullanıcı var ise;
            if (user == null)
            {
                throw new Exception();
            }

            return _mapper.Map<UserToListDTO>(user);
        }

        public async Task<UserProfileToListDTO> GetUserProfileByEmail(string email, string currentRole = null)
        {
            var userProfile = _mapper.Map<UserProfileToListDTO>(await _userRepository.GetUserProfileByEmail(email, currentRole));

            //Kullanıcı var ise;
            if (userProfile == null)
            {
                throw new Exception();
            }

            return userProfile;
        }

        public async Task<UserToListDTO> RegisterUser(UserToRegisterDTO userToRegisterDTO)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var user = new User();
                user.Email = userToRegisterDTO.Email.Trim();
                user.UserName = userToRegisterDTO.Email.Trim();
                var result = await _userManager.CreateAsync(user, userToRegisterDTO.Password);
                if (result.Errors.Count() > 0)
                    throw new Exception(result.Errors.FirstOrDefault().Description);

                scope.Complete();

                return _mapper.Map<UserToListDTO>(user);
            }
        }

        public async Task<string> GetResetToken(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            //resetToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(resetToken));
            return resetToken;
        }

        public async Task<bool> ResetPassword(string email, string token, string password)
        {
            var user = await _userManager.FindByNameAsync(email);
            var identityResult = await _userManager.ResetPasswordAsync(user, token, password);
            return identityResult != null;
        }

        public async Task<bool> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            await _emailConfigurationService.SendEmail(
                new EmailDTO
                {
                    EmailAddress = forgotPasswordModel.Email,
                    Title = "Oprazi Parola Sıfırlama",
                    Message = forgotPasswordModel.Link
                });
            return true;
        }

        public async Task<UserDTO> AddUser(UserToAddDTO userToAddDTO)
        {
            var user = new User();

            user.Email = userToAddDTO.UserName.Trim();
            user.UserName = userToAddDTO.UserName.Trim();
            var result = await _userManager.CreateAsync(user, userToAddDTO.Password.Trim());
            if (result.Errors.Count() > 0)
                throw new Exception(result.Errors.FirstOrDefault().Description);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task UpdateUser(UserToListDTO userDTO)
        {
            await _userRepository.Update(_mapper.Map<User>(userDTO));
        }

        public async Task DeleteUser(int Id)
        {
            await _userRepository.Delete(Id);
        }



    }
}
