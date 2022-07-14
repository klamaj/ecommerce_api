using Core.Models.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.ProductsConfig;

public class ProductsConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.ProductName).IsRequired().HasMaxLength(30);
        builder.Property(p => p.ProductDescription).IsRequired();
        builder.Property(p => p.ProductShortDescription).IsRequired().HasMaxLength(120);
        builder.Property(p => p.Status).HasDefaultValue("Published");
        builder.HasOne(p => p.Brand).WithMany().HasForeignKey(p => p.BrandId);
        builder.HasIndex(p => p.Slug).IsUnique();
        builder.HasIndex(p => p.ProductName).IsUnique();
    }
}
