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
using System.Security.Claims;

namespace Oprazi.Bll.Services
{
    public class RoleClaimService : IRoleClaimService
    {
        private readonly IRoleClaimRepository _roleclaimRepository;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;
        public RoleClaimService(IRoleClaimRepository roleclaimRepository, IMapper mapper, RoleManager<Role> roleManager)
        {
            _roleclaimRepository = roleclaimRepository;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<RoleClaimToResponseDTO> GetRoleClaims(RoleClaimToFilterDTO filter)
        {
            return _mapper.Map<RoleClaimToResponseDTO>(await _roleclaimRepository.GetRoleClaimList(_mapper.Map<RoleClaimFilterModel>(filter)) );
        }

        public async Task<RoleClaimToResponseDTO> GetRoleClaimsByRole(List<int> RoleIds)
        {
            return _mapper.Map<RoleClaimToResponseDTO>(await _roleclaimRepository.GetRoleClaimListByRole(RoleIds));
        }

        public async Task<RoleClaimDTO> GetRoleClaimById(int Id)
        {
            return _mapper.Map<RoleClaimDTO>(await _roleclaimRepository.GetRoleClaimById(Id));
        }

        public async Task<RoleClaimDTO> AddRoleClaim(RoleClaimToAddDTO roleclaimToAddDTO)
        {
            return _mapper.Map<RoleClaimDTO>(await _roleclaimRepository.Add(_mapper.Map<RoleClaim>(roleclaimToAddDTO ) ) );
        }

        public async Task UpdateRoleClaim(RoleClaimDTO roleclaimDTO)
        {
            await _roleclaimRepository.Update(_mapper.Map<RoleClaim>(roleclaimDTO ) );
        }

        public async Task DeleteRoleClaim(int Id)
        {
            var roleClaim = _mapper.Map<RoleClaimDTO>(await _roleclaimRepository.GetRoleClaimById(Id));
            var role = await _roleManager.FindByIdAsync(roleClaim.RoleId.ToString());
            await _roleManager.RemoveClaimAsync(role, new Claim(roleClaim.ClaimType, roleClaim.ClaimValue));
        }

      
     
    }
}
