using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NexusERP.Application.Abstractions;
using NexusERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
        // define claims 
        List<Claim> tokenClaims = new List<Claim>() {// will add roles , username , id , generated Id
        new Claim(ClaimTypes.NameIdentifier,user.Id),
        new Claim(ClaimTypes.Name,user.UserName),
        new Claim(ClaimTypes.Email,user.Email),
        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

        };
        var userRoles = await _userManager.GetRolesAsync(user);
        foreach (var role in userRoles)
        {
            tokenClaims.Add(new Claim(ClaimTypes.Role, role));
        }
        // signIncredintials 
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));

        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
                issuer: _config["JWT:Iss"],
                audience: _config["JWT:Aud"],
                expires: DateTime.UtcNow.AddDays(1),
                claims: tokenClaims,
                signingCredentials: creds

            );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    }
}
