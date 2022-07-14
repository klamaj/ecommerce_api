using Core.Models.ProductModels;

namespace API.DTOs;

public class ProductToAddDto
{
    public string ProductName { get; set; }
    public string ProductShortDescription { get; set; }
    public string ProductDescription { get; set; }
    public string ProductStatus { get; set; }
    public int[] ProductCategories { get; set; }
    public int ProductBrand { get; set; }
    public ProductVariants[] ProductVariants { get; set; }

}
