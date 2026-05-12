using Microsoft.EntityFrameworkCore;
using NexusERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Application.Abstractions
{
    public interface IAppDbContext
    {
        public DbSet<Product> Products { get;  }
        public DbSet<Category> Categories { get; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationTokens);
        
    }
}
