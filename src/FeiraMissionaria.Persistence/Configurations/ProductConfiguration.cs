using FeiraMissionaria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeiraMissionaria.Persistence.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Produtcs");

        builder.Property(p => p.Name).HasColumnType("varchar").HasMaxLength(100);
        builder.Property(p => p.Description).HasColumnType("varchar").HasMaxLength(200);
        builder.Property(p => p.Price).HasColumnType("decimal(5,2)");

        builder.HasIndex(p => p.DeletedAt);
        builder.HasQueryFilter(q => q.DeletedAt == null);
    }
}
