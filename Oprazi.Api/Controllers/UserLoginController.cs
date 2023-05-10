using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oprazi.Bll.Services.IServices;
using Oprazi.Dto.DTOs;
using Oprazi.Utility.Utilities;
using System;
using System.Threading.Tasks;

namespace Oprazi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginService _userloginService;

        public UserLoginController(IUserLoginService userloginService)
        {
            _userloginService = userloginService;
        }

        [Authorize(Policy = ClaimUtility.userlogin)]
        [HttpGet("getuserlogins")]
        public async Task<IActionResult> GetUserLogins([FromQuery] UserLoginToFilterDTO filter)
        {
                var userlogin = await _userloginService.GetUserLogins(filter);
                if (userlogin == null) 
                    return NotFound();
                else
                    return Ok(userlogin);
        }
      
        [Authorize(Policy = ClaimUtility.userlogin_view)]
        [HttpGet("getuserlogin/{id}")]
        public async Task<IActionResult> GetUserLogin(int Id)
        {
                var userlogin = await _userloginService.GetUserLoginById(Id);
                if (userlogin == null)
                {
                    return NotFound();
                }

                return Ok(new { data = userlogin});
        }
      
        [Authorize(Policy = ClaimUtility.userlogin_create)]
        [HttpPost("adduserlogin")]
        public async Task<IActionResult> AddUserLogin(UserLoginToAddDTO model)
        {
                await _userloginService.AddUserLogin(model);
                
                return Ok();
        }
   
        [Authorize(Policy = ClaimUtility.userlogin_update)]
        [HttpPut("updateuserlogin/{id}")]
        public async Task<IActionResult> UpdateUserLogin([FromBody] UserLoginDTO model)
        {
                await _userloginService.UpdateUserLogin(model);

                return Ok();
        }
      
        [Authorize(Policy = ClaimUtility.userlogin_delete)]

        [HttpDelete("deleteuserlogin/{id}")]
        public async Task<IActionResult> DeleteUserLogin(int Id)
        {
                await _userloginService.DeleteUserLogin(Id);
                return Ok();
        }
    }
}
