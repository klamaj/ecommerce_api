using Core.Models.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config.ProductsConfig;

public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
    {
        // builder.HasMany<Product>(c => c.Products).WithMany(p => p.Categories);
        builder.HasIndex(c => c.CategoryName).IsUnique();
        builder.HasIndex(c => c.Slug).IsUnique();
        builder.Property(c => c.CategoryName).HasMaxLength(25).IsRequired();
        builder.Property(c => c.CategoryDescription).IsRequired();
        builder.Property(c => c.CategoryImagePath).IsRequired();
        builder.Property(c => c.Slug).HasMaxLength(25).IsRequired();
        builder.Property(c => c.CategoryCode).IsRequired().HasMaxLength(2);
    }
}
