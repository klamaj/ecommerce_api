namespace Core.Models.ProductModels;

public class ProductDetails : Base
{
    public ProductVariants ProductVariants { get; set; }
    public int ProductVariantsId { get; set; }
}

/*
    INSERT INTO ProductDetails
        (Id, ProductVariantsId)
    VALUES 
        (1, 1),
        (1, 2);
*/
