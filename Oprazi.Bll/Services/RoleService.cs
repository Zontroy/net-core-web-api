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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;
        public RoleService(IRoleRepository roleRepository, IMapper mapper, RoleManager<Role> roleManager)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<RoleToResponseDTO> GetRoles(RoleToFilterDTO filter)
        {
            return _mapper.Map<RoleToResponseDTO>(await _roleRepository.GetRoleList(_mapper.Map<RoleFilterModel>(filter)));
        }

        public async Task<RoleDTO> GetRoleById(int Id)
        {
            return _mapper.Map<RoleDTO>(await _roleRepository.GetByIdAsync(Id));
        }

        public async Task<RoleDTO> AddRole(RoleToAddDTO roleToAddDTO)
        {
            return _mapper.Map<RoleDTO>(await _roleRepository.Add(_mapper.Map<Role>(roleToAddDTO)));
        }

        public async Task UpdateRole(RoleDTO roleDTO)
        {
            await _roleRepository.Update(_mapper.Map<Role>(roleDTO));
        }

        public async Task DeleteRole(int Id)
        {
            await _roleRepository.Delete(Id);
        }



    }
}
