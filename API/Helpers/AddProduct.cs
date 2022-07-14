using API.DTOs;
using Core.Interfaces;
using Core.Models.ProductModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Helpers;

public class AddProduct
{
    private readonly IGenericRepository<Product> _productRepo;
    private readonly IGenericRepository<ProductVariants> _productVariantsRepo;
    private readonly IGenericRepository<Image> _imageRepo;
    public AddProduct(IGenericRepository<Product> productRepo,
                      IGenericRepository<ProductVariants> productVariantsRepo,
                      IGenericRepository<Image> imageRepo
                    )
    {
        _imageRepo = imageRepo;
        _productVariantsRepo = productVariantsRepo;
        _productRepo = productRepo;
    }

    public async Task<ActionResult<Product>> ProductCreation(ProductToAddDto val)
    {

        var product = new Product();

        product.ProductName = val.ProductName;
        product.ProductDescription = val.ProductDescription;
        product.ProductShortDescription = val.ProductShortDescription;
        product.Slug = _productRepo.SetSlug(val.ProductName);
        product.Status = val.ProductStatus;
        product.BrandId = val.ProductBrand;

        await _productRepo.Add(product);

        foreach(var variant in val.ProductVariants)
        {
            var productVariant = new ProductVariants();

            productVariant.ProductId = product.ID;
            productVariant.ProductVariantName = variant.ProductVariantName;
            productVariant.SKU = _productVariantsRepo.SetSKU(product.ID,product.BrandId,val.ProductCategories[0],variant.ProductVariantName);
            productVariant.RegularPrice = variant.RegularPrice;
            productVariant.SalePrice = variant.SalePrice;
            productVariant.Quantity = variant.Quantity;

            await _productVariantsRepo.Add(productVariant);

            foreach(var image in variant.Images)
            {
                var img = new Image();

                img.ImagePath = image.ImagePath;
                img.AlternativeText = image.AlternativeText;
                img.ProductVariantId = productVariant.ID;

                await _imageRepo.Add(img);
            }
        }

        return product;         
    }
}
