namespace Core.Models.ProductModels;

public class Image : Base
{
    public string ImagePath { get; set; }
    public string AlternativeText { get; set; }
    public int ProductVariantId { get; set; }
    public ProductVariants ProductVariants { get; set; }
}
