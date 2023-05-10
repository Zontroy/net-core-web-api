using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Oprazi.Bll.Services.IServices;
using Oprazi.Dto.DTOs;
using Oprazi.Entity.Entities;
using Oprazi.Utility.Utilities;
using System;
using System.Threading.Tasks;

namespace Oprazi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService,
            RoleManager<Role> roleManager,
            IMapper mapper)
        {
            _roleService = roleService;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        [Authorize(Policy = ClaimUtility.role)]
        [HttpGet("getroles")]
        public async Task<IActionResult> GetRoles([FromQuery] RoleToFilterDTO filter)
        {
                var role = await _roleService.GetRoles(filter);
                if (role == null) 
                    return NotFound();
                else
                    return Ok(role);
        }
     
        [Authorize(Policy = ClaimUtility.role_view)]
        [HttpGet("getrole/{id}")]
        public async Task<IActionResult> GetRole(string Id)
        {
                var role = await _roleManager.FindByIdAsync(Id);
                if (role == null)
                {
                    return NotFound();
                }

                return Ok(new { data = role});

        }
     
        [Authorize(Policy = ClaimUtility.role_create)]
        [HttpPost("addrole")]
        public async Task<IActionResult> AddRole(RoleToAddDTO model)
        {
                await _roleManager.CreateAsync(_mapper.Map<Role>(model));
                
                return Ok();
        }
      
        [Authorize(Policy = ClaimUtility.role_update)]
        [HttpPut("updaterole/{id}")]
        public async Task<IActionResult> UpdateRole([FromBody] RoleDTO model)
        {
                await _roleManager.UpdateAsync(_mapper.Map<Role>(model));

                return Ok();

        }
    
        [Authorize(Policy = ClaimUtility.role_delete)]

        [HttpDelete("deleterole/{id}")]
        public async Task<IActionResult> DeleteRole(string Id)
        {
                var role = await _roleManager.FindByIdAsync(Id);
                await _roleManager.DeleteAsync(role);
                return Ok();
        }
    }
}
