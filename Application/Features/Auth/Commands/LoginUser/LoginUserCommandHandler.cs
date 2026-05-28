using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Experimental;
using NexusERP.Application.Abstractions;
using NexusERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IConfiguration _config;
        private readonly IJwtService _jwtservice;
        private readonly UserManager<AppUser> _userManger;
        public LoginUserCommandHandler(UserManager<AppUser> userManger,IConfiguration config,IJwtService jwtservice)
        {
            _config = config;
            _jwtservice = jwtservice;
            _userManger = userManger;
        }
        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user =await _userManger.FindByEmailAsync(request.Email);

            if (user != null) 
            {
                var validPassword = await _userManger.CheckPasswordAsync(user, request.Password);
                if (!validPassword) 
                {
                    throw new Exception("Invalid email or password");
                }

                return await _jwtservice.GenerateToken(user);
            }

            throw new Exception("Invalid email or password");
        }
        
    }
}
