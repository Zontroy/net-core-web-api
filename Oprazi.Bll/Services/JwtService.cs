using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Oprazi.Dto.DTOs;
using Oprazi.Utility.Utilities;

namespace Oprazi.Bll.Services
{
    public class JwtService
    {
        private readonly string _secret;
        private readonly string _expDate;
        private readonly string _issuer;
        private readonly string _audience;

        public JwtService(IConfiguration config)
        {
            _secret = config.GetSection("Application").GetSection("Secret").Value;
            _expDate = config.GetSection("Application").GetSection("ExpirationInMinutes").Value;
            _audience = config.GetSection("Application").GetSection("Audience").Value;
            _issuer = config.GetSection("Application").GetSection("Issuer").Value;
        }

        public string GenerateSecurityToken(UserToListDTO user, List<RoleClaimToListDTO> roleclaims)
        {
            

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);

            var claims = new List<Claim>();
            foreach (var roleClaim in roleclaims)
                claims.Add(new Claim(roleClaim.ClaimType, roleClaim.ClaimValue));
            claims.Add(new Claim(ClaimTypeUtility.email, user.Email));
          
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _audience,
                Issuer = _issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }

        public string ValidateJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var email = jwtToken.Claims.Where(x => x.Type == ClaimTypeUtility.email).FirstOrDefault()?.Value;

                return email;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}
