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
    public class UserClaimService : IUserClaimService
    {
        private readonly IUserClaimRepository _userclaimRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public UserClaimService(IUserClaimRepository userclaimRepository, 
            IMapper mapper, UserManager<User> userManager)
        {
            _userclaimRepository = userclaimRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UserClaimToResponseDTO> GetUserClaims(UserClaimToFilterDTO filter)
        {
            return _mapper.Map<UserClaimToResponseDTO>(await _userclaimRepository.GetUserClaimList(_mapper.Map<UserClaimFilterModel>(filter)) );
        }
       
        public async Task<UserClaimDTO> GetUserClaimById(int Id)
        {
            return _mapper.Map<UserClaimDTO>(await _userclaimRepository.GetUserClaimById(Id));
        }

        public async Task<UserClaimDTO> AddUserClaim(UserClaimToAddDTO userclaimToAddDTO)
        {
            return _mapper.Map<UserClaimDTO>(await _userclaimRepository.Add(_mapper.Map<UserClaim>(userclaimToAddDTO ) ) );
        }

        public async Task UpdateUserClaim(UserClaimDTO userclaimDTO)
        {
            await _userclaimRepository.Update(_mapper.Map<UserClaim>(userclaimDTO ) );
        }

        public async Task DeleteUserClaim(int Id)
        {
            var userClaim = _mapper.Map<UserClaimDTO>(await _userclaimRepository.GetUserClaimById(Id));
            var user = await _userManager.FindByIdAsync(userClaim.UserId.ToString());
            await _userManager.RemoveClaimAsync(user, new Claim(userClaim.ClaimType, userClaim.ClaimValue));
        }

      
     
    }
}
