using Core.Models.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.ProductsConfig;

public class VariantValuesConfiguration : IEntityTypeConfiguration<VariantValue>
{
    public void Configure(EntityTypeBuilder<VariantValue> builder)
    {
        builder.HasIndex(v => new {v.VariantId, v.VariantValueName}).IsUnique();
        builder.Property(v => v.VariantValueName).IsRequired().HasMaxLength(40);
        builder.Property(v => v.VariantValueDescription).IsRequired().HasMaxLength(256);
        builder.Property(v => v.VariantValueCode).IsRequired().HasMaxLength(2);
    }
}
