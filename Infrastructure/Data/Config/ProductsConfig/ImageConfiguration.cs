using Core.Models.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.ProductsConfig;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.Property(i => i.AlternativeText).IsRequired().HasMaxLength(25);
        builder.Property(i => i.ImagePath).IsRequired();
    }
}
