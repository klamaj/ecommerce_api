using API.DTOs;
using AutoMapper;
using Core.Interfaces;
using Core.Models.ProductModels;
using Core.Specifications.ProductsSpecifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ProductsController;

public class ProductVariantsController : BaseApiController
{
    private readonly IGenericRepository<ProductVariants> _productVariantsRepo;
    private readonly IMapper _mapper;
    public ProductVariantsController(IGenericRepository<ProductVariants> productVariatsRepo, IMapper mapper)
    {
        _mapper = mapper;
        _productVariantsRepo = productVariatsRepo;
    }

    // GetById
    [HttpGet("get/{id}")]
    public async Task<ActionResult<ProductVariants>> GetProductVariantsById(int id)
    {
        return Ok(await _productVariantsRepo.GetByIdAsync(id));
    }

    // Get
    [HttpGet("get")]
    public async Task<ActionResult<IReadOnlyList<ProductVariantsToReturnDto>>> GetProductVariants(int prdId)
    {
        var spec = new ProductVariantsWithImagesByProductId(prdId);
        var productVariants = await _productVariantsRepo.ListAsync(spec);
        // var boom = _mapper.Map<IReadOnlyList<ProductVariants>, IReadOnlyList<ProductVariantsToReturnDto>>(productVariants);
        return Ok(_mapper.Map<IReadOnlyList<ProductVariants>, IReadOnlyList<ProductVariantsToReturnDto>>(productVariants));
        // return Ok(productVariants);
    }
}
