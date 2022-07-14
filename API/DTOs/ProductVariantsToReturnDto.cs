using static System.Net.Mime.MediaTypeNames;

namespace API.DTOs;

public class ProductVariantsToReturnDto
{
    public int ProductVariantId { get; set; }
    public string ProductVariantName { get; set; }
    public string SKU { get; set; }
    public float RegularPrice { get; set; }
    public float SalePrice { get; set; }
    public int Quantity { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string ProductShortDescription { get; set; }
    public string ProductBrand { get; set; }
    public IReadOnlyList<ImagesDto> Images { get; set; }
}
