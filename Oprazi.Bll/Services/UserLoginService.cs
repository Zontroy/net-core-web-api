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

namespace Oprazi.Bll.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserLoginRepository _userloginRepository;
        private readonly IMapper _mapper;
        public UserLoginService(IUserLoginRepository userloginRepository, IMapper mapper)
        {
            _userloginRepository = userloginRepository;
            _mapper = mapper;
        }

        public async Task<UserLoginToResponseDTO> GetUserLogins(UserLoginToFilterDTO filter)
        {
            return _mapper.Map<UserLoginToResponseDTO>(await _userloginRepository.GetUserLoginList(_mapper.Map<UserLoginFilterModel>(filter)) );
        }
       
        public async Task<UserLoginDTO> GetUserLoginById(int Id)
        {
            return _mapper.Map<UserLoginDTO>(await _userloginRepository.GetUserLoginById(Id));
        }

        public async Task<UserLoginDTO> AddUserLogin(UserLoginToAddDTO userloginToAddDTO)
        {
            return _mapper.Map<UserLoginDTO>(await _userloginRepository.Add(_mapper.Map<UserLogin>(userloginToAddDTO ) ) );
        }

        public async Task UpdateUserLogin(UserLoginDTO userloginDTO)
        {
            await _userloginRepository.Update(_mapper.Map<UserLogin>(userloginDTO ) );
        }

        public async Task DeleteUserLogin(int Id)
        {
            await _userloginRepository.Delete(Id);
        }

      
     
    }
}
