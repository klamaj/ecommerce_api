using API.DTOs.ProductsDTOs;
using Core.Interfaces;
using Core.Models.ProductModels;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ProductsController;

public class Variants : BaseApiController
{
    private readonly DatabaseContext _context;
    private readonly IGenericRepository<Variant> _variantsRepo;
    public Variants(DatabaseContext context, IGenericRepository<Variant> variantsRepo)
    {
        _variantsRepo = variantsRepo;
        _context = context;
    }

    // Get
    [HttpGet("get")]
    public async Task<ActionResult<List<Variant>>> GetVariants()
    {
        return Ok(await _variantsRepo.ListAllAsync());
    }

    // GetById
    [HttpGet("get/{id}")]
    public async Task<ActionResult<Variant>> GetVariantById(int id)
    {
        return Ok(await _variantsRepo.GetByIdAsync(id));
    }

    // Add
    [HttpPost("add")]
    public async Task<ActionResult<Variant>> AddVariant(Variant variant)
    {
        try
        {
            var newVariant = new Variant();
            newVariant.VariantName = char.ToUpper(variant.VariantName[0]) + variant.VariantName.Substring(1);
            newVariant.VariantDescription = variant.VariantDescription;

            await _variantsRepo.Add(newVariant);

            return Ok("Success: " + newVariant.VariantName);

        }
        catch ( Exception ex )
        {
            throw new Exception("Already exists: ", ex);
        }
    }

    // Update
    [HttpPut("update")]
    public async Task<ActionResult<Variant>> UpdateVariant(Variant variantUpdate)
    {
        try
        {
            await _variantsRepo.Update(variantUpdate);

            return Ok(variantUpdate);
        }
        catch ( Exception )
        {
            throw new Exception("This variant doesn't Exists");
        }
    }

    // Delete
    [HttpDelete("delete")]
    public async Task<ActionResult<Variant>> RemoveVariant(int ID)
    {
        try
        {
            await _variantsRepo.Delete(ID);
            return Ok("Succesfully Deleted: " + ID);
        }
        catch ( Exception )
        {
            throw new Exception( "Variant with ID: " + ID + " doesn't exist." );
        }
    }
}
