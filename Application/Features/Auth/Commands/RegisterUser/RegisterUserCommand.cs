using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<string>
    {
        public string   UserName    { get; set; }
        public string   Password    { get; set; }
        public string   ConfirmPassword    { get; set; }
        public string   Email       { get; set; }
    }
}
