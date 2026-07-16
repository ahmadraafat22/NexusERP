using NexusERP.Domain.Entities;


namespace NexusERP.Domain.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateToken(AppUser user);
    }
}
