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
    public class UserTokenService : IUserTokenService
    {
        private readonly IUserTokenRepository _usertokenRepository;
        private readonly IMapper _mapper;
        public UserTokenService(IUserTokenRepository usertokenRepository, IMapper mapper)
        {
            _usertokenRepository = usertokenRepository;
            _mapper = mapper;
        }

        public async Task<UserTokenToResponseDTO> GetUserTokens(UserTokenToFilterDTO filter)
        {
            return _mapper.Map<UserTokenToResponseDTO>(await _usertokenRepository.GetUserTokenList(_mapper.Map<UserTokenFilterModel>(filter)) );
        }
       
        public async Task<UserTokenDTO> GetUserTokenById(int Id)
        {
            return _mapper.Map<UserTokenDTO>(await _usertokenRepository.GetUserTokenById(Id));
        }

        public async Task<UserTokenDTO> AddUserToken(UserTokenToAddDTO usertokenToAddDTO)
        {
            return _mapper.Map<UserTokenDTO>(await _usertokenRepository.Add(_mapper.Map<UserToken>(usertokenToAddDTO ) ) );
        }

        public async Task UpdateUserToken(UserTokenDTO usertokenDTO)
        {
            await _usertokenRepository.Update(_mapper.Map<UserToken>(usertokenDTO ) );
        }

        public async Task DeleteUserToken(int Id)
        {
            await _usertokenRepository.Delete(Id);
        }

      
     
    }
}
