using NexusERP.Domain.Entities;


namespace NexusERP.Application.Abstractions
{
    public interface IJwtService
    {
        Task<string> GenerateToken(AppUser user);
    }
}
