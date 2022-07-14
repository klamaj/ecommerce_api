using Core.Models.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.ProductsConfig;

public class ProductVariantsConfiguration : IEntityTypeConfiguration<ProductVariants>
{
    public void Configure(EntityTypeBuilder<ProductVariants> builder)
    {
        builder.HasIndex(p => new {p.ProductId, p.ProductVariantName}).IsUnique();
        builder.HasIndex(p => p.SKU).IsUnique();
        builder.Property(p => p.RegularPrice).HasColumnType("float(18,20)");
        builder.Property(p => p.SalePrice).HasColumnType("float(18,20)");
        builder.Property(p => p.ProductId).IsRequired();
        builder.Property(p => p.Quantity).IsRequired();
        builder.HasMany(p => p.Images).WithOne(i => i.ProductVariants).HasForeignKey(i => i.ProductVariantId);
    }
}
