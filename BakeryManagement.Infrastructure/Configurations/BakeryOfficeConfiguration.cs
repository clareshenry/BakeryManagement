using BakeryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakeryManagement.Infrastructure.Configurations
{
    public class BakeryOfficeConfiguration : IEntityTypeConfiguration<BakeryOffice>
    {
        public void Configure(EntityTypeBuilder<BakeryOffice> builder)
        {
            builder.ToTable("bakery_office");

            ConfigureColumns(builder);
            // ConfigureRelationShips(builder);
            // AuditConfiguration.Configure(builder);
        }

        private void ConfigureColumns(EntityTypeBuilder<BakeryOffice> builder)
        {
            builder.HasKey(bakeryOffice => bakeryOffice.Id);
            builder.Property(bakeryOffice => bakeryOffice.Name).HasColumnName("name").IsRequired();
            builder
                .Property(bakeryOffice => bakeryOffice.Capacity)
                .HasColumnName("capacity")
                .IsRequired();
        }
    }
}
