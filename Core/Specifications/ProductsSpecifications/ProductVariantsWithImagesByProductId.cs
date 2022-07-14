using Core.Models.ProductModels;

namespace Core.Specifications.ProductsSpecifications;

public class ProductVariantsWithImagesByProductId : BaseSpecification<ProductVariants>
{
    public ProductVariantsWithImagesByProductId(int productId) : base (p => p.ProductId == productId)
    {
        AddInclude(p => p.Images);
        AddInclude(p => p.Product);
    }
}
