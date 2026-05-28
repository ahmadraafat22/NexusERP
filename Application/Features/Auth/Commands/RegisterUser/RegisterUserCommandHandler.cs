using MediatR;
using Microsoft.AspNetCore.Identity;
using NexusERP.Application.Abstractions;
using NexusERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,string>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtService _jwtservice;

        public RegisterUserCommandHandler(UserManager<AppUser> userManager,IJwtService jwtservice)
        {
            _userManager = userManager;
            _jwtservice = jwtservice;
        }
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser() {
                UserName= request.UserName,
                Email=request.Email
            };

            var result =await  _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded) 
            {
                throw new Exception("user creation failed");
            }
            await _userManager.AddToRoleAsync(user, "User");
            return await _jwtservice.GenerateToken(user);
        }

    }
}
