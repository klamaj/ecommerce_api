using System.ComponentModel.DataAnnotations;

namespace Core.Models.ProductModels;

public class ProductVariants : Base
{
    public string ProductVariantName { get; set; }
    public string SKU { get; set; }
    public float RegularPrice { get; set; }
    public float SalePrice { get; set; }
    public int Quantity { get; set; }
    public Product Product { get; set; }
    public int ProductId { get; set; }
    public ICollection<Image> Images { get; set; }

    // TODO: StartSaleDate
    // TODO: EndSaleDated
}