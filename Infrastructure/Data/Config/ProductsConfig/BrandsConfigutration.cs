using Core.Models.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.ProductsConfig;

public class BrandsConfigutration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasIndex(b => b.BrandName).IsUnique();
        builder.HasIndex(b => b.Slug).IsUnique();
        builder.Property(b => b.BrandName).HasMaxLength(30).IsRequired();
        builder.Property(b => b.ImagePath).IsRequired();
        builder.Property(b => b.BrandCode).IsRequired().HasMaxLength(2);
    }
}
