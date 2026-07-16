using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NexusERP.Domain.Interfaces;
using NexusERP.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace NexusERP.Infrasructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;

        public JwtService(UserManager<AppUser> userManager,IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }
        public async Task<string> GenerateToken(AppUser user)
        {
            /*
             to generate token u should add (claims , signIn credentials , Confgration settings ) 
             in JWT token variable 
             */


            // define claims list 
            List<Claim> tokenClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                tokenClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            // check the key and encode it 
            if (string.IsNullOrEmpty(_config["JWT:Key"])) {
                throw new Exception("there is no Token Key ");
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));

            // add key and security algorithm in signIn credentials 
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Generate token 
            var token = new JwtSecurityToken(
                    issuer: _config["JWT:Iss"],
                    audience: _config["JWT:Aud"],
                    signingCredentials:creds,
                    claims:tokenClaims,
                    expires:DateTime.UtcNow.AddDays(1)
                );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    
    }
}
