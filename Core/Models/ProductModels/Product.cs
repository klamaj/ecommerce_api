namespace Core.Models.ProductModels;

public class Product : Base
{
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string ProductShortDescription { get; set; }
    public string Slug { get; set; }
    public string Status { get; set; }
    public Brand Brand { get; set; }
    public int BrandId { get; set; }
    public List<ProductCategory> ProductCategories { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    // TODO: Tags
    
}