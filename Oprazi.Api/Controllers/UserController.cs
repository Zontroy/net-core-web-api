using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Oprazi.Bll.Services;
using Oprazi.Bll.Services.IServices;
using Oprazi.Dto.DTOs;
using Oprazi.Entity.Entities;
using System;
using System.Threading.Tasks;
using System.Linq;
using Oprazi.Utility.Utilities;
using Serilog;
using System.Web;
using Microsoft.AspNetCore.Cors;

namespace Oprazi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly IRoleClaimService _roleClaimService;
        private readonly RoleManager<Role> _roleManager;
        private IConfiguration _config;

        public UserController(IUserService userService,
            IConfiguration config,
            RoleManager<Role> roleManager,
            IUserRoleService userRoleService,
            IRoleClaimService roleClaimService)
        {
            _userService = userService;
            _config = config;
            _roleManager = roleManager;
            _userRoleService = userRoleService;
            _roleClaimService = roleClaimService;
        }

        [Authorize(Policy = ClaimUtility.user)]
        [HttpGet("getusers")]
        public async Task<IActionResult> GetUsers([FromQuery] UserToFilterDTO filter)
        {
            var users = await _userService.GetUsers(filter);
            if (users == null)
                return NotFound();
            else
                return Ok(users);
        }

     
        [Authorize(Policy = ClaimUtility.user_view)]
        [HttpGet("getuser/{id}")]
        public async Task<IActionResult> GetUser(int Id)
        {
            var user = await _userService.GetUserById(Id);
            if (user == null)
            {
                return BadRequest("Veri yok");
            }

            return Ok(new { data = user });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            Log.Information($"Information {login.email} entered login action.");
            Log.Error("{ControllerName}{MethodName}", typeof(UserController),"Login");

            var user = await _userService.GetUserByAuth(login.email, login.password);
            var userroles = await _userRoleService.GetUserRoles(new UserRoleToFilterDTO { UserId = user.Id });
            var roleclaims = await _roleClaimService.GetRoleClaimsByRole(userroles.Data.Select(x => x.RoleId).ToList());

            if (user == null)
                return NotFound();
            else
            {
                var jwt = new JwtService(_config);
                var token = jwt.GenerateSecurityToken(user, roleclaims.Data);
                var userProfile = await _userService.GetUserProfileByEmail(user.Email);
                return Ok(new AuthModel { api_token = token, currentRole = userProfile.Roles.FirstOrDefault() });
            }

        }

        [HttpPost("verifytoken")]
        public async Task<IActionResult> VerifyToken([FromBody] VerifyModel verify)
        {
            var jwt = new JwtService(_config);
            string email = jwt.ValidateJwtToken(verify.api_token);
            if (string.IsNullOrEmpty(email))
            {
                return NotFound();
            }
            var user = await _userService.GetUserProfileByEmail(email, verify.current_role);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserToRegisterDTO userToRegisterDTO)
        {
            var user = await _userService.RegisterUser(userToRegisterDTO);
            var userroles = await _userRoleService.GetUserRoles(new UserRoleToFilterDTO { UserId = user.Id });
            var roleclaims = await _roleClaimService.GetRoleClaimsByRole(userroles.Data.Select(x => x.RoleId).ToList());

            if (user == null)
                return NotFound();
            else
            {
                var jwt = new JwtService(_config);
                var token = jwt.GenerateSecurityToken(user, roleclaims.Data);
                var userProfile = await _userService.GetUserProfileByEmail(user.Email);
                return Ok(new AuthModel { api_token = token, currentRole = userProfile.Roles.FirstOrDefault() });
            }
        }

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel forgotPasswordModel)
        {
            var user = await _userService.GetUserByEmail(forgotPasswordModel.Email);
            if (user == null)
                return NotFound();

            var resetToken = await _userService.GetResetToken(user.Email);
            forgotPasswordModel.Link = $"<p>Merhaba Sayın Kullanıcı,<br><br>Oprazi kullanıcı parolanızı sıfırlamak için aşağıdaki linki kullanın :</p><br><a target=\"_blank\" href=\"https://okul.oprazi.com/auth/reset-password?email=" +  forgotPasswordModel.Email + "&token=" + HttpUtility.UrlEncode(resetToken) + "\">Parola Sıfırla!</a><br><br><p>Oprazi'yi seçtiğiniz için teşekkür ederiz!</p><p>Oprazi Eğitim Yönetim Sistemi<br>Oprazi Müşteri Hizmetleri</p>";
            await _userService.ForgotPassword(forgotPasswordModel);
            return Ok();
        }

        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel resetPasswordModel)
        {
            if (resetPasswordModel.Password != resetPasswordModel.ChangePassword)
                return NotFound();

            var result = await _userService.ResetPassword(resetPasswordModel.Email, resetPasswordModel.Token, resetPasswordModel.Password);

            if(!result)
                return NotFound();

            return Ok();
        }

        [Authorize(Policy = ClaimUtility.user_create)]
        [HttpPost("adduser")]
        public async Task<IActionResult> AddUser([FromBody] UserToAddDTO userToAddDTO)
        {
            //var validator = new UserValidator();
            //var result = validator.Validate(userToAddDTO);
            //if (ModelState.IsValid)
            await _userService.AddUser(userToAddDTO);
            return Ok();
            //else
            //    return BadRequest(result.Errors);
        }
      
        [Authorize(Policy = ClaimUtility.user_update)]
        [HttpPut("updateuser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserToListDTO model)
        {
            await _userService.UpdateUser(model);

            return Ok();
        }
    
        [Authorize(Policy = ClaimUtility.user_delete)]
        [HttpDelete("deleteuser/{id}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            await _userService.DeleteUser(Id);
            return Ok();
        }
    }
}
