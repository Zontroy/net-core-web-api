using Oprazi.Bll.Services.IServices;
using Oprazi.Dal.Repositories.IRepositories;
using Oprazi.Dto.DTOs;
using Oprazi.Entity.Entities;
using Oprazi.Entity.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;

namespace Oprazi.Bll.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userroleRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public UserRoleService(IUserRoleRepository userroleRepository, 
            IMapper mapper,
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            _userroleRepository = userroleRepository;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<UserRoleToResponseDTO> GetUserRoles(UserRoleToFilterDTO filter)
        {
            return _mapper.Map<UserRoleToResponseDTO>(await _userroleRepository.GetUserRoleList(_mapper.Map<UserRoleFilterModel>(filter)) );
        }
       
        public async Task<UserRoleDTO> GetUserRoleById(int UserId, int RoleId)
        {
            return _mapper.Map<UserRoleDTO>(await _userroleRepository.GetUserRoleById(UserId));
        }

        public async Task<UserRoleDTO> AddUserRole(UserRoleToAddDTO userroleToAddDTO)
        {
            return _mapper.Map<UserRoleDTO>(await _userroleRepository.Add(_mapper.Map<UserRole>(userroleToAddDTO ) ) );
        }

        public async Task UpdateUserRole(UserRoleDTO userroleDTO)
        {
            await _userroleRepository.Update(_mapper.Map<UserRole>(userroleDTO ) );
        }

        public async Task DeleteUserRole(int UserId, int RoleId)
        {
            var user = await _userManager.FindByIdAsync(UserId.ToString());
            var role = await _roleManager.FindByIdAsync(RoleId.ToString());
            await _userManager.RemoveFromRoleAsync(user, role.Name);

        }

      
     
    }
}
