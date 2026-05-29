using Microsoft.EntityFrameworkCore;
using NexusERP.Domain.Entities;

namespace NexusERP.Application.Abstractions
{
    public interface IAppDbContext
    {
        public DbSet<Product> Products { get;  }
        public DbSet<Category> Categories { get; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationTokens);
        
    }
}
