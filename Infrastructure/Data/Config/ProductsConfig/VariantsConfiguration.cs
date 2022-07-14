using Core.Models.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.ProductsConfig;

public class VariantsConfiguration : IEntityTypeConfiguration<Variant>
{
    public void Configure(EntityTypeBuilder<Variant> builder)
    {
        builder.HasIndex(v => v.VariantName).IsUnique();
        builder.Property(v => v.VariantDescription).IsRequired().HasMaxLength(256);
    }
}
