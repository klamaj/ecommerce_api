using Core.Interfaces;
using Core.Models.ProductModels;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ProductsController;

public class Brands : BaseApiController
{
    private readonly DatabaseContext _context;
    private readonly IGenericRepository<Brand> _brandsRepo;
    public Brands(DatabaseContext context, IGenericRepository<Brand> brandsRepo)
    {
        _brandsRepo = brandsRepo;
        _context = context;
    }

    // Get
    [HttpGet("get")]
    public async Task<ActionResult<List<Brand>>> GetBrands()
    {
        return Ok( await _brandsRepo.ListAllAsync());
    }

    // GetById
    [HttpGet("get/{id}")]
    public async Task<ActionResult<Brand>> GetBrandById(int id)
    {
        return Ok(await _brandsRepo.GetByIdAsync(id));
    }

    // Add
    [HttpPost("add")]
    public async Task<ActionResult<Brand>> AddBrand(Brand val)
    {
        val.Slug = _brandsRepo.SetSlug(val.BrandName);
        await _brandsRepo.Add(val);
        return Ok(val);
    }

    // Update
    [HttpPut("update")]
    public async Task<ActionResult<Brand>> UpdateBrand(Brand val)
    {
        await _brandsRepo.Update(val);
        return Ok(val);
    }

    // Delete
    [HttpDelete("delete")]
    public async Task<ActionResult<Brand>> DeleteBrand(int ID)
    {
        try
        {
            await _brandsRepo.Delete(ID);
            return Ok("Brand with id: " + ID + " succesfully removed");
        }
        catch (Exception)
        {
            throw new Exception("Brand with ID: " + ID + " doesn't exist.");
        }
    }
}