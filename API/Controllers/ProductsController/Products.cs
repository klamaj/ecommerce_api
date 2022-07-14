using API.DTOs;
using API.Helpers;
using AutoMapper;
using Core.Interfaces;
using Core.Models.ProductModels;
using Core.Specifications.ProductsSpecifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ProductsController;

public class Products : BaseApiController
{
    private readonly DatabaseContext _context;
    private readonly IGenericRepository<Product> _productRepo;
    private readonly IMapper _mapper;
    private readonly AddProduct _prd;
    public Products(DatabaseContext context, IGenericRepository<Product> productRepo, IMapper mapper, AddProduct prd)
    {
        _prd = prd;
        _mapper = mapper;
        _productRepo = productRepo;
        _context = context;

    }

    // Get
    [HttpGet("get")]
    public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(string sort, int? brandId)
    {
        var spec = new ProductsWithBrandsSpecification(sort, brandId);
        var products = await _productRepo.ListAsync(spec);

        return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
    }

    // getByID
    [HttpGet("get/{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        return Ok(await _productRepo.GetByIdAsync(id));
    }

    // add
    [HttpPost("add")]
    public async Task<ActionResult<ProductToAddDto>> AddProduct(ProductToAddDto val)
    {

        var product = await _prd.ProductCreation(val);
        return Ok(product);
    }
}