using NexusERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Application.Abstractions
{
    public interface IJwtService
    {
        Task<string> GenerateToken(AppUser user);
    }
}
