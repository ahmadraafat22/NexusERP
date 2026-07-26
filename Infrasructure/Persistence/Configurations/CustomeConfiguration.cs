using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexusERP.Domain.Entities;

namespace NexusERP.Infrasructure.Persistence.Configurations
{
    public class CustomeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired(true)
                .HasMaxLength(50);
            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);
            builder.Property(c => c.Email)
                .IsRequired(false);
            builder.HasIndex(c => c.Email)
                .IsUnique()
                .HasFilter("[Email] is not null");
            builder.Property(c => c.Address)
                .IsRequired(false)
                .HasMaxLength(200);
            builder.Property(c => c.Code)
                .IsRequired()
                .HasMaxLength(20);
            builder.HasIndex(c => c.Code)
                .IsUnique();
            builder.HasIndex(c => c.PhoneNumber)
                .IsUnique();
            builder.HasQueryFilter(c => !c.IsDeleted);

        }
    }
}
