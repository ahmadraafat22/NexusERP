using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexusERP.Domain.Entities;

namespace NexusERP.Infrasructure.Persistence.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.HasIndex(x => x.PhoneNumber)
                   .IsUnique();

            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.HasIndex(x => x.Code)
                   .IsUnique();

            builder.Property(x => x.Email)
                   .HasMaxLength(100);

            builder.HasIndex(x => x.Email)
                   .IsUnique()
                   .HasFilter("[Email] IS NOT NULL");

            builder.Property(x => x.Address)
                   .HasMaxLength(200);

            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}
