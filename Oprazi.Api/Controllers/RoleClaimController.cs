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
    public class RoleClaimController : ControllerBase
    {
        private readonly IRoleClaimService _roleclaimService;
        
        public RoleClaimController(IRoleClaimService roleclaimService)
        {
            _roleclaimService = roleclaimService;
        }

        [Authorize(Policy = ClaimUtility.roleclaim)]
        [HttpGet("getroleclaims")]
        public async Task<IActionResult> GetRoleClaims([FromQuery] RoleClaimToFilterDTO filter)
        {
                var roleclaim = await _roleclaimService.GetRoleClaims(filter);
                if (roleclaim == null) 
                    return NotFound();
                else
                    return Ok(roleclaim);
        }

      
        [Authorize(Policy = ClaimUtility.roleclaim_view)]
        [HttpGet("getroleclaim/{id}")]
        public async Task<IActionResult> GetRoleClaim(int Id)
        {
                var roleclaim = await _roleclaimService.GetRoleClaimById(Id);
                if (roleclaim == null)
                {
                    return NotFound();
                }

                return Ok(new { data = roleclaim});

        }

     
        [Authorize(Policy = ClaimUtility.roleclaim_create)]
        [HttpPost("addroleclaim")]
        public async Task<IActionResult> AddRoleClaim(RoleClaimToAddDTO model)
        {
                await _roleclaimService.AddRoleClaim(model);
                
                return Ok();
        }

    
        [Authorize(Policy = ClaimUtility.roleclaim_update)]
        [HttpPut("updateroleclaim/{id}")]
        public async Task<IActionResult> UpdateRoleClaim([FromBody] RoleClaimDTO model)
        {
                await _roleclaimService.UpdateRoleClaim(model);

                return Ok();

        }

       
        [Authorize(Policy = ClaimUtility.roleclaim_delete)]
        [HttpDelete("deleteroleclaim/{id}")]
        public async Task<IActionResult> DeleteRoleClaim(int Id)
        {
                await _roleclaimService.DeleteRoleClaim(Id);
                return Ok();
        }
    }
}
