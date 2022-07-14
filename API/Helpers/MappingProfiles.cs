using API.DTOs;
using AutoMapper;
using Core.Models.ProductModels;

namespace API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Mapping Product
        CreateMap<Product, ProductToReturnDto>()
            .ForMember(p => p.ProductBrand, o => o.MapFrom(b => b.Brand.BrandName));

        // Mapping ProductVariants
        CreateMap<ProductVariants, ProductVariantsToReturnDto>()
            .ForMember(p => p.ProductVariantId, o => o.MapFrom(x => x.ID))
            .ForMember(p => p.ProductName, o => o.MapFrom(x => x.Product.ProductName))
            .ForMember(p => p.ProductDescription, o => o.MapFrom(x => x.Product.ProductDescription))
            .ForMember(p => p.ProductShortDescription, o => o.MapFrom(x => x.Product.ProductShortDescription))
            .ForMember(p => p.ProductBrand, o => o.MapFrom(x => x.Product.BrandId))
            .ForMember(p => p.Images, o => o.MapFrom(x => x.Images.Select(x => x.ProductVariants)));

        // Mapping Images
        CreateMap<Image, ImagesDto>()
            .ForMember(i => i.ImageId, o => o.MapFrom(x => x.ID))
            .ForMember(i => i.AlternativeText, o => o.MapFrom(x => x.AlternativeText))
            .ForMember(i => i.ImagePath, o => o.MapFrom(x => x.ImagePath));
    }
}
