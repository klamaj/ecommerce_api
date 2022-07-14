using Core.Models.ProductModels;

namespace Core.Specifications.ProductsSpecifications;

public class ProductsWithBrandsSpecification : BaseSpecification<Product>
{
    public ProductsWithBrandsSpecification(string sort, int? brandId)
        : base(x => !brandId.HasValue || x.BrandId != brandId)
    {
        AddInclude(x => x.Brand);
        AddOrderBy(x => x.ProductName);

        if(!string.IsNullOrEmpty(sort))
        {
            switch (sort)
            {
                case "dateAsc":
                    AddOrderBy(p => p.DateCreated);
                    break;
                case "dateDes":
                    AddOrderByDescending(p => p.DateCreated);
                    break;
                default:
                    AddOrderBy(n => n.ProductName);
                    break;
            }
        }
    }

    public ProductsWithBrandsSpecification(int id) : base(x => x.ID == id)
    {
        AddInclude(x => x.Brand);
    }
}
