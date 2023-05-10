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
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userroleService;

        public UserRoleController(IUserRoleService userroleService)
        {
            _userroleService = userroleService;
        }


        [Authorize(Policy = ClaimUtility.userrole)]
      
        //[BasicAuthorization]
        [HttpGet("getuserroles")]
        public async Task<IActionResult> GetUserRoles([FromQuery] UserRoleToFilterDTO filter)
        {
                var userrole = await _userroleService.GetUserRoles(filter);
                if (userrole == null) 
                    return NotFound();
                else
                    return Ok(userrole);
        }
        // [Authorize(Policy = ClaimUtility.userrole_view)]
        [HttpGet("getuserrole/{userId}/{roleId}")]
        public async Task<IActionResult> GetUserRole(int UserId, int RoleId)
        {
                var userrole = await _userroleService.GetUserRoleById(UserId, RoleId);
                if (userrole == null)
                {
                    return NotFound();
                }

                return Ok(new { data = userrole});
        }
       
        [Authorize(Policy = ClaimUtility.userrole_create)]
        [HttpPost("adduserrole")]
        public async Task<IActionResult> AddUserRole(UserRoleToAddDTO model)
        {
                await _userroleService.AddUserRole(model);
                
                return Ok();
        }
 
        [Authorize(Policy = ClaimUtility.userrole_update)]
        [HttpPut("updateuserrole/{userId}/{roleId}")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UserRoleDTO model)
        {
                await _userroleService.UpdateUserRole(model);

                return Ok();
        }

    
        [Authorize(Policy = ClaimUtility.userrole_delete)]
        [HttpDelete("deleteuserrole/{userId}/{roleId}")]
        public async Task<IActionResult> DeleteUserRole(int UserId, int RoleId)
        {
                await _userroleService.DeleteUserRole(UserId, RoleId);
                return Ok();
        }
    }
}
