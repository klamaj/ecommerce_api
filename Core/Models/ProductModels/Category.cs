namespace Core.Models.ProductModels;

public class Category : Base
{
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
    public string Slug { get; set; }
    public string CategoryImagePath  { get; set; }
    public string CategoryCode { get; set; }
    public List<ProductCategory> ProductCategories { get; set; }
}
