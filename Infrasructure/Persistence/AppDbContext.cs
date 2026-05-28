using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NexusERP.Application.Abstractions;
using NexusERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Infrasructure.Persistence
{
    public class AppDbContext:IdentityDbContext<AppUser>,IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<Product>   Products    { get; set; }
        public DbSet<Category>  Categories  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This searching for IEntityTypeConfiguration to apply configuration on it automaticlly 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
