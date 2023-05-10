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
    public class UserClaimController : ControllerBase
    {
        private readonly IUserClaimService _userclaimService;

        public UserClaimController(IUserClaimService userclaimService)
        {
            _userclaimService = userclaimService;
        }
        [Authorize(Policy = ClaimUtility.userclaim)]
        //[BasicAuthorization]
        [HttpGet("getuserclaims")]
        public async Task<IActionResult> GetUserClaims([FromQuery] UserClaimToFilterDTO filter)
        {
                var userclaim = await _userclaimService.GetUserClaims(filter);
                if (userclaim == null) 
                    return NotFound();
                else
                    return Ok(userclaim);
        }
 
        [Authorize(Policy = ClaimUtility.userclaim_view)]
        [HttpGet("getuserclaim/{id}")]
        public async Task<IActionResult> GetUserClaim(int Id)
        {
                var userclaim = await _userclaimService.GetUserClaimById(Id);
                if (userclaim == null)
                {
                    return NotFound();
                }

                return Ok(new { data = userclaim});
        }
     
        [Authorize(Policy = ClaimUtility.userclaim_create)]
        [HttpPost("adduserclaim")]
        public async Task<IActionResult> AddUserClaim(UserClaimToAddDTO model)
        {
                await _userclaimService.AddUserClaim(model);
                
                return Ok();
        }
    
        [Authorize(Policy = ClaimUtility.userclaim_update)]
        [HttpPut("updateuserclaim/{id}")]
        public async Task<IActionResult> UpdateUserClaim([FromBody] UserClaimDTO model)
        {
                await _userclaimService.UpdateUserClaim(model);

                return Ok();
        }

    
        [Authorize(Policy = ClaimUtility.userclaim_delete)]
        [HttpDelete("deleteuserclaim/{id}")]
        public async Task<IActionResult> DeleteUserClaim(int Id)
        {
                await _userclaimService.DeleteUserClaim(Id);
                return Ok();
        }
    }
}
