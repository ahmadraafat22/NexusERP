using Microsoft.EntityFrameworkCore;
using NexusERP.Domain.Entities;

namespace NexusERP.Domain.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<Product> Products { get; }
        public DbSet<Category> Categories { get; }
        public DbSet<Customer> Customers { get; }
        public DbSet<Order> Orders { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationTokens);

    }
}
