namespace API.DTOs;

public class ProductToReturnDto
{
    public int ID { get; set; }
    public string ProductName { get; set; }
    public string  ProductDescription { get; set; }
    public string ProductShortDescription { get; set; }
    public string Slug { get; set; }
    public string Status { get; set; }
    public string ProductBrand { get; set; }
    public DateTime DateCreated { get; set; }
}
