using BakeryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakeryManagement.Infrastructure.Configurations
{
    public class BreadConfiguration : IEntityTypeConfiguration<Bread>
    {
        public void Configure(EntityTypeBuilder<Bread> builder)
        {
            builder.ToTable("Breads");
        }

        public void ConfigureColumns(EntityTypeBuilder<Bread> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.CookingTime).IsRequired();
            builder.Property(x => x.RestingTime).IsRequired();
            builder.Property(x => x.FermentTime).IsRequired();
            builder.Property(x => x.Temperature).IsRequired();
        }
    }
}
