using Microsoft.AspNetCore.Mvc;
using Oprazi.Bll.Services.IServices;
using Oprazi.Dto.DTOs;
using System;
using System.Threading.Tasks;

namespace Oprazi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTokenController : ControllerBase
    {
        private readonly IUserTokenService _usertokenService;

        public UserTokenController(IUserTokenService usertokenService)
        {
            _usertokenService = usertokenService;
        }

        //[BasicAuthorization]
        [HttpGet("getusertokens")]
        public async Task<IActionResult> GetUserTokens([FromQuery] UserTokenToFilterDTO filter)
        {
                var usertoken = await _usertokenService.GetUserTokens(filter);
                if (usertoken == null) 
                    return NotFound();
                else
                    return Ok(usertoken);
        }
        
        [HttpGet("getusertoken/{id}")]
        public async Task<IActionResult> GetUserToken(int Id)
        {
                var usertoken = await _usertokenService.GetUserTokenById(Id);
                if (usertoken == null)
                {
                    return NotFound();
                }

                return Ok(new { data = usertoken});
        }

        [HttpPost("addusertoken")]
        public async Task<IActionResult> AddUserToken(UserTokenToAddDTO model)
        {
                await _usertokenService.AddUserToken(model);
                
                return Ok();
        }

        [HttpPut("updateusertoken/{id}")]
        public async Task<IActionResult> UpdateUserToken([FromBody] UserTokenDTO model)
        {
                await _usertokenService.UpdateUserToken(model);

                return Ok();
        }


        [HttpDelete("deleteusertoken/{id}")]
        public async Task<IActionResult> DeleteUserToken(int Id)
        {
                await _usertokenService.DeleteUserToken(Id);
                return Ok();
        }
    }
}
